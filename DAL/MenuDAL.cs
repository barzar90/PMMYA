using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;

namespace DAL
{
    public class MenuDAL
    {
        #region Public variable declaration
        //DataSet ds;
        #endregion

   
        public DataSet GetMenuType()
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@MenuType", SqlDbType.VarChar);
                param[0].Value = "BindMenu";

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "UspGetMenuDetails", param))
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

        public DataSet GetParentList()
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@MenuType", SqlDbType.VarChar);
                param[0].Value = "BindParent";

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "UspGetMenuDetails", param))
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

        public DataSet GetChildList(MenuSchema objmenuschema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@MenuType", SqlDbType.VarChar);
                param[0].Value = "BindChild";
                param[1] = new SqlParameter("@MenuID", SqlDbType.Int);
                param[1].Value = objmenuschema.Parentid;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "UspGetMenuDetails", param))
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

        public DataSet GetPageUrl(MenuSchema objmenuschema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@MenuType", SqlDbType.VarChar);
                param[0].Value = "GetPageUrl";
                param[1] = new SqlParameter("@RowID", SqlDbType.Int);
                param[1].Value = objmenuschema.Rowid;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "UspGetMenuDetails", param))
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

        public DataSet GetMenuId(MenuSchema objmenuschema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@MenuType", SqlDbType.VarChar);
                param[0].Value = "GetMenuID";
                param[1] = new SqlParameter("@ParentID", SqlDbType.Int);
                param[1].Value = objmenuschema.Parentid;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "UspGetMenuDetails", param))
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

        public DataSet GetPagedata(MenuSchema objmenuschema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@MenuType", SqlDbType.VarChar);
                param[0].Value = "GetPageData";
                param[1] = new SqlParameter("@MenuID", SqlDbType.Int);
                param[1].Value = objmenuschema.Menuid;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "UspGetMenuDetails", param))
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

        public int SaveMenuDeatails(MenuSchema objmenuschema)
        {
            try
            {

                using (SqlConnection objConn = SQLHelper.OpenConnection())
                {
                    using (SqlTransaction objTran = objConn.BeginTransaction())
                    {
                        try
                        {

                            SqlParameter imageParameter = new SqlParameter("@MenuImage", SqlDbType.Image);
                            imageParameter.Value = objmenuschema.MenuImage ;

                           
                            //param.Parameters.Add(imageParameter);

                            var param = new SqlParameter[]
                            {
                             new SqlParameter("@MenuName",objmenuschema.MenuName== null ? (object)DBNull.Value : objmenuschema.MenuName),
                             new SqlParameter("@MenuName_LL",objmenuschema.MenuName_LL== null ? (object)DBNull.Value : objmenuschema.MenuName_LL),
                             new SqlParameter("@MenuName_UL",objmenuschema.MenuName_UL== null ? (object)DBNull.Value : objmenuschema.MenuName_UL),
                             new SqlParameter("@IsNewFlag",objmenuschema.IsNewflag == false ? Convert.ToBoolean(0) : objmenuschema.IsNewflag),
                             new SqlParameter("@Active",objmenuschema.Active == false ? Convert.ToBoolean(0) : objmenuschema.Active),
                             new SqlParameter("@IsExternalLink",objmenuschema.IsEternalLink == false ? (Convert.ToBoolean(0)): objmenuschema.IsEternalLink),
                             new SqlParameter("@MetaDescription",objmenuschema.MetaDescription == null ? (object)DBNull.Value : objmenuschema.MetaDescription),
                             new SqlParameter("@MetaDescription_LL",objmenuschema.MetaDescription_LL == null ? (object)DBNull.Value : objmenuschema.MetaDescription_LL),
                             new SqlParameter("@MetaDescription_UL",objmenuschema.MetaDescription_UL == null ? (object)DBNull.Value : objmenuschema.MetaDescription_UL),
                             new SqlParameter("@MetaKeywords",objmenuschema.MetaKeywords == null ? (object)DBNull.Value : objmenuschema.MetaKeywords),
                             new SqlParameter("@MetaKeywords_LL",objmenuschema.MetaKeywords_LL == null ? (object)DBNull.Value : objmenuschema.MetaKeywords_LL),
                             new SqlParameter("@MetaKeywords_UL",objmenuschema.MetaKeywords_UL == null ? (object)DBNull.Value : objmenuschema.MetaKeywords_UL),
                             //new SqlParameter("@MenuImage",objmenuschema.MenuImage == null ? (object)DBNull.Value : objmenuschema.MenuImage),
                             new SqlParameter("@MenuImage", imageParameter.Value),                        
                            new SqlParameter("@SequenceNo",objmenuschema.SequenceNo == 0 ? 0 : objmenuschema.SequenceNo),
                             new SqlParameter("@MenuCategory",objmenuschema.MenuCategory == null ? (object)DBNull.Value : objmenuschema.MenuCategory),
                             new SqlParameter("@MenuType",objmenuschema.MenuType == 0 ? 0 : objmenuschema.MenuType),
                             new SqlParameter("@MenuTypeValue",objmenuschema.MenuTypeValue == null ? (object)DBNull.Value : objmenuschema.MenuTypeValue),
                             new SqlParameter("@ParentID",objmenuschema.Parentid == 0 ? 0 : objmenuschema.Parentid),
                             new SqlParameter("@RoleID",objmenuschema.Role_id == null ? (object)DBNull.Value : objmenuschema.Role_id),
                             new SqlParameter("@CreatedBy",objmenuschema.Createdby == 0 ? 0 : objmenuschema.Createdby),
                             new SqlParameter("@PageHeading",objmenuschema.PageHeading == null ? (object)DBNull.Value : objmenuschema.PageHeading),
                             new SqlParameter("@PageHeading_LL",objmenuschema.PageHeading_LL == null ? (object)DBNull.Value : objmenuschema.PageHeading_LL),
                             new SqlParameter("@PageHeading_UL",objmenuschema.PageHeading_UL == null ? (object)DBNull.Value : objmenuschema.PageHeading_UL),
                             new SqlParameter("@PageTitle",objmenuschema.PageTitle == null ? (object)DBNull.Value : objmenuschema.PageTitle),
                             new SqlParameter("@PageTitle_LL",objmenuschema.PageTitle_LL == null ? (object)DBNull.Value : objmenuschema.PageTitle_LL),
                             new SqlParameter("@PageTitle_UL",objmenuschema.PageTitle_UL == null ? (object)DBNull.Value : objmenuschema.PageTitle_UL),
                             new SqlParameter("@ForMobileVersion",objmenuschema.ForMobileVersion == false ? Convert.ToBoolean(0) : objmenuschema.ForMobileVersion),
                             new SqlParameter("@MenuID",objmenuschema.Menuid == 0 ? 0 : objmenuschema.Menuid),
                             new SqlParameter("@FileExt",objmenuschema.FileExt == null ? (object)DBNull.Value : objmenuschema.FileExt),
                             new SqlParameter("@ActionType",objmenuschema.ActionType == null ? (object)DBNull.Value : objmenuschema.ActionType)
                             

                        };
                           
                         

                            int result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "UspDMLMenuMaster", param);
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


        public DataSet GetMenuListDetails(MenuSchema objmenuschema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[3];

                param[0] = new SqlParameter("@ActionType", SqlDbType.VarChar);
                param[0].Value = objmenuschema.ActionType;
                param[1] = new SqlParameter("@MenuID", SqlDbType.Int);
                param[1].Value = objmenuschema.Menuid;
                param[2] = new SqlParameter("@MenuCategory", SqlDbType.VarChar);
                param[2].Value = objmenuschema.MenuCategory;
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "UspGetMenuListDetails", param))
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

        public int DMLMenuListDetails(MenuSchema objmenuschema)
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
                             new SqlParameter("@Menuid",objmenuschema.Menuid == 0 ? 0 : objmenuschema.Menuid),                            
                            };
                            int result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "Usp_DMLMenuListDetails", param);
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

        public DataSet GetMenuDetails(MenuSchema objmenuschema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@MenuName", SqlDbType.VarChar);
                param[0].Value = objmenuschema.MenuName;
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetMenuDetails", param))
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
