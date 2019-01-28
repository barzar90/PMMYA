using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Schema;
using BL;
using System.Collections;
using System.Web.Services;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class DistrictSubdistictUserControl : System.Web.UI.UserControl
    {
        BL.BL mahaitDbAccess;
        DropDownBindBL objDropDownBindBL = new DropDownBindBL();
        DropDownnSchema ObjDropDownnSchema = new DropDownnSchema();

        DataTable dt;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "en-IN")
                {
                    ObjDropDownnSchema.Langid = "1";

                }
                else { ObjDropDownnSchema.Langid = "2"; }
                ViewState["LangId"] = ObjDropDownnSchema.Langid;
                StateBind();
                //BindDummyGridrow();
                BindDummyRow();
            }
        }

        
        public void StateBind()
        {
            ds = new DataSet();
            ds = objDropDownBindBL.BindState(ObjDropDownnSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlState.DataSource = ds;
                ddlState.DataTextField = "Statename";
                ddlState.DataValueField = "StateCode";
                ddlState.DataBind();
            }
            else
            {
                ddlState.DataSource = null;
                ddlState.DataBind();
            }
        }


        private void BindDummyRow()
        {
            DataTable dummy = new DataTable();
            dummy.Columns.Add("BankName");
            dummy.Columns.Add("BranchName");
            dummy.Columns.Add("BranchAddress");
            dummy.Columns.Add("DistrictName");
            dummy.Rows.Add();
            gvCustomers.DataSource = dummy;
            gvCustomers.DataBind();
        }





        //[System.Web.Services.WebMethod]
        //public static ArrayList PopulateDistrict(int StateID)
        //{
        //    string langid;
        //    if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "en-IN")
        //    {

        //        langid = "1";
        //    }
        //    else { langid = "2"; }
        //    ArrayList list = new ArrayList();
        //    list =PopulateDistrict(;
        //    return list;

        //}

        [System.Web.Services.WebMethod]
        public static ArrayList PopulateCities(int districtid)
        {
            ArrayList list = new ArrayList();
            String strConnString = ConfigurationManager
                .ConnectionStrings["conString"].ConnectionString;
            String strQuery = "select ID, CityName from Cities where CountryID=@CountryID";
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CountryID", districtid);
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        list.Add(new ListItem(
                       sdr["CityName"].ToString(),
                       sdr["ID"].ToString()
                        ));
                    }
                    con.Close();
                    return list;
                }
            }
        }
    }
}

