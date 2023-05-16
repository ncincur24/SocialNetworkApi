using System;

namespace SocialNetwork.API.ErrorLogging
{
    public interface IErrorLogger
    {
        void Log(AppError error);
    }

    public class AppError
    {
        public Exception Exception { get; set; }
        public string Username { get; set; }
        public Guid ErrorId { get; set; }
    }
}
