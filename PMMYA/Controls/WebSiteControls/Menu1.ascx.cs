using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using Schema;
using BL;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class Menu1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["User"] = Session["UserInRole"];
        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LoginBL objLoginBL = new LoginBL();
            LoginSchema objLoginSchema = new LoginSchema();
            objLoginSchema.UserID = Session["userid"].ToString();
            System.Web.Security.FormsAuthentication.SignOut();
            for (int i = 0; i < Request.Cookies.Count; i++)
            {
                if (Request.Cookies[i].Name != ".ASPXANONYMOUS" || Request.Cookies[i].Name != "CaptchaImageText")
                {
                    HttpCookie myCookie = default(HttpCookie);
                    myCookie = Request.Cookies[i];
                    myCookie.Value = string.Empty;
                    myCookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Set(myCookie);
                }
            }

            HttpContext.Current.Profile.SetPropertyValue("RandomToken", string.Empty);
            HttpContext.Current.Profile.SetPropertyValue("AuthToken", string.Empty);

            for (int i = 0; i < Session.Count - 1; i++)
            {
                if (!(Session.Keys[i] == "CaptchaImageText"))
                {
                    Session[Session.Keys[i]] = null;
                   
                }
            }

            for (int i = 0; i < Request.Cookies.Count; i++)
            {
                HttpCookie myCookie = default(HttpCookie);
                myCookie = Request.Cookies[i];
                myCookie.Value = string.Empty;
                myCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Set(myCookie);
            }

        }

        protected void lnk_createalbum_Click(object sender, EventArgs e)
        {          
            Response.Redirect("~/App/Forms/FrmCreateAlbum.aspx");          
        }

        protected void lnk_updateulbum_Click(object sender, EventArgs e)
        {          
            Response.Redirect("~/App/Forms/FrmViewAlbum.aspx?MODE=album");
        }

        protected void lnk_updatesubalbum_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/App/Forms/FrmViewAlbum.aspx?MODE=subalbum");
        }

        protected void lnk_createalbumforpressnews_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/App/Forms/CreateAlbumForPressNews.aspx");
        }

        protected void lnk_uploadvideo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/App/Forms/CreateAlbumForVideo.aspx");
        }

        //protected void lnk_uploadallpdf_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/App/Forms/UploadAllPdf.aspx");
        //}

       

        protected void lnk_uploadfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/App/Forms/UploadFile.aspx");
        }

        protected void lnk_uploadnews_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/App/Forms/UploadNews.aspx");
        }

        //protected void lnk_uploaddocumenst_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/App/Forms/UploadDocuments.aspx");
        //}

        protected void lnk_audittrail_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/App/Forms/Audit_Trail.aspx");
        }
  
        protected void lnk_cmshome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/MenuManagement/MenuList.aspx");
        }

        protected void lnk_ViewComplaint_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/App/Forms/ViewComplaint.aspx");
        }
    }

}