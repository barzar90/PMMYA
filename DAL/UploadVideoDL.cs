using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Helper;
using Schema;

namespace DAL
{
    public class UploadVideoDL
    {
        DataSet ds;
        SqlConnection conn;
        SqlTransaction objtran;
        String sqlQuery;
        Int64 intCount;
        String ID;

        public DataTable ViewVideoList(UploadVideoSchema UploadVideo_Schema)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                SqlParameter[] cmdParameter = new SqlParameter[1];
                cmdParameter[0] = new SqlParameter("@Keyword", SqlDbType.NVarChar);
                cmdParameter[0].Value = UploadVideo_Schema.Keyword;

                sqlQuery = "Select VideoID, VideoName, VideoPath, '../../Site/Upload/Video/' + ImagePath as VideoImage,Description as VideoDesc from Video where IsActive=1";
                //sqlQuery += "where((VideoName like '%' + @Keyword + '%') or (Descriptions like '%' + @Keyword + '%') or @Keyword='') ";
                //sqlQuery += " order by VideoName";
                ds = SQLHelper.ExecuteDataset(conn, null, CommandType.Text, sqlQuery, cmdParameter);
                return ds.Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ds = null;
                SQLHelper.CloseConnection(conn);
            }
        }

        public DataTable FetchVideoPath(String VideoID)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                SqlParameter[] cmdParameter = new SqlParameter[1];
                cmdParameter[0] = new SqlParameter("@VideoID", SqlDbType.BigInt);
                cmdParameter[0].Value = VideoID;

                sqlQuery = "Select VideoPath from Video where VideoID =@VideoID";
                ds = SQLHelper.ExecuteDataset(conn, null, CommandType.Text, sqlQuery, cmdParameter);
                return ds.Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ds = null;
                SQLHelper.CloseConnection(conn);
            }
        }


    }
}
