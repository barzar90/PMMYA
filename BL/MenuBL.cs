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
    public class MenuBL
    {
        #region Public variable declaration
        MenuDAL objMenuDAL = new MenuDAL();
        DataSet ds = new DataSet();
        int result = 0;
        #endregion

        public DataSet GetMenuType()
        {
            try
            {
                ds = objMenuDAL.GetMenuType();
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

        public DataSet GetParentList()
        {
            try
            {
                ds = objMenuDAL.GetParentList();
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

        public DataSet GetChildList(MenuSchema objmenuschema)
        {
            try
            {
                ds = objMenuDAL.GetChildList(objmenuschema);
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

        public DataSet GetPageUrl(MenuSchema objmenuschema)
        {
            try
            {
                ds = objMenuDAL.GetPageUrl(objmenuschema);
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

        public DataSet GetMenuId(MenuSchema objmenuschema)
        {
            try
            {
                ds = objMenuDAL.GetMenuId(objmenuschema);
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

        public DataSet GetPagedata(MenuSchema objmenuschema)
        {
            try
            {
                ds = objMenuDAL.GetPagedata(objmenuschema);
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


        public int SaveMenuDeatails(MenuSchema objmenuschema)
        {
            try
            {
                result = objMenuDAL.SaveMenuDeatails(objmenuschema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataSet GetMenuListDetails(MenuSchema objmenuschema)
        {
            try
            {
                ds = objMenuDAL.GetMenuListDetails(objmenuschema);
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

        public int DMLMenuListDetails(MenuSchema objmenuschema)
        {
            try
            {
                result = objMenuDAL.DMLMenuListDetails(objmenuschema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataSet GetMenuDetails(MenuSchema objmenuschema)
        {
            try
            {
                ds = objMenuDAL.GetMenuDetails(objmenuschema);
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
