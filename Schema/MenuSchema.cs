using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class MenuSchema
    {
        private int menuid;
        private int rowid;
        private int parentid;
        private string menuName;
        private string menuName_LL;
        private string menuName_UL;
        private bool isnewflag;
        private bool active;
        private bool isexternalLink;
        private string metaDescription;
        private string metaDescription_LL;
        private string metaDescription_UL;
        private string metaKeywords;
        private string metaKeywords_LL;
        private string metaKeywords_UL;
        public byte[] menuimage;
        private int sequenceno;
        private string menuCategory;
        private int menuType;
        private string menuTypeValue;
        private int createdby;
        private string pageHeading;
        private string pageHeading_LL;
        private string pageHeading_UL;
        private string pageTitle;
        private string pageTitle_LL;
        private string pageTitle_UL;
        private bool forMobileVersion;
        private Guid role_id;
        private string actiontype;
        private string fileExt;
        


        public int Menuid
        {
            get { return menuid; }

            set { menuid = value; }
        }

        public int Rowid
        {
            get { return rowid; }

            set { rowid = value; }
        }

        public int Parentid
        {
            get { return parentid; }

            set { parentid = value; }
        }

        public string MenuName
        {
            get { return menuName; }

            set { menuName = value; }
        }

        public string MenuName_LL
        {
            get { return menuName_LL; }

            set { menuName_LL = value; }
        }

        public string MenuName_UL
        {
            get { return menuName_UL; }

            set { menuName_UL = value; }
        }

        public bool IsNewflag
        {
            get { return isnewflag; }

            set { isnewflag = value; }
        }
        public bool Active
        {
            get { return active; }

            set { active = value; }
        }

        public bool IsEternalLink
        {
            get { return isexternalLink; }

            set { isexternalLink = value; }
        }
        public string MetaDescription
        {
            get { return metaDescription; }

            set { metaDescription = value; }
        }
        public string MetaDescription_LL
        {
            get { return metaDescription_LL; }

            set { metaDescription_LL = value; }
        }
        public string MetaDescription_UL
        {
            get { return metaDescription_UL; }

            set { metaDescription_UL = value; }
        }
        public string MetaKeywords
        {
            get { return metaKeywords; }

            set { metaKeywords = value; }
        }
        public string MetaKeywords_LL
        {
            get { return metaKeywords_LL; }

            set { metaKeywords_LL = value; }
        }
        public string MetaKeywords_UL
        {
            get { return metaKeywords_UL; }

            set { metaKeywords_UL = value; }
        }

        public byte[] MenuImage
        {
            get { return menuimage; }

            set { menuimage = value; }
        }

        public int SequenceNo
        {
            get { return sequenceno; }

            set { sequenceno = value; }
        }

        public string MenuCategory
        {
            get { return menuCategory; }

            set { menuCategory = value; }
        }

        public int MenuType
        {
            get { return menuType; }

            set { menuType = value; }
        }

        public string MenuTypeValue
        {
            get { return menuTypeValue; }

            set { menuTypeValue = value; }
        }

        public int Createdby
        {
            get { return createdby; }

            set { createdby = value; }
        }

        public string PageHeading
        {
            get { return pageHeading; }

            set { pageHeading = value; }
        }

        public string PageHeading_LL
        {
            get { return pageHeading_LL; }

            set { pageHeading_LL = value; }
        }

        public string PageHeading_UL
        {
            get { return pageHeading_UL; }

            set { pageHeading_UL = value; }
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

        public bool ForMobileVersion
        {
            get { return forMobileVersion; }

            set { forMobileVersion = value; }
        }

        public Guid Role_id
        {
            get { return role_id; }

            set { role_id = value; }
        }

        public string ActionType
        {
            get { return actiontype; }

            set { actiontype = value; }
        }

        public string FileExt
        {
            get { return fileExt; }

            set { fileExt = value; }
        }
    }
}
