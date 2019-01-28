using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Threading;
using BL;
using Schema;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class PdfControl : System.Web.UI.UserControl
    {
        #region Public variable declaration
        DataSet ds;
        BannerControlSchema objBannerControlSchema = new BannerControlSchema();
        BannerBL objBannerBL = new BannerBL();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void Page_PreRender(Object o, EventArgs e)
        {
            BindLiterals();
        }

        private void BindLiterals()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                string COLdocPath, COLsubject, Heading;
                if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                {
                    COLsubject = "Subject_LL";
                    COLdocPath = "DocumentPath_LL";
                    Heading = "ताज्या घडामोडी";
                }
                else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
                {
                    COLsubject = "Subject";
                    COLdocPath = "DocumentPath";
                    Heading = "LATEST UPDATE";
                }
                else
                {
                    COLsubject = "مضمون";
                    COLdocPath = "دستاویزی پاتھ";
                    Heading = "تازہ ترین اپ ڈیٹ";
                }
                objBannerControlSchema.Parameter = "Select_For_Marquee";
                ds = objBannerBL.GetMarquee(objBannerControlSchema);         
                    if (ds.Tables.Count > 0)
                    {
                        sb.Append("<ul>");
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            sb.Append("<li>");
                            sb.Append("<a class='ExternalLink' target='_blank' href='../../site/upload/pdf/" + ds.Tables[0].Rows[i][COLdocPath].ToString() + "'>");
                            sb.Append("<i class='fa fa-comment'></i>");
                            sb.Append(Convert.ToString(ds.Tables[0].Rows[i][COLsubject] + "      "));
                            sb.Append("</a>");
                            sb.Append("</li>");
                        }
                        for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                        {
                            sb.Append("<li>");
                            sb.Append("<a class='ExternalLink' target='_blank' href='" + ds.Tables[1].Rows[j][COLdocPath].ToString() + "'>");
                            sb.Append(Convert.ToString(ds.Tables[1].Rows[j][COLsubject] + "     "));
                            sb.Append("</a>");
                            sb.Append("</li>");
                        }
                    }
                    sb.Append("</ul>");
                    literalDisplay.Text = sb.ToString();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}