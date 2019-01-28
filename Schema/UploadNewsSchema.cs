using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class UploadNewsSchema
    {
        private string news;
        private string news_ll;
        private string news_ul;
        private int langid;
        private bool is_active;
        private string url;
        private DateTime createddate;
        private bool islink;
        private string actiontype;
        private int id;
        private bool isnew;
        private string para;
        private string search;

        public string News
        {
            get { return news; }

            set { news = value; }
        }

        public string News_LL
        {
            get { return news_ll; }

            set { news_ll = value; }
        }
        public string News_UL
        {
            get { return news_ul; }

            set { news_ul = value; }
        }

        public int LangID
        {
            get { return langid; }

            set { langid = value; }
        }

        public bool Is_Active
        {
            get { return is_active; }

            set { is_active = value; }
        }

        public string URL
        {
            get { return url; }

            set { url = value; }
        }

        public DateTime CreatedDate
        {
            get { return createddate; }

            set { createddate = value; }
        }

        public bool IsLink
        {
            get { return islink; }

            set { islink = value; }
        }

        public string ActionType
        {
            get { return actiontype; }

            set { actiontype = value; }
        }

        public int ID
        {
            get { return id; }

            set { id = value; }
        }

        public bool IsNew
        {
            get { return isnew; }

            set { isnew = value; }
        }

        public string Para
        {
            get { return para; }

            set { para = value; }
        }

        public string Search
        {
            get { return search; }

            set { search = value; }
        }
    }
}
