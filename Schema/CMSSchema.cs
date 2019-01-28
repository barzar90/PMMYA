using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class CMSSchema
    {

        private int menuID;
        private string langType;
        private bool isQuickMenu;
        private int menucontentID;

        public int MenuID
        {
            get { return menuID; }

            set { menuID = value; }
        }

        public string LangType
        {
            get { return langType; }

            set { langType = value; }
        }

        public bool IsQuickMenu
        {
            get { return isQuickMenu; }

            set { isQuickMenu = value; }
        }

        public int MenucontentID
        {
            get { return menucontentID; }

            set { menucontentID = value; }
        }
    }
}
