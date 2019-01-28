using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class Entity_tblErrorLog
    {
        private int idField;

        public int Id
        {
            get { return this.idField; }
            set { this.idField = value; }
        }

        private string errorCodeField;

        public string ErrorCode
        {
            get { return this.errorCodeField; }
            set { this.errorCodeField = value; }
        }

        private string messageField;

        public string Message
        {
            get { return this.messageField; }
            set { this.messageField = value; }
        }

        private string typeField;

        public string Type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }

        private string stackTraceField;

        public string StackTrace
        {
            get { return this.stackTraceField; }
            set { this.stackTraceField = value; }
        }

        private string innerExceptionTraceField;

        public string InnerException
        {
            get { return this.innerExceptionTraceField; }
            set { this.innerExceptionTraceField = value; }
        }

        private string htmlErrorField;

        public string HtmlError
        {
            get { return this.htmlErrorField; }
            set { this.htmlErrorField = value; }
        }

        private string browserField;

        public string Browser
        {
            get { return this.browserField; }
            set { this.browserField = value; }
        }

        private string browserVersionField;

        public string BrowserVersion
        {
            get { return this.browserVersionField; }
            set { this.browserVersionField = value; }
        }

        private string userIpField;

        public string UserIp
        {
            get { return this.userIpField; }
            set { this.userIpField = value; }
        }

        private DateTime createdField;

        public DateTime Created
        {
            get { return this.createdField; }
            set { this.createdField = value; }
        }
    }
}
