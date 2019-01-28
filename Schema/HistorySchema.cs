using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class HistorySchema
    {
        private int srNo;
        private int yearOfHistory;
        private string details;
        private string imageContent;
        private string imageFileName;
        private string imageFileType;
        private DateTime createdOn;


        public int SrNo
        {
            get { return srNo; }
            set { srNo = value; }
        }
        public int YearOfHistory
        {
            get { return yearOfHistory; }
            set { yearOfHistory = value; }
        }
        public string Details
        {
            get { return details; }
            set { details = value; }
        }

        public string ImageContent
        {
            get { return imageContent; }
            set { imageContent = value; }
        }

        public string ImageFileName
        {
            get { return imageFileName; }
            set { imageFileName = value; }
        }

        public string ImageFileType
        {
            get { return imageFileType; }
            set { imageFileType = value; }
        }
        public DateTime CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }
    }
}
