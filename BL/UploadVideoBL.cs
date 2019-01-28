using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Schema;
using DAL;
using System.Data;

namespace BL
{
    public class UploadVideoBL
    {
        public DataTable ViewVideoList(UploadVideoSchema UploadVideo_Schema)
        {
            try
            {
                UploadVideoDL objUploadVideo_DAL = new UploadVideoDL();
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

        public DataTable FetchVideoPath(String VideoID)
        {
            try
            {
                UploadVideoDL objUploadVideo_DAL = new UploadVideoDL();
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
    }
}
