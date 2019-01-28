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
    public class ViewPhotoAlbumBL
    {

        #region Public variable declaration
        ViewPhotoAlbumDAL objViewPhotoAlbum = new ViewPhotoAlbumDAL();
        System.Data.DataSet ds = new DataSet();
        #endregion

        public DataSet ViewPhotoAlbum(ViewPhotoAlbumSchema viewPhotoAlbumSchema)
        {
            try
            {
                ds = objViewPhotoAlbum.GetPhotoAlbum(viewPhotoAlbumSchema);
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
        public DataSet ViewSubAlbum()
        {
            try
            {
                ds = objViewPhotoAlbum.GetSubAlbum();
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


        public DataSet CheckValidAlbum(ViewPhotoAlbumSchema viewPhotoAlbumSchema)
        {
            try
            {
                ds = objViewPhotoAlbum.CheckValidAlbum(viewPhotoAlbumSchema);
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

        public int DMLAlbumPhoto(ViewPhotoAlbumSchema viewPhotoAlbumSchema)
        {
            try
            {
                int result = objViewPhotoAlbum.DMLAlbumPhoto(viewPhotoAlbumSchema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataSet DisplayPhoto()
        {
            try
            {
                ds = objViewPhotoAlbum.DisplayPhoto();
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

        public DataSet DisplayAlbum()
        {
            try
            {
                ds = objViewPhotoAlbum.DisplayAlbum();
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
