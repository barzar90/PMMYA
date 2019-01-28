using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;

namespace DAL
{
    public class UploadDocumentDAL
    {

        public DataSet GetUploadPDFDetails(UploadDocumentSchema objUploadDocumentSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {

                var param = new SqlParameter[]
                            {
                               new SqlParameter("@ActionType",objUploadDocumentSchema.Actiontype == null ? (object)DBNull.Value : objUploadDocumentSchema.Actiontype),
                               new SqlParameter("@EnumerationValueID",objUploadDocumentSchema.Enumarationvalueid == null ? (object)DBNull.Value : objUploadDocumentSchema.Enumarationvalueid),
                               new SqlParameter("@DocumentType",objUploadDocumentSchema.Documenttype == null ? (object)DBNull.Value : objUploadDocumentSchema.Documenttype),
                               new SqlParameter("@chkArchive",objUploadDocumentSchema.ChkArchive == false ? Convert.ToBoolean(0) : objUploadDocumentSchema.ChkArchive),
                               new SqlParameter("@parent_EnumerationValueID",objUploadDocumentSchema.Parent_Enumarationvalueid == null ? (object)DBNull.Value : objUploadDocumentSchema.Parent_Enumarationvalueid),
                               new SqlParameter("@DocumentID",objUploadDocumentSchema.Documentid == null ? (object)DBNull.Value : objUploadDocumentSchema.Documentid)
                        };

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_UploadPDF", param))
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

        public int DMLUploadPdf(UploadDocumentSchema objUploadDocumentSchema)
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
                               new SqlParameter("@ActionType",objUploadDocumentSchema.Actiontype == null ? (object)DBNull.Value : objUploadDocumentSchema.Actiontype),
                               new SqlParameter("@DocumentID",objUploadDocumentSchema.Documentid == null ? (object)DBNull.Value : objUploadDocumentSchema.Documentid),
                               new SqlParameter("@subject",objUploadDocumentSchema.Subject == null ? (object)DBNull.Value : objUploadDocumentSchema.Subject),
                               new SqlParameter("@subject_LL",objUploadDocumentSchema.Subject_LL == null ? (object)DBNull.Value : objUploadDocumentSchema.Subject_LL),
                               new SqlParameter("@subject_UL",objUploadDocumentSchema.Subject_UL == null ? (object)DBNull.Value : objUploadDocumentSchema.Subject_UL),
                               new SqlParameter("@DocumentPath",objUploadDocumentSchema.DocumentPath == null ? (object)DBNull.Value : objUploadDocumentSchema.DocumentPath),
                               new SqlParameter("@DocumentPath_LL",objUploadDocumentSchema.DocumentPath_LL == null ? (object)DBNull.Value : objUploadDocumentSchema.DocumentPath_LL),
                               new SqlParameter("@DocumentPath_UL",objUploadDocumentSchema.DocumentPath_UL == null ? (object)DBNull.Value : objUploadDocumentSchema.DocumentPath_UL),
                               new SqlParameter("@DocumentType",objUploadDocumentSchema.Documenttype == null ? (object)DBNull.Value : objUploadDocumentSchema.Documenttype),
                               new SqlParameter("@CreatedBy",objUploadDocumentSchema.Createdby == null ? (object)DBNull.Value : objUploadDocumentSchema.Createdby),
                               new SqlParameter("@Size",objUploadDocumentSchema.Size == null ? (object)DBNull.Value : objUploadDocumentSchema.Size),
                               new SqlParameter("@SeasonId",objUploadDocumentSchema.SeasonId == 0 ? 0 : objUploadDocumentSchema.SeasonId),
                               new SqlParameter("@IsActive",objUploadDocumentSchema.Isctive == false ? Convert.ToBoolean(0) : objUploadDocumentSchema.Isctive),
                               new SqlParameter("@IsArchive",objUploadDocumentSchema.IsArchive == false ? Convert.ToBoolean(0) : objUploadDocumentSchema.IsArchive),
                            };

                            int result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "Usp_DMLUploadPdf", param);
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

        public DataSet GetUploadDocumentDetails(UploadDocumentSchema objUploadDocumentSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {

                var param = new SqlParameter[]
                            {
                               new SqlParameter("@ActionType",objUploadDocumentSchema.Actiontype == null ? (object)DBNull.Value : objUploadDocumentSchema.Actiontype),
                               new SqlParameter("@EnumerationValueID",objUploadDocumentSchema.Enumarationvalueid == null ? (object)DBNull.Value : objUploadDocumentSchema.Enumarationvalueid),
                               new SqlParameter("@DocumentType",objUploadDocumentSchema.Documenttype == null ? (object)DBNull.Value : objUploadDocumentSchema.Documenttype),
                               new SqlParameter("@parent_EnumerationValueID",objUploadDocumentSchema.Parent_Enumarationvalueid == null ? (object)DBNull.Value : objUploadDocumentSchema.Parent_Enumarationvalueid),
                               new SqlParameter("@DocumentID",objUploadDocumentSchema.Documentid == null ? (object)DBNull.Value : objUploadDocumentSchema.Documentid)
                        };

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_UploadDocuments", param))
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

        public int DMLUploadDocument(UploadDocumentSchema objUploadDocumentSchema)
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
                               new SqlParameter("@ActionType",objUploadDocumentSchema.Actiontype == null ? (object)DBNull.Value : objUploadDocumentSchema.Actiontype),
                               new SqlParameter("@DocumentID",objUploadDocumentSchema.Documentid == null ? (object)DBNull.Value : objUploadDocumentSchema.Documentid),
                               new SqlParameter("@Title",objUploadDocumentSchema.Title == null ? (object)DBNull.Value : objUploadDocumentSchema.Title),
                               new SqlParameter("@Title_LL",objUploadDocumentSchema.Title_LL == null ? (object)DBNull.Value : objUploadDocumentSchema.Title_LL),
                               new SqlParameter("@Title_UL",objUploadDocumentSchema.Title_LL == null ? (object)DBNull.Value : objUploadDocumentSchema.Title_LL),
                               new SqlParameter("@Description",objUploadDocumentSchema.Description == null ? (object)DBNull.Value : objUploadDocumentSchema.Description),
                               new SqlParameter("@Description_LL",objUploadDocumentSchema.Description_LL == null ? (object)DBNull.Value : objUploadDocumentSchema.Description_LL),
                               new SqlParameter("@Description_UL",objUploadDocumentSchema.Description_UL == null ? (object)DBNull.Value : objUploadDocumentSchema.Description_UL),
                               new SqlParameter("@DocumentPath",objUploadDocumentSchema.DocumentPath == null ? (object)DBNull.Value : objUploadDocumentSchema.DocumentPath),
                               new SqlParameter("@DocumentPath_LL",objUploadDocumentSchema.DocumentPath_LL == null ? (object)DBNull.Value : objUploadDocumentSchema.DocumentPath_LL),
                               new SqlParameter("@DocumentPath_UL",objUploadDocumentSchema.DocumentPath_UL == null ? (object)DBNull.Value : objUploadDocumentSchema.DocumentPath_UL),
                               new SqlParameter("@DocumentImage",objUploadDocumentSchema.DocumentImage == null ? (object)DBNull.Value : objUploadDocumentSchema.DocumentImage),
                               new SqlParameter("@DocumentType",objUploadDocumentSchema.Documenttype == null ? (object)DBNull.Value : objUploadDocumentSchema.Documenttype),
                               new SqlParameter("@CreatedDate",objUploadDocumentSchema.Createddate == null ? (object)DBNull.Value : objUploadDocumentSchema.Createddate),
                               new SqlParameter("@CreatedBy",objUploadDocumentSchema.Createdby == null ? (object)DBNull.Value : objUploadDocumentSchema.Createdby),
                               new SqlParameter("@Size",objUploadDocumentSchema.Size == null ? (object)DBNull.Value : objUploadDocumentSchema.Size),
                               new SqlParameter("@SeasonId",objUploadDocumentSchema.SeasonId == 0 ? 0 : objUploadDocumentSchema.SeasonId),
                               new SqlParameter("@IsActive",objUploadDocumentSchema.Isctive == false ? Convert.ToBoolean(0) : objUploadDocumentSchema.Isctive),
                               new SqlParameter("@IsArchive",objUploadDocumentSchema.IsArchive == false ? Convert.ToBoolean(0) : objUploadDocumentSchema.IsArchive),
                            };

                            int result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "Usp_DMLUploadDocuments", param);
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
    }
}
