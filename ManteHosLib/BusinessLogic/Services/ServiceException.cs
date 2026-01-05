using System;

namespace ManteHos.Services
{
    public class ServiceException : Exception
    {
        public ServiceException()
        {
        }

        public ServiceException(string message) : base(message)
        {
        }

        public ServiceException(string message, Exception inner) : base(message, inner)
        {
        }

     }
    public class LoginException : ServiceException
    {
        public LoginException() { }

        public LoginException(string message) : base(message) { }

        public LoginException(string message, Exception inner) : base(message, inner) { }
    }

    public class IncidentException : ServiceException
    {
        public IncidentException() { }

        public IncidentException(string message) : base(message)
        {

        }

        public IncidentException(string message, Exception inner) : base(message, inner)
        {
        }

    }
    public class WorkOrderException : ServiceException
    {
        public WorkOrderException() { }

        public WorkOrderException(string message) : base(message) { }

        public WorkOrderException(string message, Exception inner) : base(message, inner) { }
    }
}
