using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class BannerControlSchema
    {
        private string fileType;
        private string langType;
        private int menuID;
        private int contentID;
        private int newsCount;
        private int langId;
        private string parameter;
        private string userName;

        public string FileType
        {
            get { return fileType; }

            set { fileType = value; }
        }

        public string LangType
        {
            get { return langType; }

            set { langType = value; }
        }

        public int MenuID
        {
            get { return menuID; }

            set { menuID = value; }
        }

        public int ContentID
        {
            get { return contentID; }

            set { contentID = value; }
        }

        public int LangId
        {
            get { return langId; }

            set { langId = value; }
        }

        public int NewsCount
        {
            get { return newsCount; }

            set { newsCount = value; }
        }

        public string Parameter
        {
            get { return parameter; }

            set { parameter = value; }
        }

        public string UserName
        {
            get { return userName; }

            set { userName = value; }
        }
    }
}
