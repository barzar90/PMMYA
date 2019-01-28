using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class EnumerationSchema
    {
        private string enumerationname;
        private string enumerationcode;
        private string enumerationvalue;
        private string enumerationvalueid;
        private string enumerationid;
        private string langid;
        private string enumationValue_LL;
        private bool isactive;
        private int sortOrder;
        private string parent_EnumerationValueID;

        public string Parent_EnumerationValueID
        {
            get { return parent_EnumerationValueID; }
            set { parent_EnumerationValueID = value; }
        }

        public int SortOrder
        {
            get { return sortOrder; }
            set { sortOrder = value; }
        }

        public bool Isactive
        {
            get { return isactive; }
            set { isactive = value; }
        }


        public string EnumationValue_LL
        {
            get { return enumationValue_LL; }
            set { enumationValue_LL = value; }
        }

        public string LangID
        {
            get { return langid; }
            set { langid = value; }
        }

        public string EnumerationName
        {
            get { return enumerationname; }
            set { enumerationname = value; }
        }

        public string EnumerationCode
        {
            get { return enumerationcode; }
            set { enumerationcode = value; }
        }


        public string EnumerationValue
        {
            get { return enumerationvalue; }
            set { enumerationvalue = value; }
        }
        public string EnumerationValueID
        {
            get
            {
                return enumerationvalueid;
            }
            set { enumerationvalueid = value; }
        }
        public string EnumerationID
        {
            get
            {
                return enumerationid;
            }
            set { enumerationid = value; }
        }
    }
}
