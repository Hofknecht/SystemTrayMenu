using System.Windows.Forms;
using SystemTrayMenu.Utilities;

namespace SystemTrayMenu.Helper
{
    internal class MessageFilter : IMessageFilter
    {
        private const int WM_MOUSELEAVE = 0x02A3;
        private const int WM_MOUSEMOVE = 0x0200;
        public event EventHandlerEmpty MouseLeave;
        public event EventHandlerEmpty MouseMove;
        private bool messageFilterAdded = false;

        public bool PreFilterMessage(ref Message message)
        {
            if (message.Msg == WM_MOUSELEAVE)
            {
                MouseLeave?.Invoke();
            }
            else if (message.Msg == WM_MOUSEMOVE)
            {
                MouseMove?.Invoke();
            }
            return false;
        }

        internal void StartListening()
        {
            if (!messageFilterAdded)
            {
                Application.AddMessageFilter(this);
                messageFilterAdded = true;
            }
        }

        internal void StopListening()
        {
            if (messageFilterAdded)
            {
                Application.RemoveMessageFilter(this);
                messageFilterAdded = false;
            }
        }
    }
}
