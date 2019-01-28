using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class PlaceHolderSchema
    {
        private string placeHolderName;
        private string shortDescription;
        private string shortDescription_LL;
        private string shortDescription_UL;
        private string updatedBy;
        private string createdBy;
        private bool isApprove;
        private bool isActive;
        private string actionType;
        private int placeholderId;

        public string PlaceHolderName
        {
            get { return placeHolderName; }

            set { placeHolderName = value; }
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
        public int PlaceholderId
        {
            get { return placeholderId; }

            set { placeholderId = value; }
        }
    }
}
