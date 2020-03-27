//using System;
//using System.Runtime.InteropServices;

//namespace SystemTrayMenu.Helper
//{
//    public class LocalWindowsHook
//    {
//        // ************************************************************************
//        // Filter function delegate
//        public delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);
//        // ************************************************************************

//        // ************************************************************************
//        // Internal properties
//        protected IntPtr m_hhook = IntPtr.Zero;
//        protected HookProc m_filterFunc = null;
//        protected HookType m_hookType;
//        // ************************************************************************

//        // ************************************************************************
//        // Event delegate
//        public delegate void HookEventHandler(object sender, HookEventArgs e);
//        // ************************************************************************

//        // ************************************************************************
//        // Event: HookInvoked 
//        public event HookEventHandler HookInvoked;
//        protected void OnHookInvoked(HookEventArgs e)
//        {
//            if (HookInvoked != null)
//            {
//                HookInvoked(this, e);
//            }
//        }
//        // ************************************************************************

//        // ************************************************************************
//        // Class constructor(s)
//        public LocalWindowsHook(HookType hook)
//        {
//            m_hookType = hook;
//            m_filterFunc = new HookProc(CoreHookProc);
//        }
//        public LocalWindowsHook(HookType hook, HookProc func)
//        {
//            m_hookType = hook;
//            m_filterFunc = func;
//        }
//        // ************************************************************************

//        // ************************************************************************
//        // Default filter function
//        protected int CoreHookProc(int code, IntPtr wParam, IntPtr lParam)
//        {
//            if (code < 0)
//            {
//                return CallNextHookEx(m_hhook, code, wParam, lParam);
//            }

//            // Let clients determine what to do
//            HookEventArgs e = new HookEventArgs
//            {
//                HookCode = code,
//                wParam = wParam,
//                lParam = lParam
//            };
//            OnHookInvoked(e);

//            // Yield to the next hook in the chain
//            return CallNextHookEx(m_hhook, code, wParam, lParam);
//        }

//        public void Install()
//        {
//            m_hhook = SetWindowsHookEx(
//                m_hookType,
//                m_filterFunc,
//                IntPtr.Zero,
//                AppDomain.GetCurrentThreadId());
//        }

//        public void Uninstall()
//        {
//            UnhookWindowsHookEx(m_hhook);
//        }

//        [DllImport("user32.dll")]
//        protected static extern IntPtr SetWindowsHookEx(HookType code,
//            HookProc func,
//            IntPtr hInstance,
//            int threadID);

//        [DllImport("user32.dll")]
//        protected static extern int UnhookWindowsHookEx(IntPtr hhook);

//        [DllImport("user32.dll")]
//        protected static extern int CallNextHookEx(IntPtr hhook,
//            int code, IntPtr wParam, IntPtr lParam);
//    }
//}
