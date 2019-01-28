using BL;
using Newtonsoft.Json;
using Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMMYA.Site.Home
{   
    public partial class Financer : System.Web.UI.Page
    {
        #region Public variable declaration
        ApplicationFormSchema objApplicationFormSchema = new ApplicationFormSchema();
        ApplicationFormBAL objApplicationFormBAL = new ApplicationFormBAL();
        Feedback_BL objFeedback_BL = new Feedback_BL();
        FeddbackSchema objFeedback_Schema = new FeddbackSchema();
        DataTable dt;
        DataSet ds;
        MAHAITUserControl _MahaITUC = new MAHAITUserControl();
        CMSBL objCMSBL = new CMSBL();
        CMSSchema objCMSSchema = new CMSSchema();
        int menuid = 0;
        #endregion

        protected void Page_PreRender(Object sender, EventArgs e)
        {
            lblBankDetails.Text = _MahaITUC.GetResourceValue("Common", "lblfinancer", "");
            lblDistrict.Text = _MahaITUC.GetResourceValue("Common", "lblDistrict", "");
            lblTaluka.Text = _MahaITUC.GetResourceValue("Common", "lblTaluka", "");
            LblBankName.Text = _MahaITUC.GetResourceValue("Common", "lblBankName", "");
            LblBranchName.Text = _MahaITUC.GetResourceValue("Common", "lblBranch", "");
            LblBankAddress.Text = _MahaITUC.GetResourceValue("Common", "lblBankAdd", "");
            LblIFSCCode.Text = _MahaITUC.GetResourceValue("Common", "lblBankIFSC", "");

            BindDistrict();
            menuid = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SerachFinancer"]);
            BindLeftMenu(menuid);           
        }
        protected void Page_Load(object sender, EventArgs e)
        {       
            
        }
        public void BindDistrict()
        {
            objFeedback_Schema.Langid = 1;
            ds = new DataSet();
            ds = objFeedback_BL.GetDistrict(objFeedback_Schema);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddldistrict.DataSource = ds;
                ddldistrict.DataTextField = "Districtname";
                ddldistrict.DataValueField = "Districtcode";
                ddldistrict.DataBind();
                ddldistrict.Items.Insert(0, new ListItem("--Select--", "0"));
                ddldistrict.SelectedValue = "0";

            }
            else
            {
                ddldistrict.Items.Insert(0, new ListItem("--Select--", "0"));
                ddldistrict.SelectedValue = "0";
            }
        }

        public void BindLeftMenu(int menuid)
        {
            try
            {

                string LangID = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();
                objCMSSchema.MenuID = Convert.ToInt32(menuid);
                ds = objCMSBL.GetLeftMenuDetails(objCMSSchema);
                if (ds.Tables.Count > 0)
                {
                    PContent.Visible = true;
                    LeftMenuContent.Visible = true;
                    PContent.InnerHtml = "<ul class='quick-links'>";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (LangID == "en-IN")
                        {
                            PContent.InnerHtml += "<li><a href=" + HttpUtility.HtmlDecode(Convert.ToString(dr["ShortDescription"]).Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty))) + ">" + dr["MenuName"] + "</a></li>";
                        }
                        else if (LangID == "mr-IN")
                        {
                            PContent.InnerHtml += "<li><a href=" + HttpUtility.HtmlDecode(Convert.ToString(dr["ShortDescription_LL"]).Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty))) + ">" + dr["MenuName_LL"] + "</a></li>";
                        }
                        else
                        {
                            PContent.InnerHtml += "<li><a href=" + HttpUtility.HtmlDecode(Convert.ToString(dr["ShortDescription_UL"]).Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty))) + ">" + dr["MenuName_UL"] + "</a></li>";
                        }
                    }
                    PContent.InnerHtml += "</ul>";
                }
                else
                {
                    PContent.Visible = false;
                    LeftMenuContent.Visible = false;
                }
            }
            finally
            {

            }
        }
        [System.Web.Services.WebMethod]
        public static ArrayList PopulateSubDistrict(int DistrictID)
        {

            DataSet ds;
            DataTable dt = new DataTable();
            ApplicationFormSchema objApplicationFormSchema = new ApplicationFormSchema();
            ApplicationFormBAL objApplicationFormBAL = new ApplicationFormBAL();
            DataTableReader dr;
            ArrayList list = new ArrayList();


            objApplicationFormSchema.Districtid = DistrictID;

            ds = objApplicationFormBAL.GetTaluka(objApplicationFormSchema);

            if (ds != null)
            {
                dt = ds.Tables[0];

                dr = dt.CreateDataReader();
                while (dr.Read())
                {
                    list.Add(new ListItem(
                   dr["SubDistrictname"].ToString(),
                   dr["SubDistrictcode"].ToString()
                    ));
                }
                return list;
            }


            return list;
        }
        public class BankData
        {
            public string BankName { get; set; }
            public string BranchName { get; set; }
            public string IFSCode { get; set; }
            public string BranchAddress { get; set; }
            public List<BankData> data { get; set; }
        }

        [System.Web.Services.WebMethod]
        public static List<BankData> BindBankList(int districtid, int talukaid)
        {
            DataSet ds;
            DataTable dt = new DataTable();
            ApplicationFormSchema objApplicationFormSchema = new ApplicationFormSchema();
            ApplicationFormBAL objApplicationFormBAL = new ApplicationFormBAL();
            DataTableReader dr;
            //ArrayList list = new ArrayList();
            List<BankData> bankdata = new List<BankData>();
            objApplicationFormSchema.Districtid = districtid;
            objApplicationFormSchema.Talukaid = talukaid;

            ds = objApplicationFormBAL.GetBankData(objApplicationFormSchema);

            //if (ds != null)
            //{
            //    dt = ds.Tables[0];
            //    dr = dt.CreateDataReader();
            //    while (dr.Read())
            //    {
            //        bankdata.Add(new BankData()
            //        {
            //            BankName = dr["BankName"].ToString(),
            //            BranchName = dr["BranchName"].ToString(),
            //            BranchAddress = dr["BranchAddress"].ToString(),
            //            IFSCode = dr["IFSCode"].ToString()
            //        });
            //    }
            //    return bankdata;
            //}

            string str = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0]);
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            bankdata = JsonConvert.DeserializeObject<List<BankData>>(str.ToString());

            return bankdata;
        }

        
    }
}