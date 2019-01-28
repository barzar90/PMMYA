using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class ContactUsSchema
    {
        private int srno;
        private string districtname;
        private string dponame;
        private string dpoaddress;
        private string emailid;
        private string telno;
        private int langid;

        public int Srno
        {
            get { return srno; }

            set { srno = value; }
        }

        public string DistrictName
        {
            get { return districtname; }

            set { districtname = value; }
        }

        public string DPOName
        {
            get { return dponame; }

            set { dponame = value; }
        }

        public string DPOAddress
        {
            get { return dpoaddress; }

            set { dpoaddress = value; }
        }

        public string EmailID
        {
            get { return emailid; }

            set { emailid = value; }
        }

        public string TelNo
        {
            get { return telno; }

            set { telno = value; }
        }

        public int Langid
        {
            get { return langid; }

            set { langid = value; }
        }

    }
}
