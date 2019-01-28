using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Schema;
using BL;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace PMMYA.Site.Home
{
    public partial class ContactUs : System.Web.UI.Page
    {
        #region Public variable declaration    

        public static int LangID = 0;

        ContactUsSchema objcontact = new ContactUsSchema();
        ContactUsBL objContactUsBL = new ContactUsBL();
        MAHAITUserControl _MahaITUC = new MAHAITUserControl();
        #endregion

      

        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
            //    GetDpoDetails(LangID);
            //}

        }

        [System.Web.Services.WebMethod]
        public static List<ContactUsSchema> BindDpoDetails()
        {
            List<ContactUsSchema> DPOData = new List<ContactUsSchema>();

            try
            {
                
                ContactUsSchema objcontact = new ContactUsSchema();
                ContactUsBL objContactUsBL = new ContactUsBL();
                DataSet ds = new DataSet();

                objcontact.Langid = LangID;
                ds = objContactUsBL.GetDPODetails(objcontact);


                string str = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0]);
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                DPOData = JsonConvert.DeserializeObject<List<ContactUsSchema>>(str.ToString());
                
            }
            catch (Exception EX)
            {

            }
            return DPOData;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            LblSrno.Text = _MahaITUC.GetResourceValue("Common", "LblSrno", "");
            lblDistrict.Text = _MahaITUC.GetResourceValue("Common", "lblDistrict", "");
            LblDponame.Text = _MahaITUC.GetResourceValue("Common", "LblDponame", "");
            LblOfficeAddress.Text = _MahaITUC.GetResourceValue("Common", "LblOfficeAddress", "");
            LblEmailIdContact.Text = _MahaITUC.GetResourceValue("Common", "lblEmailId", "");
            LblTelNo.Text = _MahaITUC.GetResourceValue("Common", "lblTelephone", "");

            try
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                {
                    LangID = 2;
                }
                else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
                {
                    LangID = 1;
                }
                else
                {
                    LangID = 3;
                }
                lblContact.Text = _MahaITUC.GetResourceValue("Common", "lblContact", "");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}