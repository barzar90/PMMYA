using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Schema;
using Helper;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UploadVideoDAL
    {
        DataSet ds;
        SqlConnection conn;
        SqlTransaction objtran;
        String sqlQuery;
        Int64 intCount;
        String ID;

        #region Insert
        public Int64 InsertVideo(UploadVideoSchema objUploadVideoSchema)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                objtran = conn.BeginTransaction();

                SqlParameter[] cmdParameters = new SqlParameter[8];
                cmdParameters[0] = new SqlParameter("@VideoID", SqlDbType.BigInt);
                if (objUploadVideoSchema.VideoID == null)
                {
                    cmdParameters[0].Value = DBNull.Value;
                }
                else
                {
                    cmdParameters[0].Value = objUploadVideoSchema.VideoID;
                }

                cmdParameters[1] = new SqlParameter("@VideoName", SqlDbType.NVarChar);
                cmdParameters[1].Value = objUploadVideoSchema.VideoName;
                cmdParameters[2] = new SqlParameter("@VideoPath", SqlDbType.NVarChar);
                cmdParameters[2].Value = objUploadVideoSchema.VideoPath;
                cmdParameters[3] = new SqlParameter("@ImagePath", SqlDbType.NVarChar);
                cmdParameters[3].Value = objUploadVideoSchema.ImagePath;
                cmdParameters[4] = new SqlParameter("@Description", SqlDbType.NVarChar);
                cmdParameters[4].Value = objUploadVideoSchema.Description;
                cmdParameters[5] = new SqlParameter("@Type", SqlDbType.VarChar);
                cmdParameters[5].Value = objUploadVideoSchema.Type;
                cmdParameters[6] = new SqlParameter("@Flag", SqlDbType.VarChar, 10);
                cmdParameters[6].Value = objUploadVideoSchema.Flag;
                cmdParameters[7] = new SqlParameter("@Langid", SqlDbType.Int);
                cmdParameters[7].Value = objUploadVideoSchema.langid;

                intCount = SQLHelper.ExecuteNonQuery(conn, objtran, CommandType.StoredProcedure, "spVideoAddUpdate", cmdParameters);

                objtran.Commit();
                return intCount;
            }
            catch (Exception)
            {
                objtran.Rollback();
                return 0;
            }
            finally
            {
                SQLHelper.CloseConnection(conn);
                intCount = 0;
            }
        }

        public Int64 InsertVideoRecord(UploadVideoSchema objUploadVideoSchema)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                objtran = conn.BeginTransaction();

                SqlParameter[] cmdParameters = new SqlParameter[10];
                cmdParameters[0] = new SqlParameter("@VideoID", SqlDbType.BigInt);
                if (objUploadVideoSchema.VideoID == null)
                {
                    cmdParameters[0].Value = DBNull.Value;
                }
                else
                {
                    cmdParameters[0].Value = objUploadVideoSchema.VideoID;
                }

                cmdParameters[1] = new SqlParameter("@VideoName", SqlDbType.NVarChar);
                cmdParameters[1].Value = objUploadVideoSchema.VideoName;
                cmdParameters[2] = new SqlParameter("@VideoPath", SqlDbType.NVarChar);
                cmdParameters[2].Value = objUploadVideoSchema.VideoPath;
                cmdParameters[3] = new SqlParameter("@ImagePath", SqlDbType.NVarChar);
                cmdParameters[3].Value = objUploadVideoSchema.ImagePath;
                cmdParameters[4] = new SqlParameter("@Description", SqlDbType.NVarChar);
                cmdParameters[4].Value = objUploadVideoSchema.Description;
                cmdParameters[5] = new SqlParameter("@Type", SqlDbType.VarChar);
                cmdParameters[5].Value = objUploadVideoSchema.Type;
                cmdParameters[6] = new SqlParameter("@Flag", SqlDbType.VarChar, 10);
                cmdParameters[6].Value = objUploadVideoSchema.Flag;
                cmdParameters[7] = new SqlParameter("@Langid", SqlDbType.Int);
                cmdParameters[7].Value = objUploadVideoSchema.langid;
                cmdParameters[8] = new SqlParameter("@CreatedBy", SqlDbType.UniqueIdentifier);
                cmdParameters[8].Value = objUploadVideoSchema.CreatedBy;
                cmdParameters[9] = new SqlParameter("@IPAddress", SqlDbType.NVarChar);
                cmdParameters[9].Value = objUploadVideoSchema.IPAddress;

                intCount = SQLHelper.ExecuteNonQuery(conn, objtran, CommandType.StoredProcedure, "spVideoGalleryAdd", cmdParameters);

                objtran.Commit();
                return intCount;
            }
            catch (Exception)
            {
                objtran.Rollback();
                return 0;
            }
            finally
            {
                SQLHelper.CloseConnection(conn);
                intCount = 0;
            }
        }

        public Int64 InsertVideoGallery(UploadVideoSchema objUploadVideoSchema)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                objtran = conn.BeginTransaction();

                SqlParameter[] cmdParameters = new SqlParameter[10];

                cmdParameters[0] = new SqlParameter("@VideoName", SqlDbType.NVarChar);
                cmdParameters[0].Value = objUploadVideoSchema.VideoName;
                cmdParameters[1] = new SqlParameter("@VideoName_LL", SqlDbType.NVarChar);
                cmdParameters[1].Value = objUploadVideoSchema.VideoName_LL;
                cmdParameters[2] = new SqlParameter("@VideoPath", SqlDbType.NVarChar);
                cmdParameters[2].Value = objUploadVideoSchema.VideoPath;
                //cmdParameters[3] = new SqlParameter("@VideoPath_LL", SqlDbType.NVarChar);
                //cmdParameters[3].Value = objUploadVideoSchema.VideoPath_LL;
                cmdParameters[3] = new SqlParameter("@ImagePath", SqlDbType.NVarChar);
                cmdParameters[3].Value = objUploadVideoSchema.ImagePath;
                //cmdParameters[5] = new SqlParameter("@ImagePath_LL", SqlDbType.NVarChar);
                //cmdParameters[5].Value = objUploadVideoSchema.ImagePath_LL;
                cmdParameters[4] = new SqlParameter("@Description", SqlDbType.NVarChar);
                cmdParameters[4].Value = objUploadVideoSchema.Description;
                cmdParameters[5] = new SqlParameter("@Description_LL", SqlDbType.NVarChar);
                cmdParameters[5].Value = objUploadVideoSchema.Description_LL;
                cmdParameters[6] = new SqlParameter("@Type", SqlDbType.VarChar);
                cmdParameters[6].Value = objUploadVideoSchema.Type;
                cmdParameters[7] = new SqlParameter("@Flag", SqlDbType.VarChar, 10);
                cmdParameters[7].Value = objUploadVideoSchema.Flag;
                cmdParameters[8] = new SqlParameter("@CreatedBy", SqlDbType.UniqueIdentifier);
                cmdParameters[8].Value = objUploadVideoSchema.CreatedBy;
                cmdParameters[9] = new SqlParameter("@IPAddress", SqlDbType.NVarChar);
                cmdParameters[9].Value = objUploadVideoSchema.IPAddress;

                intCount = SQLHelper.ExecuteNonQuery(conn, objtran, CommandType.StoredProcedure, "spVideoInsert", cmdParameters);

                objtran.Commit();
                return intCount;
            }
            catch (Exception)
            {
                objtran.Rollback();
                return 0;
            }
            finally
            {
                SQLHelper.CloseConnection(conn);
                intCount = 0;
            }
        }
        #endregion

        #region Delete
        public Int64 DeleteVideo(String VideoID)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                objtran = conn.BeginTransaction();

                SqlParameter[] cmdParameters = new SqlParameter[1];
                cmdParameters[0] = new SqlParameter("@VideoID", SqlDbType.BigInt);
                cmdParameters[0].Value = VideoID;
                intCount = SQLHelper.ExecuteNonQuery(conn, objtran, CommandType.Text, "Delete from Video where VideoID=@VideoID", cmdParameters);
                objtran.Commit();
                return intCount;
            }
            catch (Exception)
            {
                objtran.Rollback();
                return 0;
            }
            finally
            {
                SQLHelper.CloseConnection(conn);
                intCount = 0;
            }
        }

        public Int64 DeleteVideoRecord(UploadVideoSchema objUploadVideoSchema)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                objtran = conn.BeginTransaction();

                SqlParameter[] cmdParameters = new SqlParameter[3];
                cmdParameters[0] = new SqlParameter("@VideoID", SqlDbType.BigInt);
                cmdParameters[0].Value = objUploadVideoSchema.VideoID;
                cmdParameters[1] = new SqlParameter("@CreatedBy", SqlDbType.UniqueIdentifier);
                cmdParameters[1].Value = objUploadVideoSchema.CreatedBy;
                cmdParameters[2] = new SqlParameter("@IPAddress", SqlDbType.NVarChar);
                cmdParameters[2].Value = objUploadVideoSchema.IPAddress;

                intCount = SQLHelper.ExecuteNonQuery(conn, objtran, CommandType.StoredProcedure, "spDeleteVideo", cmdParameters);
                objtran.Commit();
                return intCount;
            }
            catch (Exception)
            {
                objtran.Rollback();
                return 0;
            }
            finally
            {
                SQLHelper.CloseConnection(conn);
                intCount = 0;
            }
        }
        #endregion

        #region Fetch
        public DataTable FetchVideo()
        {
            try
            {
                conn = SQLHelper.OpenConnection();

                sqlQuery = "Select * from Video order by VideoID desc";
                ds = SQLHelper.ExecuteDataset(conn, null, CommandType.Text, sqlQuery);
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

        public DataTable FetchVideoList()
        {
            try
            {
                conn = SQLHelper.OpenConnection();

                sqlQuery = "Select VideoID, VideoName, VideoPath, '../../Site/Upload/Video/' + ImagePath as VideoImage from Video where Type='Video' order by VideoName";
                ds = SQLHelper.ExecuteDataset(conn, null, CommandType.Text, sqlQuery);
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

        public DataTable FetchVideoListByLangid(int langid)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                SqlParameter[] cmdparameter = new SqlParameter[1];
                cmdparameter[0] = new SqlParameter("@Langid", SqlDbType.Int);
                cmdparameter[0].Value = langid;

                sqlQuery = "Select VideoID, VideoName, VideoPath, '../../Site/Upload/Video/' + ImagePath as VideoImage, Description as VideoDesc from Video where Type='Video' and Langid=@Langid order by VideoName";
                ds = SQLHelper.ExecuteDataset(conn, null, CommandType.Text, sqlQuery, cmdparameter);
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

        public DataTable FetchAudioList()
        {
            try
            {
                conn = SQLHelper.OpenConnection();

                sqlQuery = "Select VideoID, VideoName, VideoPath, '../../Site/Upload/Video/' + ImagePath as VideoImage from Video where Type='Audio' order by VideoName";
                ds = SQLHelper.ExecuteDataset(conn, null, CommandType.Text, sqlQuery);
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

        public DataTable FetchAudioListByLangid(int langid)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                SqlParameter[] cmdparameter = new SqlParameter[1];
                cmdparameter[0] = new SqlParameter("@Langid", SqlDbType.Int);
                cmdparameter[0].Value = langid;

                //sqlQuery = "Select VideoID, VideoName, VideoPath, '../../Site/Upload/Video/' + ImagePath as VideoImage, Description as AudioDesc from Video where Type='Audio' and Langid=@Langid order by VideoName";
                sqlQuery = "Select VideoID, VideoName, VideoPath, Description as AudioDesc from Video where Type='Audio' and Langid=@Langid order by VideoName";
                ds = SQLHelper.ExecuteDataset(conn, null, CommandType.Text, sqlQuery, cmdparameter);
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

        public DataTable FetchVideoByLangId(int langid)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                SqlParameter[] cmdParameter = new SqlParameter[1];
                cmdParameter[0] = new SqlParameter("@Langid", SqlDbType.Int);
                cmdParameter[0].Value = langid;

                sqlQuery = "Select * from Video where langid=@Langid order by VideoID desc";
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

        public DataTable FillVideoGrid(int Langid, string title, string filetype)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                SqlParameter[] cmdParameter = new SqlParameter[3];
                cmdParameter[0] = new SqlParameter("@Langid", SqlDbType.Int);
                cmdParameter[0].Value = Langid;
                cmdParameter[1] = new SqlParameter("@Title", SqlDbType.NVarChar);
                cmdParameter[1].Value = title;
                cmdParameter[2] = new SqlParameter("@FileType", SqlDbType.VarChar);
                cmdParameter[2].Value = filetype;

                sqlQuery = "Select * from Video where Langid=@Langid and VideoName like '%' + @Title + '%'  and Type like '%' + @FileType + '%' order by LastUpdated desc";
                //sqlQuery = "Select * from Video where Langid=@Langid and VideoName like '%" + title + "%' order by VIdeoName";
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

        public DataTable FillVideoGridpager(int Langid, string title, string filetype, int PageSize, int PageIndex)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                SqlParameter[] cmdParameter = new SqlParameter[5];
                cmdParameter[0] = new SqlParameter("@Langid", SqlDbType.Int);
                cmdParameter[0].Value = Langid;
                cmdParameter[1] = new SqlParameter("@Title", SqlDbType.NVarChar);
                cmdParameter[1].Value = title;
                cmdParameter[2] = new SqlParameter("@FileType", SqlDbType.VarChar);
                cmdParameter[2].Value = filetype;
                cmdParameter[3] = new SqlParameter("@PageSize", SqlDbType.Int);
                cmdParameter[3].Value = PageSize;
                cmdParameter[4] = new SqlParameter("@PageIndex", SqlDbType.Int);
                cmdParameter[4].Value = PageIndex;

                ds = SQLHelper.ExecuteDataset(conn, null, CommandType.StoredProcedure, "spSearchVideo", cmdParameter);
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

        public DataTable FetchRecord(string id)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                SqlParameter[] cmdParameter = new SqlParameter[1];
                cmdParameter[0] = new SqlParameter("@id", SqlDbType.NVarChar);
                cmdParameter[0].Value = id;

                sqlQuery = "Select * from Video where VideoID=@id";
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

        public DataTable ViewVideoList(UploadVideoSchema UploadVideo_Schema)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                SqlParameter[] cmdParameter = new SqlParameter[2];
                cmdParameter[0] = new SqlParameter("@Langid", SqlDbType.Int);
                cmdParameter[0].Value = UploadVideo_Schema.langid;
                cmdParameter[1] = new SqlParameter("@Keyword", SqlDbType.NVarChar);
                cmdParameter[1].Value = UploadVideo_Schema.Keyword;

                sqlQuery = "Select VideoID, VideoName, VideoPath, '../../Site/Upload/Video/' + ImagePath as VideoImage, Description as VideoDesc from Video where Type='Video' and Langid=@Langid ";
                sqlQuery += " and ((VideoName like '%' + @Keyword + '%') or (Description like '%' + @Keyword + '%') or @Keyword='') ";
                sqlQuery += " order by VideoName";
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

        public DataTable ViewAudioList(UploadVideoSchema UploadVideo_Schema)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                SqlParameter[] cmdParameter = new SqlParameter[2];
                cmdParameter[0] = new SqlParameter("@Langid", SqlDbType.Int);
                cmdParameter[0].Value = UploadVideo_Schema.langid;
                cmdParameter[1] = new SqlParameter("@Keyword", SqlDbType.NVarChar);
                cmdParameter[1].Value = UploadVideo_Schema.Keyword;

                sqlQuery = "Select VideoID, VideoName, VideoPath, Description as AudioDesc from Video where Type='Audio' and Langid=@Langid ";
                sqlQuery += " and ((VideoName like '%' + @Keyword + '%') or (Description like '%' + @Keyword + '%') or @Keyword='') ";
                sqlQuery += " order by VideoName";
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
        #endregion
    }
}
