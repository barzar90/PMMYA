using Helper;
using Schema;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DropdownBindDAL
    {
        public DataSet BindState(DropDownnSchema objDropDownnSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@LangID", SqlDbType.VarChar);
                param[0].Value = objDropDownnSchema.Langid;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Sp_BindStateDropDown", param))
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



       

        //[System.Web.Services.WebMethod]
        //public static ArrayList PopulateDistrict(int StateID)
        //{
        //    string Langid;
        //    if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "en-IN")
        //    {
        //        Langid = "1";

        //    }
        //    else { Langid = "2"; }
        //    ArrayList list = new ArrayList();
        //    SqlConnection objConn = SQLHelper.OpenConnection();
        //    try
        //    {





        //        //String strConnString = ConfigurationManager
        //        //    .ConnectionStrings["conString"].ConnectionString;

        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@LangID", Langid);
        //            cmd.Parameters.AddWithValue("@StateID", StateID);
        //            cmd.CommandText = "[Sp_BindDistrictDropDown]";
        //            //cmd.Connection = objConn;
        //            //objConn.Open();
        //            SqlDataReader sdr = cmd.ExecuteReader();
        //            while (sdr.Read())
        //            {
        //                list.Add(new ListItem(
        //               sdr["Districtname"].ToString(),
        //               sdr["Districtcode"].ToString()
        //                ));
        //            }
        //            objConn.Close();
        //            return list;
        //        }

        //    }

        //    catch (Exception ex)
        //    { }
        //    return list;
        //}
        //[System.Web.Services.WebMethod]
        //public static ArrayList PopulateCities(int districtid)
        //{
        //    ArrayList list = new ArrayList();
        //    String strConnString = ConfigurationManager
        //        .ConnectionStrings["conString"].ConnectionString;
        //    String strQuery = "select ID, CityName from Cities where CountryID=@CountryID";
        //    using (SqlConnection con = new SqlConnection(strConnString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Parameters.AddWithValue("@CountryID", districtid);
        //            cmd.CommandText = strQuery;
        //            cmd.Connection = con;
        //            con.Open();
        //            SqlDataReader sdr = cmd.ExecuteReader();
        //            while (sdr.Read())
        //            {
        //                list.Add(new ListItem(
        //               sdr["CityName"].ToString(),
        //               sdr["ID"].ToString()
        //                ));
        //            }
        //            con.Close();
        //            return list;
        //        }
        //    }
        //}
    }
}
