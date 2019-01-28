using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schema;
using DAL;

namespace BL
{
    public class BL_ErrorLog
    {

        DAL_Errorlog objerrorlog;

        public int SetErrorLogBl(Entity_tblErrorLog tblerrorLog)
        {
            int exceptionId = -1;
            try
            {
                objerrorlog = new DAL_Errorlog();
                exceptionId = objerrorlog.ErrorlogDl(tblerrorLog);
            }
            catch
            {

            }
            finally
            {
                objerrorlog = null;
            }
            return exceptionId;
        }
    }
}
