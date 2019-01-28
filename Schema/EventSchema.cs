using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class EventSchema
    {
        private int keyid;
        private string eventheading;
        private bool is_active;
        private string event_detail_xml;
        private string event_image_xml;
        private string event_dtls;


        public int KeyID
        {
            get { return keyid; }
            set { keyid = value; }
        }

        public string EventHeading
        {
            get { return eventheading; }
            set { eventheading = value; }
        }

        public bool Is_Active
        {
            get { return is_active; }
            set { is_active = value; }
        }

        public string Event_Detail_Xml
        {
            get { return event_detail_xml; }
            set { event_detail_xml = value; }
        }

        public string Event_Image_Xml
        {
            get { return event_image_xml; }
            set { event_image_xml = value; }
        }

        public string Event_Dtls
        {
            get { return event_dtls; }
            set { event_dtls = value; }
        }

    }
}
