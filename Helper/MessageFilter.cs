using System.Windows.Forms;

namespace SystemTrayMenu
{
    public delegate void EventHandler();

    class MessageFilter : IMessageFilter
    {
        const int WM_MOUSELEAVE = 0x02A3;
        const int WM_MOUSEMOVE = 0x0200;
        const int WM_NCMOUSEMOVE = 0x00A0;
        public event EventHandler MouseLeave;
        public event EventHandler MouseMove;
        public event EventHandler ScrollBarMouseMove;

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
            else if (message.Msg == WM_NCMOUSEMOVE)
            {
                ScrollBarMouseMove?.Invoke();
            }
            return false;
        }
    }
}
