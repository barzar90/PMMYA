using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using BL;
using DAL;
using System;
using Schema;

namespace BL
{
    public class MenuContentBL
    {
        #region Public variable declaration
        MenuContentDAL objmenucontentDAL = new MenuContentDAL();
        DataSet ds = new DataSet();
        int result = 0;
        #endregion


        public DataSet GetMenuContentDetails(MenuContentSchema objmenuContentSchema)
        {
            try
            {
                ds = objmenucontentDAL.GetMenuContentDetails(objmenuContentSchema);
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

        public int SaveMenuContentDeatails(MenuContentSchema objmenuContentSchema)
        {
            try
            {
                result = objmenucontentDAL.SaveMenuContentDeatails(objmenuContentSchema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public DataSet GetMenuContentList(MenuContentSchema objmenuContentSchema)
        {
            try
            {
                ds = objmenucontentDAL.GetMenuContentList(objmenuContentSchema);
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

        public int DMLMenuContentList(MenuContentSchema objmenuContentSchema)
        {
            try
            {
                result = objmenucontentDAL.DMLMenuContentList(objmenuContentSchema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
