using System;
using System.Runtime.Serialization;

namespace SystemTrayMenu.Helper
{
    [Serializable]
    public class ShellContextMenuException : Exception
    {
        public ShellContextMenuException()
        {
            // Add any type-specific logic, and supply the default message.
        }

        public ShellContextMenuException(string message) : base(message)
        {
            // Add any type-specific logic.
        }

        public ShellContextMenuException(string message, Exception innerException) :
           base(message, innerException)
        {
            // Add any type-specific logic for inner exceptions.
        }

        protected ShellContextMenuException(SerializationInfo info,
           StreamingContext context) : base(info, context)
        {
            // Implement type-specific serialization constructor logic.
        }
    }

}
