using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Schema;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BL
{
    public class UploadVideo_BL
    {
        #region Insert
        public Int64 InsertVideo(UploadVideoSchema objUploadVideoSchema)
        {
            try
            {
                UploadVideoDAL objUploadVideo_DAL = new UploadVideoDAL();
                return objUploadVideo_DAL.InsertVideo(objUploadVideoSchema);

            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
            }
        }

        public Int64 InsertVideoGallery(UploadVideoSchema objUploadVideoSchema)
        {
            try
            {
                UploadVideoDAL objUploadVideo_DAL = new UploadVideoDAL();
                return objUploadVideo_DAL.InsertVideoGallery(objUploadVideoSchema);

            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
            }
        }

        public Int64 InsertVideoRecord(UploadVideoSchema objUploadVideoSchema)
        {
            try
            {
                UploadVideoDAL objUploadVideo_DAL = new UploadVideoDAL();
                return objUploadVideo_DAL.InsertVideoRecord(objUploadVideoSchema);

            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
            }
        }
        #endregion

        #region Delete
        public Int64 DeleteVideo(String VideoID)
        {
            try
            {
                UploadVideoDAL objUploadVideo_DAL = new UploadVideoDAL();
                return objUploadVideo_DAL.DeleteVideo(VideoID);
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
            }
        }

        public Int64 DeleteVideoRecord(UploadVideoSchema objUploadVideoSchema)
        {
            try
            {
                UploadVideoDAL objUploadVideo_DAL = new UploadVideoDAL();
                return objUploadVideo_DAL.DeleteVideoRecord(objUploadVideoSchema);
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
            }
        }
        #endregion

        #region Fetch
        public DataTable FetchVideo()
        {
            try
            {
                UploadVideoDAL objUploadVideo_DAL = new UploadVideoDAL();
                DataTable dt = new DataTable();
                dt = objUploadVideo_DAL.FetchVideo();
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
            }
        }

        public DataTable FetchVideoList()
        {
            try
            {
                UploadVideoDAL objUploadVideo_DAL = new UploadVideoDAL();
                DataTable dt = new DataTable();
                dt = objUploadVideo_DAL.FetchVideoList();
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
            }
        }

        public DataTable FetchVideoListByLangid(int langid)
        {
            try
            {
                UploadVideoDAL objUploadVideo_DAL = new UploadVideoDAL();
                DataTable dt = new DataTable();
                dt = objUploadVideo_DAL.FetchVideoListByLangid(langid);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
            }
        }

        public DataTable FetchAudioList()
        {
            try
            {
                UploadVideoDAL objUploadVideo_DAL = new UploadVideoDAL();
                DataTable dt = new DataTable();
                dt = objUploadVideo_DAL.FetchAudioList();
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
            }
        }

        public DataTable FetchAudioListByLangid(int langid)
        {
            try
            {
                UploadVideoDAL objUploadVideo_DAL = new UploadVideoDAL();
                DataTable dt = new DataTable();
                dt = objUploadVideo_DAL.FetchAudioListByLangid(langid);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
            }
        }

        public DataTable FetchVideoPath(String VideoID)
        {
            try
            {
                UploadVideoDAL objUploadVideo_DAL = new UploadVideoDAL();
                DataTable dt = new DataTable();
                dt = objUploadVideo_DAL.FetchVideoPath(VideoID);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
            }
        }

        public DataTable FetchVideoByLangId(int langid)
        {
            try
            {
                UploadVideoDAL objUploadVideo_DAL = new UploadVideoDAL();
                DataTable dt = new DataTable();
                dt = objUploadVideo_DAL.FetchVideoByLangId(langid);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
            }
        }

        public DataTable FillVideoGrid(int Langid, string title, string filetype)
        {
            try
            {
                UploadVideoDAL objUploadVideo_DAL = new UploadVideoDAL();
                DataTable dt = new DataTable();
                dt = objUploadVideo_DAL.FillVideoGrid(Langid, title, filetype);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
            }
        }

        public DataTable FillVideoGridpager(int Langid, string title, string filetype, int PageSize, int PageIndex)
        {
            try
            {
                UploadVideoDAL objUploadVideo_DAL = new UploadVideoDAL();
                DataTable dt = new DataTable();
                dt = objUploadVideo_DAL.FillVideoGridpager(Langid, title, filetype, PageSize, PageIndex);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
            }
        }

        public DataTable FetchRecord(string id)
        {
            try
            {
                UploadVideoDAL objUploadVideo_DAL = new UploadVideoDAL();
                DataTable dt = new DataTable();
                dt = objUploadVideo_DAL.FetchRecord(id);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
            }
        }

        public DataTable ViewVideoList(UploadVideoSchema UploadVideo_Schema)
        {
            try
            {
                UploadVideoDAL objUploadVideo_DAL = new UploadVideoDAL();
                DataTable dt = new DataTable();
                dt = objUploadVideo_DAL.ViewVideoList(UploadVideo_Schema);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
            }
        }

        public DataTable ViewAudioList(UploadVideoSchema UploadVideo_Schema)
        {
            try
            {
                UploadVideoDAL objUploadVideo_DAL = new UploadVideoDAL();
                DataTable dt = new DataTable();
                dt = objUploadVideo_DAL.ViewAudioList(UploadVideo_Schema);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion

    }
}
