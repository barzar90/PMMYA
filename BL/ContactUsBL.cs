using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schema;
using DAL;

namespace BL
{
    public class ContactUsBL
    {
        #region Public variable declaration
        ContactUsDAL objContactDAL = new ContactUsDAL();
        DataSet ds = new DataSet();
        #endregion

        public DataSet GetDPODetails(ContactUsSchema objContactUs)
        {
            try
            {
                ds = objContactDAL.GetDPODetails(objContactUs);
                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }
    }
}
