using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Schema;
using Helper;


namespace DAL
{
    public class UploadFileDL
    {
        DataSet ds;
        SqlConnection conn;
        String sqlQuery;
        int returnVal = 0;

        public int SaveUploadFileDL(UploadFileSchema objUploadFileSchema)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                SqlParameter[] cmdParameter = new SqlParameter[17];

                cmdParameter[0] = new SqlParameter("@fileCategory", SqlDbType.Int);
                cmdParameter[0].Value = objUploadFileSchema.FileCategory;
                cmdParameter[1] = new SqlParameter("@fileTitle", SqlDbType.VarChar);
                cmdParameter[1].Value = objUploadFileSchema.FileTitle;
                cmdParameter[2] = new SqlParameter("@fileTitleLL", SqlDbType.NVarChar);
                cmdParameter[2].Value = objUploadFileSchema.FileTitleLL;
                cmdParameter[3] = new SqlParameter("@fileDetail", SqlDbType.VarChar);
                cmdParameter[3].Value = objUploadFileSchema.FileDetail;
                cmdParameter[4] = new SqlParameter("@fileDetailLL", SqlDbType.NVarChar);
                cmdParameter[4].Value = objUploadFileSchema.FileDetailLL;
                cmdParameter[5] = new SqlParameter("@imageContent", SqlDbType.Image);
                cmdParameter[5].Value = objUploadFileSchema.ImageContent;
                cmdParameter[6] = new SqlParameter("@imageType", SqlDbType.VarChar);
                cmdParameter[6].Value = objUploadFileSchema.ImageType;
                cmdParameter[7] = new SqlParameter("@fileSize", SqlDbType.VarChar);
                cmdParameter[7].Value = objUploadFileSchema.FileSize;
                cmdParameter[8] = new SqlParameter("@isActive", SqlDbType.Bit);
                cmdParameter[8].Value = objUploadFileSchema.IsActive;
                cmdParameter[9] = new SqlParameter("@sequenceNo", SqlDbType.Int);
                cmdParameter[9].Value = objUploadFileSchema.SequenceNo;
                cmdParameter[10] = new SqlParameter("@ipAddress", SqlDbType.VarChar);
                cmdParameter[10].Value = objUploadFileSchema.IpAddress;
                cmdParameter[11] = new SqlParameter("@CreatedBy", SqlDbType.VarChar);
                cmdParameter[11].Value = objUploadFileSchema.CreatedBy;
                cmdParameter[12] = new SqlParameter("@createdDate", SqlDbType.Date);
                cmdParameter[12].Value = objUploadFileSchema.CreatedDate;
                cmdParameter[13] = new SqlParameter("@updatedDate", SqlDbType.Date);
                cmdParameter[13].Value = objUploadFileSchema.UpdatedDate;
                cmdParameter[14] = new SqlParameter("@Flag", SqlDbType.VarChar);
                cmdParameter[14].Value = "Insert";

                //Added By K.P. on 23.05.2018
                cmdParameter[15] = new SqlParameter("@FileDetailUL", SqlDbType.NVarChar);
                cmdParameter[15].Value = objUploadFileSchema.FileDetailUL;
                cmdParameter[16] = new SqlParameter("@FileTitleUL", SqlDbType.NVarChar);
                cmdParameter[16].Value = objUploadFileSchema.FileTitleUL;


                returnVal = SQLHelper.ExecuteNonQuery(conn, null, CommandType.StoredProcedure, "Sp_UploadFile", cmdParameter);
                return returnVal;
            }
            catch (Exception ex) { return returnVal; }
            finally
            { SQLHelper.CloseConnection(conn); }
        }

        public DataSet ShowUploadFileDL(UploadFileSchema objUploadFileSchema)
        {
            DataSet ds = new DataSet();
            try
            {
                conn = SQLHelper.OpenConnection();
                SqlParameter[] cmdParameter = new SqlParameter[2];
                cmdParameter[0] = new SqlParameter("@FileCategory", SqlDbType.Int);
                cmdParameter[0].Value = objUploadFileSchema.FileCategory;
                cmdParameter[1] = new SqlParameter("@Flag", SqlDbType.VarChar);
                cmdParameter[1].Value = "Select";
                return ds = SQLHelper.ExecuteDataset(conn, null, CommandType.StoredProcedure, "Sp_UploadFile", cmdParameter);
            }
            catch (Exception ex) { throw ex; }
            finally { SQLHelper.CloseConnection(conn); }
        }

        public int DeleteFileDL(UploadFileSchema objUploadFileSchema)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                SqlParameter[] cmdParameter = new SqlParameter[1];
                cmdParameter[0] = new SqlParameter("@RowId", SqlDbType.Int);
                cmdParameter[0].Value = objUploadFileSchema.RowId;
                return returnVal = SQLHelper.ExecuteNonQuery(conn, null, CommandType.StoredProcedure, "Usp_DeleteFileUpload", cmdParameter);
            }
            catch (Exception ex) { throw ex; }
        }

        public DataSet ShowFileDetailsdDL(UploadFileSchema objUploadFileSchema)
        {
            ds = new DataSet();
            try
            {
                conn = SQLHelper.OpenConnection();
                SqlParameter[] cmdParameter = new SqlParameter[1];
                cmdParameter[0] = new SqlParameter("@RowID", SqlDbType.Int);
                cmdParameter[0].Value = objUploadFileSchema.RowId;
                //Added By K.P
                return ds = SQLHelper.ExecuteDataset(conn, null, CommandType.StoredProcedure, "Usp_GetUploadFile", cmdParameter);
            }
            catch (Exception ex) { throw ex; }
            finally { SQLHelper.CloseConnection(conn); }
        }

        //public int UpdateUploadFileDL(UploadFileSchema objUploadFileSchema)
        //{
        //    try
        //    {
        //        conn = SQLHelper.OpenConnection();

        //        SqlParameter[] cmdParameter = new SqlParameter[15];


        //        cmdParameter[0] = new SqlParameter("@fileTitle", SqlDbType.VarChar);
        //        cmdParameter[0].Value = objUploadFileSchema.FileTitle;
        //        cmdParameter[1] = new SqlParameter("@fileTitleLL", SqlDbType.NVarChar);
        //        cmdParameter[1].Value = objUploadFileSchema.FileTitleLL;
        //        cmdParameter[2] = new SqlParameter("@fileDetail", SqlDbType.VarChar);
        //        cmdParameter[2].Value = objUploadFileSchema.FileDetail;
        //        cmdParameter[3] = new SqlParameter("@fileDetailLL", SqlDbType.NVarChar);
        //        cmdParameter[3].Value = objUploadFileSchema.FileDetailLL;
        //        cmdParameter[4] = new SqlParameter("@imageContent", SqlDbType.Image);
        //        cmdParameter[4].Value = objUploadFileSchema.ImageContent;
        //        cmdParameter[5] = new SqlParameter("@imageType", SqlDbType.VarChar);
        //        cmdParameter[5].Value = objUploadFileSchema.ImageType;
        //        cmdParameter[6] = new SqlParameter("@fileSize", SqlDbType.VarChar);
        //        cmdParameter[6].Value = objUploadFileSchema.FileSize;
        //        cmdParameter[7] = new SqlParameter("@isActive", SqlDbType.Bit);
        //        cmdParameter[7].Value = objUploadFileSchema.IsActive;
        //        cmdParameter[8] = new SqlParameter("@sequenceNo", SqlDbType.Int);
        //        cmdParameter[8].Value = objUploadFileSchema.SequenceNo;
        //        cmdParameter[9] = new SqlParameter("@ipAddress", SqlDbType.VarChar);
        //        cmdParameter[9].Value = objUploadFileSchema.IpAddress;
        //        cmdParameter[10] = new SqlParameter("@updatedDate", SqlDbType.Date);
        //        cmdParameter[10].Value = objUploadFileSchema.UpdatedDate;
        //        cmdParameter[11] = new SqlParameter("@RowId", SqlDbType.Int);
        //        cmdParameter[11].Value = objUploadFileSchema.RowId;
        //        cmdParameter[12] = new SqlParameter("@Flag", SqlDbType.VarChar);
        //        cmdParameter[12].Value = "Update";
        //        cmdParameter[13] = new SqlParameter("@FileDetailUL", SqlDbType.VarChar);
        //        cmdParameter[13].Value = objUploadFileSchema.FileDetailUL;
        //        cmdParameter[14] = new SqlParameter("@FileTitleUL", SqlDbType.VarChar);
        //        cmdParameter[14].Value = objUploadFileSchema.FileTitleUL;

        //        returnVal = SQLHelper.ExecuteNonQuery(conn, null, CommandType.StoredProcedure, "Sp_UploadFile", cmdParameter);
        //        return returnVal;
        //    }
        //    catch (Exception ex) { return returnVal; }
        //    finally
        //    { SQLHelper.CloseConnection(conn); }
        //}

        public int UpdateUploadFileDL(UploadFileSchema objUploadFileSchema)
        {
            try
            {
                using (SqlConnection objConn = SQLHelper.OpenConnection())
                {


                    SqlParameter imageParameter = new SqlParameter("@imageContent", SqlDbType.Image);
                    imageParameter.Value = objUploadFileSchema.ImageContent;

                    var param = new SqlParameter[]
                    {
                       new SqlParameter("@FileTitle",objUploadFileSchema.FileTitle == null ? (object)DBNull.Value : objUploadFileSchema.FileTitle),
                       new SqlParameter("@fileTitleLL",objUploadFileSchema.FileTitleLL == null ? (object)DBNull.Value : objUploadFileSchema.FileTitleLL),
                       new SqlParameter("@fileDetail",objUploadFileSchema.FileDetail == null ? (object)DBNull.Value : objUploadFileSchema.FileDetail),
                       new SqlParameter("@fileDetailLL",objUploadFileSchema.FileDetailLL == null ? (object)DBNull.Value : objUploadFileSchema.FileDetailLL),
                       new SqlParameter("@imageContent", imageParameter.Value),
                       new SqlParameter("@imageType",objUploadFileSchema.ImageType == null ? (object)DBNull.Value : objUploadFileSchema.ImageType),
                       new SqlParameter("@fileSize",objUploadFileSchema.FileSize == null ? (object)DBNull.Value : objUploadFileSchema.FileSize),
                       new SqlParameter("@isActive",objUploadFileSchema.IsActive == false ? Convert.ToBoolean(0) : objUploadFileSchema.IsActive),
                       new SqlParameter("@sequenceNo",objUploadFileSchema.SequenceNo == 0 ? 0 : objUploadFileSchema.SequenceNo),
                       new SqlParameter("@ipAddress",objUploadFileSchema.IpAddress == null ? (object)DBNull.Value : objUploadFileSchema.IpAddress),
                       new SqlParameter("@updatedDate",objUploadFileSchema.UpdatedDate == null ? (object)DBNull.Value : objUploadFileSchema.UpdatedDate),
                       new SqlParameter("@RowId",objUploadFileSchema.RowId == 0 ? 0 : objUploadFileSchema.RowId),
                       new SqlParameter("@Flag","Update"),
                       new SqlParameter("@FileDetailUL",objUploadFileSchema.FileDetailUL == null ? (object)DBNull.Value : objUploadFileSchema.FileDetailUL),
                       new SqlParameter("@FileTitleUL",objUploadFileSchema.FileTitleUL == null ? (object)DBNull.Value : objUploadFileSchema.FileTitleUL)
                    };

                    int result = SQLHelper.ExecuteNonQuery(objConn, null, CommandType.StoredProcedure, "Sp_UploadFile", param);
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




        public DataSet BindCategory()
        {
            DataSet ds = new DataSet();
            try
            {
                conn = SQLHelper.OpenConnection();                
                return ds = SQLHelper.ExecuteDataset(conn, null, CommandType.StoredProcedure, "Usp_BindCategory", null);
            }
            catch (Exception ex) { throw ex; }
            finally { SQLHelper.CloseConnection(conn); }
        }

    }
}
