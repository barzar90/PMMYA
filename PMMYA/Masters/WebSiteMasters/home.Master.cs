
using System;
using System.Web.UI.HtmlControls;
using PMMYA.Controls.WebSiteControls;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using BL;
using System.Web.Services;
using Schema;

namespace PMMYA.Masters.WebSiteMasters
{
    public partial class home : MAHAITMasterPage
    {
        #region Public variable declaration
        int LangID = 0;
        LastReviewedDate objLastReviewedDate = new LastReviewedDate();
        ApplicationFormSchema objApplicationFormSchema = new ApplicationFormSchema();
        ApplicationFormBAL objApplicationFormBAL = new ApplicationFormBAL();
        DataSet ds;
        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();

            if (Request.Cookies[".ASPXANONYMOUS"] != null)
            {
                HttpCookie myCookie = new HttpCookie(".ASPXANONYMOUS");
                Request.Cookies[".ASPXANONYMOUS"].Value = "";
            }
            Response.Cookies[".ASPXAUTH"].Value = String.Empty;
            Response.Cookies.Remove(".ASPXAUTH");
            Request.Cookies.Remove(".ASPXAUTH");

            HttpContext.Current.Profile.SetPropertyValue("RandomToken", string.Empty);
            HttpContext.Current.Profile.SetPropertyValue("AuthToken", string.Empty);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindLoanType();
                BindBusinessPurpose();
            }
            Culture = HeaderMain1.SetCulture1.MAHAITCurrentCultureID;
            HeaderMain1.SetCulture1.ButtonClickedLarger += new EventHandler(SetCulture1_ButtonClickedBrightest);
            HeaderMain1.SetCulture1.ButtonClickedLarge += new EventHandler(SetCulture1_ButtonClickedBright);
            HeaderMain1.SetCulture1.ButtonClickedMedium += new EventHandler(SetCulture1_ButtonClickedNormal);
            HeaderMain1.SetCulture1.ButtonClickedSmall += new EventHandler(SetCulture1_ButtonClickedDark);
            HeaderMain1.SetCulture1.ButtonClickedSmallest += new EventHandler(SetCulture1_ButtonClickedDarkest);
            HeaderMain1.SetCulture1.ButtonClickedABlack += new EventHandler(SetCulture1_ButtonClickedContrast);
            HeaderMain1.SetCulture1.ButtonClickedAWhite += new EventHandler(SetCulture1_ButtonClickedWhite);
            HeaderMain1.SetCulture1.ButtonClickedCultureSheet += new EventHandler(SetCulture1_ButtonClickedCultureSheet);
            //MudraDetails.ButtonClickedSubmit += new EventHandler(MudraDetails_ButtonClickedSubmit);


            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                LangID = 2;
            }
            else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-US").ToLower())
            {
                LangID = 1;
            }
            else
            {
                LangID = 3;
            }
                
        }
        protected void Page_PreRender(Object sender, EventArgs e)
        {
            if (LangID == 1)
            {
                Page.MetaDescription = "";
                Page.MetaKeywords = "";
                Head1.Attributes["lang"] = "en-US";
            }
            //Added By K.p
            else if (LangID == 3)
            {
                Page.MetaDescription = "";
                Page.MetaKeywords = "";
                Head1.Attributes["lang"] = "hi";
            }
            else
            {
                Page.MetaDescription = "";
                Page.MetaKeywords = "";
                Head1.Attributes["lang"] = "mr-IN";
            }

            MAHAITUserControl _MahaITUC = new MAHAITUserControl();
            lbldepName.Text = _MahaITUC.GetResourceValue("Common", "lbldepName", "");
            lblGallery.Text = _MahaITUC.GetResourceValue("Common", "lblGallery", "");
            lblMotivational.Text = _MahaITUC.GetResourceValue("Common", "lblMotivational", "");
            lblSuccessStories.Text = _MahaITUC.GetResourceValue("Common", "lblSuccessStories", "");
            lblPhoto.Text = _MahaITUC.GetResourceValue("Common", "lblPhoto", "");
            lblName.Text = _MahaITUC.GetResourceValue("Common", "lblName", "");
            lblMobileNumber.Text = _MahaITUC.GetResourceValue("Common", "lblMobileNumber", "");
            lblEmailId.Text = _MahaITUC.GetResourceValue("Common", "lblEmailId", "");
            LblDescription.Text = _MahaITUC.GetResourceValue("Common", "LblDescription", "");
            btnSubmit.InnerText = _MahaITUC.GetResourceValue("Common", "btnSubmit", "");
        }

        void SetCulture1_ButtonClickedCultureSheet(object sender, EventArgs e)
        {
            HtmlLink Link = FindControl("CultureSheet") as HtmlLink;
            if (Link == null) return;
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                Link.Href = @"../../Styles/LayoutMR.css";
            }
            else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
            {
                Link.Href = @"../../Styles/LayoutEN.css";
            }
            else
            {
                Link.Href = @"../../Styles/LayoutUR.css";
            }
        }

        protected void SetCulture1_ButtonClickedBrightest(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "larger");
        }
        protected void SetCulture1_ButtonClickedBright(object sender, System.EventArgs e)
        {

            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "large");

        }
        protected void SetCulture1_ButtonClickedNormal(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "medium");

        }
        protected void SetCulture1_ButtonClickedDark(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "small");

        }
        protected void SetCulture1_ButtonClickedDarkest(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "smaller");

        }
        protected void SetCulture1_ButtonClickedWhite(object sender, System.EventArgs e)
        {
            HtmlLink link = FindControl("mystylesheet") as HtmlLink;
            link.Href = @"../../styles/Layout.css";
        }
        protected void SetCulture1_ButtonClickedContrast(object sender, System.EventArgs e)
        {
            HtmlLink Link = FindControl("MyStyleSheet") as HtmlLink;
            Link.Href = @"../../Styles/LayoutBlack.css";

        }

        protected void Page_Unload(object sender, EventArgs e)
        {
           
        }


        //public void BindLoanType()
        //{
        //    objApplicationFormSchema.Type = "LoanType";

        //    ds = new DataSet();
        //    ds = objApplicationFormBAL.GetLoanTypeDetails(objApplicationFormSchema);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {

        //        ddlloantype.DataSource = ds;
        //        ddlloantype.DataTextField = "MudraLoanType";
        //        ddlloantype.DataValueField = "ID";
        //        ddlloantype.DataBind();
        //        ddlloantype.Items.Insert(0, new ListItem("--Select--", "0"));
        //        //ddlloantype.SelectedIndex =0;

        //    }
        //    else
        //    {
        //        ddlloantype.Items.Insert(0, new ListItem("--Select--", "0"));
        //        //ddlloantype.SelectedIndex = 0;
        //    }
        //}

        public void BindBusinessPurpose()
        {
            objApplicationFormSchema.Type = "BusinessPurpose";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetLoanTypeDetails(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlBusinessPurpose.DataSource = ds;
                ddlBusinessPurpose.DataTextField = "PurposeType";
                ddlBusinessPurpose.DataValueField = "ID";
                ddlBusinessPurpose.DataBind();
                ddlBusinessPurpose.Items.Insert(0, new ListItem("--Select--", "0"));
                //ddlloantype.SelectedIndex =0;

            }
            else
            {
                ddlBusinessPurpose.Items.Insert(0, new ListItem("--Select--", "0"));
                //ddlloantype.SelectedIndex = 0;
            }
        }
    }
}