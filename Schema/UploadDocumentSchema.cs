using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class UploadDocumentSchema
    {
        private string actiontype;
        private Guid enumarationvalueid;
        private Guid documenttype;
        private bool chkArchive;
        private Guid parent_enumarationvalueid;
        private Guid documentid;
        private string subject;
        private string subject_LL;
        private string subject_UL;
        private string documentPath;
        private string documentPath_LL;
        private string documentPath_UL;
        private string createdby;
        private string size;
        private int seasonId;
        private bool isActive;
        private bool isArchive;
        private string title;
        private string title_LL;
        private string title_UL;
        private string description;
        private string description_LL;
        private string description_UL;
        private string documentImage;
        private DateTime createddate;

        public string Actiontype
        {
            get { return actiontype; }

            set { actiontype = value; }
        }

        public Guid Enumarationvalueid
        {
            get { return enumarationvalueid; }

            set { enumarationvalueid = value; }
        }

        public Guid Documenttype
        {
            get { return documenttype; }

            set { documenttype = value; }
        }

        public bool ChkArchive
        {
            get { return chkArchive; }

            set { chkArchive = value; }
        }

        public Guid Parent_Enumarationvalueid
        {
            get { return parent_enumarationvalueid; }

            set { parent_enumarationvalueid = value; }
        }

        public Guid Documentid
        {
            get { return documentid; }

            set { documentid = value; }
        }

        public string Subject
        {
            get { return subject; }

            set { subject = value; }
        }

        public string Subject_LL
        {
            get { return subject_LL; }

            set { subject_LL = value; }
        }

        public string Subject_UL
        {
            get { return subject_UL; }

            set { subject_UL = value; }
        }

        public string DocumentPath
        {
            get { return documentPath; }

            set { documentPath = value; }
        }

        public string DocumentPath_LL
        {
            get { return documentPath_LL; }

            set { documentPath_LL = value; }
        }

        public string DocumentPath_UL
        {
            get { return documentPath_UL; }

            set { documentPath_UL = value; }
        }

        public string Createdby
        {
            get { return createdby; }

            set { createdby = value; }
        }

        public string Size
        {
            get { return size; }

            set { size = value; }
        }

        public int SeasonId
        {
            get { return seasonId; }

            set { seasonId = value; }
        }

        public bool Isctive
        {
            get { return isActive; }

            set { isActive = value; }
        }

        public bool IsArchive
        {
            get { return isArchive; }

            set { isArchive = value; }
        }

        public string Title
        {
            get { return title; }

            set { title = value; }
        }

        public string Title_LL
        {
            get { return title_LL; }

            set { title_LL = value; }
        }

        public string Title_UL
        {
            get { return title_UL; }

            set { title_UL = value; }
        }
        public string Description
        {
            get { return description; }

            set { description = value; }
        }
        public string Description_LL
        {
            get { return description_LL; }

            set { description_LL = value; }
        }
        public string Description_UL
        {
            get { return description_UL; }

            set { description_UL = value; }
        }

        public string DocumentImage
        {
            get { return documentImage; }

            set { documentImage = value; }
        }

        public DateTime Createddate
        {
            get { return createddate; }

            set { createddate = value; }
        }


    }
}
