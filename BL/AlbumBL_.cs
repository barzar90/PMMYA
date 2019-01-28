using DAL;
using Schema;
using System;
using System.Data;

namespace BL
{
    public class AlbumBL_
    {
        #region Public variable declaration
        AlbumDAL objAlbumDAL = new AlbumDAL();
        DataSet ds = new DataSet();
        int result = 0;
        #endregion


        public DataSet GetPressNewsAlbumdetails(AlbumSchema objAlbumSchema)
        {
            try
            {
                ds = objAlbumDAL.GetPressNewsAlbumdetails(objAlbumSchema);
               
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

        public int DMLAlbumForPressNews(AlbumSchema objAlbumSchema)
        {
            try
            {
                result = objAlbumDAL.DMLAlbumForPressNews(objAlbumSchema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataSet GetVideos(AlbumSchema objAlbumSchema)
        {
            try
            {
                ds = objAlbumDAL.GetVideos(objAlbumSchema);
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

        public int SaveVideo(AlbumSchema objAlbumSchema)
        {
            try
            {
                result = objAlbumDAL.SaveVideo(objAlbumSchema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int DMLAlbhumForVideo(AlbumSchema objAlbumSchema)
        {
            try
            {
                result = objAlbumDAL.DMLAlbhumForVideo(objAlbumSchema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataSet GetAlbumDetails(AlbumSchema objAlbumSchema)
        {
            try
            {
                ds = objAlbumDAL.GetAlbumDetails(objAlbumSchema);
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

        public int DMLAlbumDetails(AlbumSchema objAlbumSchema)
        {
            try
            {
                result = objAlbumDAL.DMLAlbumDetails(objAlbumSchema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataSet GetViewAlbum(AlbumSchema objAlbumSchema)
        {
            try
            {
                ds = objAlbumDAL.GetViewAlbum(objAlbumSchema);
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

        public int DMLViewAlbum(AlbumSchema objAlbumSchema)
        {
            try
            {
                result = objAlbumDAL.DMLViewAlbum(objAlbumSchema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
