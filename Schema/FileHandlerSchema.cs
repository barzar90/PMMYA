using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class FileHandlerSchema
    {
        private int rowid;

        public int RowID
        {
            get { return rowid; }

            set { rowid = value; }
        }
    }
}
