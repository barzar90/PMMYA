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
    public class UploadEventsDL
    {
        DataSet ds;
        SqlConnection conn;
        String sqlQuery;
        int returnVal = 0;


        public int SaveEventsDL(UploadEventsSchema objUploadEventsSchema)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                SqlParameter[] cmdParameter = new SqlParameter[13];

                cmdParameter[0] = new SqlParameter("@flag", SqlDbType.VarChar);
                cmdParameter[0].Value = "Insert";
                cmdParameter[1] = new SqlParameter("@EventTitle", SqlDbType.VarChar);
                cmdParameter[1].Value = objUploadEventsSchema.EventTitle;
                cmdParameter[2] = new SqlParameter("@EventTitleLL", SqlDbType.NVarChar);
                cmdParameter[2].Value = objUploadEventsSchema.EventTitleLL;
                cmdParameter[3] = new SqlParameter("@EventDescr", SqlDbType.VarChar);
                cmdParameter[3].Value = objUploadEventsSchema.EventDescr;
                cmdParameter[4] = new SqlParameter("@EventDescrLL", SqlDbType.NVarChar);
                cmdParameter[4].Value = objUploadEventsSchema.EventDescrLL;
                cmdParameter[5] = new SqlParameter("@ImageContent", SqlDbType.Image);
                cmdParameter[5].Value = objUploadEventsSchema.ImageContent;
                cmdParameter[6] = new SqlParameter("@ImageType", SqlDbType.VarChar);
                cmdParameter[6].Value = objUploadEventsSchema.ImageType;
                cmdParameter[7] = new SqlParameter("@ImageName", SqlDbType.VarChar);
                cmdParameter[7].Value = objUploadEventsSchema.ImageName;
                cmdParameter[8] = new SqlParameter("@IsActive", SqlDbType.Bit);
                cmdParameter[8].Value = objUploadEventsSchema.IsActive;
                cmdParameter[9] = new SqlParameter("@createdDate", SqlDbType.Date);
                cmdParameter[9].Value = objUploadEventsSchema.CreatedDate;
                cmdParameter[10] = new SqlParameter("@updatedDate", SqlDbType.Date);
                cmdParameter[10].Value = objUploadEventsSchema.UpdatedDate;
                cmdParameter[11] = new SqlParameter("@createBy", SqlDbType.VarChar);
                cmdParameter[11].Value = objUploadEventsSchema.CreateBy;
                cmdParameter[12] = new SqlParameter("@updatedBy", SqlDbType.VarChar);
                cmdParameter[12].Value = objUploadEventsSchema.UpdatedBy;


                returnVal = SQLHelper.ExecuteNonQuery(conn, null, CommandType.StoredProcedure, "Sp_UploadEvents", cmdParameter);
                return returnVal;
            }
            catch (Exception ex) { return returnVal; }
            finally
            { SQLHelper.CloseConnection(conn); }
        }

        public int UpdateEventsDL(UploadEventsSchema objUploadEventsSchema)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                SqlParameter[] cmdParameter = new SqlParameter[15];

                cmdParameter[0] = new SqlParameter("@EventId", SqlDbType.Int);
                cmdParameter[0].Value = objUploadEventsSchema.EventId;
                cmdParameter[1] = new SqlParameter("@EventTitle", SqlDbType.VarChar);
                cmdParameter[1].Value = objUploadEventsSchema.EventTitle;
                cmdParameter[2] = new SqlParameter("@EventTitleLL", SqlDbType.NVarChar);
                cmdParameter[2].Value = objUploadEventsSchema.EventTitleLL;
                cmdParameter[3] = new SqlParameter("@EventDescr", SqlDbType.VarChar);
                cmdParameter[3].Value = objUploadEventsSchema.EventDescr;
                cmdParameter[4] = new SqlParameter("@EventDescrLL", SqlDbType.NVarChar);
                cmdParameter[4].Value = objUploadEventsSchema.EventDescrLL;
                cmdParameter[5] = new SqlParameter("@ImageContent", SqlDbType.Image);
                cmdParameter[5].Value = objUploadEventsSchema.ImageContent;
                cmdParameter[6] = new SqlParameter("@ImageType", SqlDbType.VarChar);
                cmdParameter[6].Value = objUploadEventsSchema.ImageType;
                cmdParameter[7] = new SqlParameter("@ImageName", SqlDbType.VarChar);
                cmdParameter[7].Value = objUploadEventsSchema.ImageName;
                cmdParameter[10] = new SqlParameter("@updatedDate", SqlDbType.Date);
                cmdParameter[10].Value = objUploadEventsSchema.UpdatedDate;
                cmdParameter[12] = new SqlParameter("@updatedBy", SqlDbType.VarChar);
                cmdParameter[12].Value = objUploadEventsSchema.UpdatedBy;
                cmdParameter[14] = new SqlParameter("@flag", SqlDbType.VarChar);
                cmdParameter[14].Value = "Update";

                returnVal = SQLHelper.ExecuteNonQuery(conn, null, CommandType.StoredProcedure, "Sp_UploadEvents", cmdParameter);
                return returnVal;
            }
            catch (Exception ex) { return returnVal; }
            finally
            { SQLHelper.CloseConnection(conn); }
        }
    }
}
