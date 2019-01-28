using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class UploadFileSchema
    {
        private int rowId;
        private int fileCategory;
        private string fileTitle;
        private string fileTitleLL;
        private string fileDetail;
        private string fileDetailLL;
        private byte[] imageContent;
        private string imageType;
        private string fileSize;
        private bool isActive;
        private int sequenceNo;
        private string ipAddress;
        private string createdBy;
        private DateTime createdDate;
        private DateTime updatedDate;
        private string fileTitleUL;
        private string fileDetailUL;

        public int RowId
        {
            get { return rowId; }
            set { rowId = value; }
        }
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        public byte[] ImageContent
        {
            get { return imageContent; }
            set { imageContent = value; }
        }

        public string CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
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

        public string IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        public int SequenceNo
        {
            get { return sequenceNo; }
            set { sequenceNo = value; }
        }




        public string FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }

        public string ImageType
        {
            get { return imageType; }
            set { imageType = value; }
        }


        public string FileDetailLL
        {
            get { return fileDetailLL; }
            set { fileDetailLL = value; }
        }

        public string FileDetail
        {
            get { return fileDetail; }
            set { fileDetail = value; }
        }

        public string FileTitleLL
        {
            get { return fileTitleLL; }
            set { fileTitleLL = value; }
        }

        public string FileTitle
        {
            get { return fileTitle; }
            set { fileTitle = value; }
        }
        public int FileCategory
        {
            get { return fileCategory; }
            set { fileCategory = value; }
        }
        // Added By K.P on 22-05-2018
        public string FileTitleUL
        {
            get { return fileTitleUL; }
            set { fileTitleUL = value; }
        }

        public string FileDetailUL
        {
            get { return fileDetailUL; }
            set { fileDetailUL = value; }
        }

        //End
    }
}
