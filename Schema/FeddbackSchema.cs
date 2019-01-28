using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class FeddbackSchema
    {
        private string name;
        private string contact;
        private string subject;
        private string email;
        private string message;
        private DateTime createdOn;
        private int langid;
        private int districtid;
        public string Name
        {
            get { return name; }

            set { name = value; }
        }

        public string Contact
        {
            get { return contact; }

            set { contact = value; }
        }

        public string Subject
        {
            get { return subject; }

            set { subject = value; }
        }

        public string Email
        {
            get { return email; }

            set { email = value; }
        }

        public string Message
        {
            get { return message; }

            set { message = value; }
        }

        public DateTime CreatedOn
        {
            get { return createdOn; }

            set { createdOn = value; }
        }

        public int Langid
        {
            get { return langid; }

            set { langid = value; }
        }

        public int Districtid
        {
            get { return districtid; }

            set { districtid = value; }
        }

    }
}
