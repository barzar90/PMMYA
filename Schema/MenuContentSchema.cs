using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class MenuContentSchema
    {
        private int menuContentID;
        private string pageTitle;
        private string pageTitle_LL;
        private string pageTitle_UL;
        private string shortDescription;
        private string shortDescription_LL;
        private string shortDescription_UL;
        private string longDescription;
        private string longDescription_LL;
        private string longDescription_UL;
        private int sequenceNo;
        private int menuID;
        private string updatedBy;
        private string createdBy;
        private bool isApprove;
        private bool isActive;
        private string actionType;

        public int MenuContentID
        {
            get { return menuContentID; }

            set { menuContentID = value; }
        }

        public string PageTitle
        {
            get { return pageTitle; }

            set { pageTitle = value; }
        }
        public string PageTitle_LL
        {
            get { return pageTitle_LL; }

            set { pageTitle_LL = value; }
        }
        public string PageTitle_UL
        {
            get { return pageTitle_UL; }

            set { pageTitle_UL = value; }
        }
        public string ShortDescription
        {
            get { return shortDescription; }

            set { shortDescription = value; }
        }
        public string ShortDescription_LL
        {
            get { return shortDescription_LL; }

            set { shortDescription_LL = value; }
        }
        public string ShortDescription_UL
        {
            get { return shortDescription_UL; }

            set { shortDescription_UL = value; }
        }

        public int SequenceNo
        {
            get { return sequenceNo; }

            set { sequenceNo = value; }
        }

        public int MenuID
        {
            get { return menuID; }

            set { menuID = value; }
        }

        public string CreatedBy
        {
            get { return createdBy; }

            set { createdBy = value; }
        }
        public string UpdatedBy
        {
            get { return updatedBy; }

            set { updatedBy = value; }
        }

        public bool IsApprove
        {
            get { return isApprove; }

            set { isApprove = value; }
        }

        public bool IsActive
        {
            get { return isActive; }

            set { isActive = value; }
        }
        public string ActionType
        {
            get { return actionType; }

            set { actionType = value; }
        }
        public string LongDescription
        {
            get { return longDescription; }

            set { longDescription = value; }
        }
        public string LongDescription_LL
        {
            get { return longDescription_LL; }

            set { longDescription_LL = value; }
        }
        public string LongDescription_UL
        {
            get { return longDescription_UL; }

            set { longDescription_UL = value; }
        }
    }
}
