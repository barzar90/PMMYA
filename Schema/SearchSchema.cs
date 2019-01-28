using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class SearchSchema
    {

        private int langID;
        private string keyword;



        public int LangID
        {
            get { return langID; }

            set { langID = value; }
        }

        public string Keyword
        {
            get { return keyword; }

            set { keyword = value; }
        }



    }
}
