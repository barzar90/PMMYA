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
   public class BannerBL
    {
        #region Public variable declaration
        BannerDAL objBannerDAL = new BannerDAL();
        DataSet ds = new DataSet();
        #endregion

        public DataSet GetBannerContentDetails(BannerControlSchema objBannerControlSchema)
        {
            try
            {
                ds = objBannerDAL.GetBannerContentDetails(objBannerControlSchema);
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

        public DataSet GetKeyPersonDetails(BannerControlSchema objBannerControlSchema)
        {
            try
            {
                ds = objBannerDAL.GetKeyPersonDetails(objBannerControlSchema);
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

        public DataSet GetLastReviewDate(BannerControlSchema objBannerControlSchema)
        {
            try
            {
                ds = objBannerDAL.GetLastReviewDate(objBannerControlSchema);
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

        public DataSet GetNews(BannerControlSchema objBannerControlSchema)
        {
            try
            {
                ds = objBannerDAL.GetNews(objBannerControlSchema);
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

        public DataSet GetMarquee(BannerControlSchema objBannerControlSchema)
        {
            try
            {
                ds = objBannerDAL.GetMarquee(objBannerControlSchema);
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

        public DataSet GetUCBreadCrumData(BannerControlSchema objBannerControlSchema)
        {
            try
            {
                ds = objBannerDAL.GetUCBreadCrumData(objBannerControlSchema);
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

        public DataSet GetUCBreadCrumDataforQuickMenu(BannerControlSchema objBannerControlSchema)
        {
            try
            {
                ds = objBannerDAL.GetUCBreadCrumDataforQuickMenu(objBannerControlSchema);
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

        public DataSet GetVisitorCount(BannerControlSchema objBannerControlSchema)
        {
            try
            {
                ds = objBannerDAL.GetVisitorCount(objBannerControlSchema);
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
