using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class AppErrorSchema
    {
        private string errorCode;
        private string message;
        private string type;
        private string stackTrace;
        private string innerException;
        private string htmlError;
        private string userIP;
        private string browser;
        private string browserVersion;
        private int errorId;

        public string ErrorCode
        {
            get { return errorCode; }

            set { errorCode = value; }
        }

        public string Message
        {
            get { return message; }
            
            set { message = value; }
        }

        public string Type
        {
            get { return type; }

            set { type = value; }
        }

        public string StackTrace
        {
            get { return stackTrace; }

            set { stackTrace = value; }
        }

        public string InnerException
        {
            get { return innerException; }

            set { innerException = value; }
        }

        public string HtmlError
        {
            get { return htmlError; }

            set { htmlError = value; }
        }

        public string UserIp
        {
            get { return userIP; }

            set { userIP = value; }
        }

        public string Browser
        {
            get { return browser; }

            set { browser = value; }
        }

        public string BrowserVersion
        {
            get { return browserVersion; }

            set { browserVersion = value; }
        }

        public int ErrorId
        {
            get { return errorId; }

            set { errorId = value; }
        }


    }
}
