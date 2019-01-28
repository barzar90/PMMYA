using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class UploadEventsSchema
    {
        int eventId;
        string eventTitle;
        string eventTitleLL;
        string eventDescr;
        string eventDescrLL;
        byte[] imageContent;
        string imageType;
        string imageName;
        bool isActive;
        DateTime createdDate;
        DateTime updatedDate;
        DateTime createBy;
        DateTime updatedBy;

        public DateTime UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        public DateTime CreateBy
        {
            get { return createBy; }
            set { createBy = value; }
        }

        public DateTime UpdatedDate
        {
            get { return updatedDate; }
            set { updatedDate = value; }
        }

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }

        public string ImageType
        {
            get { return imageType; }
            set { imageType = value; }
        }

        public byte[] ImageContent
        {
            get { return imageContent; }
            set { imageContent = value; }
        }

        public string EventDescrLL
        {
            get { return eventDescrLL; }
            set { eventDescrLL = value; }
        }

        public string EventDescr
        {
            get { return eventDescr; }
            set { eventDescr = value; }
        }

        public string EventTitleLL
        {
            get { return eventTitleLL; }
            set { eventTitleLL = value; }
        }

        public string EventTitle
        {
            get { return eventTitle; }
            set { eventTitle = value; }
        }

        public int EventId
        {
            get { return eventId; }
            set { eventId = value; }
        }

    }
}
