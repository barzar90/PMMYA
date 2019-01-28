using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;


namespace DAL
{
    public class ViewPhotoAlbumDAL
    {
        public DataSet GetPhotoAlbum(ViewPhotoAlbumSchema objviewPhotoAlbumSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                var param = new SqlParameter[]
                           {
                                   new SqlParameter("@PhotoSubAlbumID",objviewPhotoAlbumSchema.PhotoSubAlbumID == 0 ? 0 : objviewPhotoAlbumSchema.PhotoSubAlbumID),
                             };
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_ViewPhoto", param))
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

        public DataSet GetSubAlbum()
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {   
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Sp_DisplaySubAlbums", null))
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

        public DataSet CheckValidAlbum(ViewPhotoAlbumSchema objviewPhotoAlbumSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                var param = new SqlParameter[]
                {
                    new SqlParameter("@ActionType",objviewPhotoAlbumSchema.ActionType == null ? (object)DBNull.Value : objviewPhotoAlbumSchema.ActionType),
                    new SqlParameter("@PhotoAlbumID",objviewPhotoAlbumSchema.Photoalbumid == 0 ? 0 : objviewPhotoAlbumSchema.Photoalbumid),
                    new SqlParameter("@Name",objviewPhotoAlbumSchema.Name == null ? (object)DBNull.Value : objviewPhotoAlbumSchema.Name)

                };
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_CheckValidAlbum", null))
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

        public int DMLAlbumPhoto(ViewPhotoAlbumSchema objviewPhotoAlbumSchema)
        {
            try
            {
                using (SqlConnection objConn = SQLHelper.OpenConnection())
                {
                    var param = new SqlParameter[]
                    {
                       new SqlParameter("@ActionType",objviewPhotoAlbumSchema.ActionType == null ? (object)DBNull.Value : objviewPhotoAlbumSchema.ActionType),
                       new SqlParameter("@AlbumName",objviewPhotoAlbumSchema.Albumname == null ? (object)DBNull.Value : objviewPhotoAlbumSchema.Albumname),
                       new SqlParameter("@FileName",objviewPhotoAlbumSchema.FileName == null ? (object)DBNull.Value : objviewPhotoAlbumSchema.FileName),
                       new SqlParameter("@PhotoAlbumID",objviewPhotoAlbumSchema.Photoalbumid == 0 ? 0 : objviewPhotoAlbumSchema.Photoalbumid)
                    };

                    int result = SQLHelper.ExecuteNonQuery(objConn, null, CommandType.StoredProcedure, "Usp_DMLAlbumPhoto", param);
                    if (result == 1)
                    {
                        return result;
                    }
                    else
                    {
                        return 0;
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


        public DataSet DisplayPhoto()
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_GetAllPhoto", null))
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

        public DataSet DisplayAlbum()
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_displayAlbum", null))
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
