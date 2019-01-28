using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using BL;
using Schema;

namespace PMMYA.Site.Home
{
    public partial class SearchSite : System.Web.UI.Page
    {
        #region Public variable declaration
        int length = 0;
        BL.BL MAHAITDBAccess;
        String Keyword;
        int LangID = 0;
        DataSet ds;
        private string KeywordChange = "";
        string SearchString = string.Empty;
        SearchBAL objSearchBAL = new SearchBAL();
        SearchSchema objSearchSchema = new SearchSchema();
        MAHAITUserControl _mahaitUC = new MAHAITUserControl();
        string msgtext = "";
        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            MAHAITDBAccess = ((MAHAITMasterPage)this.Master).MAHAITDBAccess;
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            //lblPartnersHeading.Text = GetResourceValue("Login", "lblViewPartnersHeading", lblPartnersHeading.Text);

            lblPartnersHeading.Text = GetResourceValue("Common", "lblViewPartnersHeading", "");

            msgtext = _mahaitUC.GetResourceValue("Common", "lblSearchword", "");


            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                LangID = 2;
                lblSearchword.Text = msgtext + ViewState["keyword"].ToString() + "";
            }

            else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
            {
                LangID = 1;
                lblSearchword.Text = msgtext + ViewState["keyword"].ToString() + "";
            }
            else
            {
                LangID = 3;
                lblSearchword.Text = msgtext + ViewState["keyword"].ToString() + "";
            }

            if (hdncult.Value == String.Empty)
            {
                hdncult.Value = MAHAITDBAccess.LangID;
                BindSearchDataList(Convert.ToInt32(hdncult.Value), Keyword);
            }
            else
            {
                if (MAHAITDBAccess.LangID.ToString() != hdncult.Value)
                {
                    hdncult.Value = MAHAITDBAccess.LangID.ToString();
                    BindSearchDataList(Convert.ToInt32(hdncult.Value), Keyword);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            length = Convert.ToString(Request.QueryString["Keyword"]).Length;
            PMMYA.WebServices.validateHtml objvalid = new WebServices.validateHtml();
            bool flg = true;
            HttpUtility.HtmlDecode(Convert.ToString(Request.QueryString["Keyword"]));
            if (!objvalid.ValidateHTML(Convert.ToString(Request.QueryString["Keyword"]).ToLower()))
            {
                flg = false;
            }
            if (!objvalid.ValidateHTML(HttpUtility.HtmlDecode(Convert.ToString(Request.QueryString["Keyword"]))))
            {
                flg = false;

            }
            if (flg)
            {
                if (Convert.ToString(Request.QueryString["Keyword"]) == "" || Convert.ToString(Request.QueryString["Keyword"]) == string.Empty)
                    return;

                if (Convert.ToString(Request.QueryString["Keyword"]).ToLower().Contains("Hacked") || Convert.ToString(Request.QueryString["Keyword"]).ToLower().Contains("Compromise"))
                    return;

                if (Convert.ToString(Request.QueryString["Keyword"]).Length == 2)
                    return;

                if (Convert.ToString(Request.QueryString["Keyword"]).Contains(";") || Convert.ToString(Request.QueryString["Keyword"]).Contains("/") || Convert.ToString(Request.QueryString["Keyword"]).Contains("(") || Convert.ToString(Request.QueryString["Keyword"]).Contains("<") || Convert.ToString(Request.QueryString["Keyword"]).Contains(")") || Convert.ToString(Request.QueryString["Keyword"]).Contains(">"))
                    return;


                msgtext = _mahaitUC.GetResourceValue("Common", "lblSearchword", "");

                if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                {
                    LangID = 2;
                    lblSearchword.Text = msgtext + Keyword + " ";
                }
                else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
                {
                    LangID = 1;
                    lblSearchword.Text = msgtext + Keyword + " ";
                }
                else
                {
                    LangID = 3;
                    lblSearchword.Text = msgtext + Keyword + " ";
                }


                ViewState["keyword"] = Convert.ToString(Request.QueryString["Keyword"]);
                if (!IsPostBack)
                {
                    Keyword = Convert.ToString(Request.QueryString["Keyword"]);

                }
            }
        }

        
        #region Methods
        private void BindSearchDataList(int LangID, String Keyword)
        {
            try

            {
                if (Request.QueryString["Keyword"] != null)
                {
                    hdn_keyword.Value = Request.QueryString["Keyword"];
                }

                if (hdn_keyword.Value != string.Empty)
                {
                    KeywordChange = Convert.ToString(hdn_keyword.Value);
                    SearchString = "<span style='background:yellow; display:inline-block; color:#000;'>" + KeywordChange + "</span>";
                }
                DataTable dtSearchList = new DataTable();
                dtSearchList = FetchSearchSite(LangID, Keyword);
                for (int i = 0; i < dtSearchList.Rows.Count; i++)
                {

                    dtSearchList.Rows[i]["PageTitle"] = Convert.ToString(Regex.Replace(dtSearchList.Rows[i]["PageTitle"].ToString(), KeywordChange, SearchString, RegexOptions.IgnoreCase));
                    dtSearchList.Rows[i]["ShortDescription"] = Convert.ToString(Regex.Replace(dtSearchList.Rows[i]["ShortDescription"].ToString(), KeywordChange, SearchString, RegexOptions.IgnoreCase));
                    dtSearchList.Rows[i]["SearchURL"] = dtSearchList.Rows[i]["SearchURL"] + "?Keyword=" + Convert.ToString(ViewState["keyword"]);
                }
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dtSearchList.DefaultView;
                pds.AllowPaging = true;
                pds.PageSize = 10;
                dlSearchSite.DataSource = pds;
                dlSearchSite.DataBind();
            }
            catch { }
            finally
            {

            }
        }

        public string GetResourceValue(string ResourceFile, string ResourceKey, string DefaultValue)
        {
            object t_Value = GetGlobalResourceObject(ResourceFile, ResourceKey);

            return t_Value == null ? DefaultValue : t_Value.ToString();
        }

        public DataTable FetchSearchSite(int langid, string Keyword)
        {
            DataTable dtSearchSite;
            try
            {
                objSearchSchema.LangID = langid;
                objSearchSchema.Keyword = Keyword;
                ds = objSearchBAL.SearchDetails(objSearchSchema);
                dtSearchSite = ds.Tables[0];
                return dtSearchSite;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                dtSearchSite = null;
            }
        }
        #endregion
    }
}