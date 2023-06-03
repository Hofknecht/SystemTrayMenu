// <copyright file="IpcPipe.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2023-2023 Peter Kirmeier
// Based on example: https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-use-named-pipes-for-network-interprocess-communication

namespace SystemTrayMenu.Business
{
    using System;
    using System.IO;
    using System.IO.Pipes;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using SystemTrayMenu.Utilities;

    internal class IpcPipe : IDisposable
    {
        private readonly string pipeName;
        private readonly string pipeHello;

        private NamedPipeServerStream? serverPipe;
        private Thread? serverThread;
        private Func<string, string>? serverHandler;
        private ManualResetEvent? cancelEvent;
        private bool isStopped;

        internal IpcPipe(byte version, string name)
        {
            pipeName = version.ToString() + "." + name + "." + (Assembly.GetExecutingAssembly().GetName().Name ?? "local");
            pipeHello = "Hello " + nameof(IpcPipe) + " from " + pipeName + "!";
        }

        public void Dispose()
        {
            isStopped = true;
            cancelEvent?.Set();
            serverThread?.Join(250);
            serverPipe?.Dispose();
            cancelEvent?.Dispose();
            serverThread = null;
        }

        internal void StartServer(Func<string, string> handler)
        {
            cancelEvent = new(false);
            serverHandler = handler;

            serverThread = new(ServerThread);
            serverThread?.Start(this);
        }

        internal string? SendToServer(string request)
        {
            string? response = null;
            NamedPipeClientStream pipeClient = new(pipeName);

            // Wait a bit in case server is restarting
            pipeClient.Connect(500);

            IpcPipeStream stream = new (pipeClient);
            string hello = stream.ReadString();

            // Check who there is, just for sanity
            if (hello == pipeHello)
            {
                stream.WriteString(request);
                response = stream.ReadString();
            }
            else
            {
                Log.Info($"IPC client pipe error: Invalid hello: \"" + hello + "\"");
            }

            pipeClient.Dispose();

            return response;
        }

        private static void ServerThread(object? data)
        {
            IpcPipe ipc = (IpcPipe)data!;
            Func<string, string> handler = ipc.serverHandler ?? (_ => string.Empty);

            while (!ipc.isStopped)
            {
                NamedPipeServerStream pipe = ipc.serverPipe = new(ipc.pipeName);
                try
                {
                    // Stupid workaround for WaitForConnection as it will not unblock when pipe gets closed or disposed.
                    // See: https://stackoverflow.com/questions/607872/what-is-a-good-way-to-shutdown-threads-blocked-on-namedpipeserverwaitforconnect
                    ManualResetEvent connectEvent = new (false);
                    pipe.BeginWaitForConnection(ar => { connectEvent.Set(); }, null);
                    if (WaitHandle.WaitAny(new WaitHandle[] { connectEvent, ipc.cancelEvent! }) == 1)
                    {
                        ipc.serverPipe = null;
                        pipe.Dispose();
                        return;
                    }

                    IpcPipeStream stream = new(pipe);

                    // Send indicator who we are, just for sanity checking
                    stream.WriteString(ipc.pipeHello);

                    string request = stream.ReadString();
                    string respone = handler.Invoke(request);
                    stream.WriteString(respone);
                }
                catch (Exception ex)
                {
                    Log.Warn($"IPC server pipe error: ", ex);
                }

                ipc.serverPipe = null;
                pipe.Dispose();
            }
        }

        // Defines the data protocol for reading and writing strings on our stream
        private class IpcPipeStream
        {
            private readonly Stream ioStream;
            private readonly UnicodeEncoding streamEncoding = new();

            internal IpcPipeStream(Stream ioStream)
            {
                this.ioStream = ioStream;
            }

            internal string ReadString()
            {
                int len = 0;

                // Receive 32 bit message size
                len += ioStream.ReadByte() >> 24;
                len += ioStream.ReadByte() >> 16;
                len += ioStream.ReadByte() >> 8;
                len += ioStream.ReadByte() >> 0;

                // Receive message
                byte[] inBuffer = new byte[len];
                ioStream.Read(inBuffer, 0, len);

                return streamEncoding.GetString(inBuffer);
            }

            internal int WriteString(string outString)
            {
                byte[] outBuffer = streamEncoding.GetBytes(outString);
                int len = outBuffer.Length;
                if (len > int.MaxValue)
                {
                    throw new InternalBufferOverflowException("More data than available space withing an IPC message");
                }

                // Send 32 bit message size
                ioStream.WriteByte((byte)((len >> 24) & 0xFF));
                ioStream.WriteByte((byte)((len >> 16) & 0xFF));
                ioStream.WriteByte((byte)((len >> 8) & 0xFF));
                ioStream.WriteByte((byte)((len >> 0) & 0xFF));

                // Send message
                ioStream.Write(outBuffer, 0, len);

                ioStream.Flush();

                return outBuffer.Length + 2;
            }
        }
    }
}
