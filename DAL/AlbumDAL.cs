using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;

namespace DAL
{
    public class AlbumDAL
    {
        public DataSet GetPressNewsAlbumdetails(AlbumSchema objAlbumSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", SqlDbType.VarChar);
                param[0].Value = objAlbumSchema.Type;
                param[1] = new SqlParameter("@AlbumName ", SqlDbType.VarChar);
                param[1].Value = objAlbumSchema.AlbumName;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_GetAlbumForPressNews", param))
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }

        public int DMLAlbumForPressNews(AlbumSchema objAlbumSchema)
        {
            try
            {

                using (SqlConnection objConn = SQLHelper.OpenConnection())
                {
                    using (SqlTransaction objTran = objConn.BeginTransaction())
                    {
                        try
                        {
                            var param = new SqlParameter[]
                            {
                             new SqlParameter("@ActionType",objAlbumSchema.Actiontype == null ? (object)DBNull.Value : objAlbumSchema.Actiontype),
                             new SqlParameter("@PressNewsAlbumID",objAlbumSchema.PressNewsAlbumID == 0 ? 0 : objAlbumSchema.PressNewsAlbumID ),
                             new SqlParameter("@AlbumName",objAlbumSchema.AlbumName == null ? (object)DBNull.Value : objAlbumSchema.AlbumName),
                             new SqlParameter("@ChkStatus",objAlbumSchema.ChkStatus == false ? Convert.ToBoolean(0) : objAlbumSchema.ChkStatus),                         
                        };
                            int result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "Usp_DMLAlbumForPressNews", param);
                            if (result == 1)
                            {
                                objTran.Commit();
                                return result;
                            }
                            else
                            {
                                objTran.Rollback();
                                return 0;
                            }
                        }

                        catch (Exception ex)
                        {
                            objTran.Rollback();
                            return 0;
                        }
                    }

                }
            }
            catch (Exception ee)
            {
                return 0;
            }
            finally
            {

            }
        }


        public DataSet GetVideos(AlbumSchema objAlbumSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Types", SqlDbType.VarChar);
                param[0].Value = objAlbumSchema.Type;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_AlbumForVideo", param))
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }


        public int SaveVideo(AlbumSchema objAlbumSchema)
        {
            try
            {

                using (SqlConnection objConn = SQLHelper.OpenConnection())
                {
                    using (SqlTransaction objTran = objConn.BeginTransaction())
                    {
                        try
                        {
                            var param = new SqlParameter[]
                            {
                             new SqlParameter("@VideoName",objAlbumSchema.VideoName == null ? (object)DBNull.Value : objAlbumSchema.VideoName),
                             new SqlParameter("@VideoNameLL",objAlbumSchema.VideoNameLL == null ? (object)DBNull.Value : objAlbumSchema.VideoNameLL),
                             new SqlParameter("@VideoNameUL",objAlbumSchema.VideoNameUL == null ? (object)DBNull.Value : objAlbumSchema.VideoNameUL),
                             new SqlParameter("@VideoPath",objAlbumSchema.VideoPath == null ? (object)DBNull.Value : objAlbumSchema.VideoPath),
                             new SqlParameter("@Description",objAlbumSchema.Description == null ? (object)DBNull.Value : objAlbumSchema.Description),
                             new SqlParameter("@DescriptionLL",objAlbumSchema.DescriptionLL == null ? (object)DBNull.Value : objAlbumSchema.DescriptionLL),
                             new SqlParameter("@DescriptionUL",objAlbumSchema.DescriptionUL == null ? (object)DBNull.Value : objAlbumSchema.DescriptionUL),
                             new SqlParameter("@Types",objAlbumSchema.Type == null ? (object)DBNull.Value : objAlbumSchema.Type),
                             new SqlParameter("@CreatedBy",objAlbumSchema.CreatedBy == null ? (object)DBNull.Value : objAlbumSchema.CreatedBy),
                             new SqlParameter("@IPAddress",objAlbumSchema.IPAddress == null ? (object)DBNull.Value : objAlbumSchema.IPAddress),
                             new SqlParameter("@ImagePath",objAlbumSchema.ImagePath == null ? (object)DBNull.Value : objAlbumSchema.ImagePath),
                             new SqlParameter("@Flag",objAlbumSchema.Flag == null ? (object)DBNull.Value : objAlbumSchema.Flag)
                        };
                            int result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "sp_InsertVideo", param);
                            if (result == 1)
                            {
                                objTran.Commit();
                                return result;
                            }
                            else
                            {
                                objTran.Rollback();
                                return 0;
                            }
                        }

                        catch (Exception ex)
                        {
                            objTran.Rollback();
                            return 0;
                        }
                    }

                }
            }
            catch (Exception ee)
            {
                return 0;
            }
            finally
            {

            }
        }


        public int DMLAlbhumForVideo(AlbumSchema objAlbumSchema)
        {
            try
            {

                using (SqlConnection objConn = SQLHelper.OpenConnection())
                {
                    using (SqlTransaction objTran = objConn.BeginTransaction())
                    {
                        try
                        {
                            var param = new SqlParameter[]
                            {
                             new SqlParameter("@VideoName",objAlbumSchema.VideoName == null ? (object)DBNull.Value : objAlbumSchema.VideoName),
                             new SqlParameter("@VideoNameLL",objAlbumSchema.VideoNameLL == null ? (object)DBNull.Value : objAlbumSchema.VideoNameLL),
                             new SqlParameter("@VideoPath",objAlbumSchema.VideoPath == null ? (object)DBNull.Value : objAlbumSchema.VideoPath),
                             new SqlParameter("@ActionType",objAlbumSchema.Actiontype == null ? (object)DBNull.Value : objAlbumSchema.Actiontype),
                             new SqlParameter("@VideoID",objAlbumSchema.VideoID == 0 ? 0 : objAlbumSchema.VideoID ),

                        };
                            int result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "Usp_DMLAlbhumForVideo", param);
                            if (result == 1)
                            {
                                objTran.Commit();
                                return result;
                            }
                            else
                            {
                                objTran.Rollback();
                                return 0;
                            }
                        }

                        catch (Exception ex)
                        {
                            objTran.Rollback();
                            return 0;
                        }
                    }

                }
            }
            catch (Exception ee)
            {
                return 0;
            }
            finally
            {

            }
        }


        public DataSet GetAlbumDetails(AlbumSchema objAlbumSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {

                var param = new SqlParameter[]
                  {
                       new SqlParameter("@ActionType",objAlbumSchema.Actiontype == null ? (object)DBNull.Value : objAlbumSchema.Actiontype),
                       new SqlParameter("@AlbumID",Convert.ToInt32(objAlbumSchema.AlbumID) == 0 ? 0 : Convert.ToInt32(objAlbumSchema.AlbumID)),
                       new SqlParameter("@PhotoSubAlbumID",objAlbumSchema.PhotoSubAlbumID == 0 ? 0 : objAlbumSchema.PhotoSubAlbumID),
                       new SqlParameter("@Name",objAlbumSchema.Name == null ? (object)DBNull.Value : objAlbumSchema.Name)          
                  };

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_GetAlbumDetails", param))
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }

        public int DMLAlbumDetails(AlbumSchema objAlbumSchema)
        {
            try
            {

                using (SqlConnection objConn = SQLHelper.OpenConnection())
                {
                    using (SqlTransaction objTran = objConn.BeginTransaction())
                    {
                        try
                        {
                            var param = new SqlParameter[]
                            {
                              new SqlParameter("@ActionType",objAlbumSchema.Actiontype == null ? (object)DBNull.Value : objAlbumSchema.Actiontype),
                              new SqlParameter("@PhotoSubAlbumID",objAlbumSchema.PhotoSubAlbumID == 0 ? 0 : objAlbumSchema.PhotoSubAlbumID ),
                              new SqlParameter("@FileName",objAlbumSchema.Filename == null ? (object)DBNull.Value : objAlbumSchema.Filename),
                              new SqlParameter("@Name",objAlbumSchema.Name == null ? (object)DBNull.Value : objAlbumSchema.Name),
                              new SqlParameter("@PhotoID",objAlbumSchema.PhotoID == 0 ? 0 : objAlbumSchema.PhotoID )
                        };
                            int result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "Usp_DMLAlbumDetails", param);
                            if (result == 1)
                            {
                                objTran.Commit();
                                return result;
                            }
                            else
                            {
                                objTran.Rollback();
                                return 0;
                            }
                        }

                        catch (Exception ex)
                        {
                            objTran.Rollback();
                            return 0;
                        }
                    }

                }
            }
            catch (Exception ee)
            {
                return 0;
            }
            finally
            {

            }
        }

        public DataSet GetViewAlbum(AlbumSchema objAlbumSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@ActionType", SqlDbType.VarChar);
                param[0].Value = objAlbumSchema.Actiontype;
                param[1] = new SqlParameter("@PhotoType", SqlDbType.VarChar);
                param[1].Value = objAlbumSchema.PhotoType;
                param[2] = new SqlParameter("@PhotoAlbumID", SqlDbType.Int);
                param[2].Value = objAlbumSchema.PhotoAlbumID;
                param[3] = new SqlParameter("@PhotoSubAlbumID", SqlDbType.Int);
                param[3].Value = objAlbumSchema.PhotoSubAlbumID;
               
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_GetViewAlbum", param))
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }

        public int DMLViewAlbum(AlbumSchema objAlbumSchema)
        {
            try
            {

                using (SqlConnection objConn = SQLHelper.OpenConnection())
                {
                    using (SqlTransaction objTran = objConn.BeginTransaction())
                    {
                        try
                        {
                            var param = new SqlParameter[]
                            {
                              new SqlParameter("@ActionType",objAlbumSchema.Actiontype == null ? (object)DBNull.Value : objAlbumSchema.Actiontype),
                              new SqlParameter("@PhotoType",objAlbumSchema.PhotoType == null ? (object)DBNull.Value : objAlbumSchema.PhotoType),
                              new SqlParameter("@PhotoAlbumID",objAlbumSchema.PhotoAlbumID == 0 ? 0 : objAlbumSchema.PhotoAlbumID ),
                              new SqlParameter("@PhotoSubAlbumID",objAlbumSchema.PhotoSubAlbumID == 0 ? 0 : objAlbumSchema.PhotoSubAlbumID ),
                              new SqlParameter("@FileName",objAlbumSchema.Filename == null ? (object)DBNull.Value : objAlbumSchema.Filename),
                              new SqlParameter("@Name",objAlbumSchema.Name == null ? (object)DBNull.Value : objAlbumSchema.Name)
                        };
                            int result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "Usp_DMLViewAlbum", param);
                            if (result == 1)
                            {
                                objTran.Commit();
                                return result;
                            }
                            else
                            {
                                objTran.Rollback();
                                return 0;
                            }
                        }

                        catch (Exception ex)
                        {
                            objTran.Rollback();
                            return 0;
                        }
                    }

                }
            }
            catch (Exception ee)
            {
                return 0;
            }
            finally
            {

            }
        }


        public DataSet GetVideosById(AlbumSchema objAlbumSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Types", SqlDbType.VarChar);
                param[0].Value = objAlbumSchema.TypeId;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetVideoByTypes", param))
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }

        public DataSet GetAllVideosById(AlbumSchema objAlbumSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Types", SqlDbType.VarChar);
                param[0].Value = objAlbumSchema.TypeId;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetAllVideoByTypes", param))
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }



    }
}
