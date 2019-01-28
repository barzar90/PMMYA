using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Schema;
using BL;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class BannerControl : System.Web.UI.UserControl
    {
        #region Public variable declaration
        DataSet ds = null;
        public string LangID = "en-IN";
        StringBuilder sb, sb2;
        public string BannerType = String.Empty;
        BannerControlSchema objBannerControlSchema = new BannerControlSchema();
        BannerBL objBannerBL = new BannerBL();
        #endregion


        protected void Page_PreRender(Object sender, EventArgs e)
        {
            GetRecord();
        }

        protected void GetRecord()
        {       
            objBannerControlSchema.FileType = "Home Banner";
            objBannerControlSchema.LangType = System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower();
            ds = objBannerBL.GetBannerContentDetails(objBannerControlSchema);

                if (ds != null)
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        sb = new StringBuilder();
                        sb2 = new StringBuilder();
                    sb2.Append("<ol class='carousel-indicators'>");
                    sb.Append("<div class='carousel-inner'>");
                    if (ds.Tables[0].Rows.Count > 0)
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            String strUrl = "../../PublicApp/STD/ViewFile.ashx?ID=" + ds.Tables[0].Rows[i]["RowID"].ToString();
                            if (i == 0)
                            {
                                sb2.Append("<li data-target='#carousel-example-generic' data-slide-to='0' class='active'></li>");
                                sb.Append("<div class='item active'>");
                                sb.Append("<img src='" + strUrl + "' alt='" + ds.Tables[0].Rows[i]["FileDtl"].ToString() + "' class='active' />");
                                sb.Append("</div>");
                            }
                            else
                            {
                                sb2.Append("<li data-target='#carousel-example-generic' data-slide-to='" + i.ToString() + "'></li>");
                                sb.Append("<div class='item'>");
                                sb.Append("<img src='" + strUrl + "' alt='" + ds.Tables[0].Rows[i]["FileDtl"].ToString() + "' />");
                                sb.Append("</div>");
                            }
                        }
                    sb.Append("\n");
                    sb.Append("</div>");
                    sb2.Append("</ol>");

                    //sb2.Append("<ol class='wrapper'>");
                    //sb.Append("<div class='full-width'>");
                    //if (ds.Tables[0].Rows.Count > 0)
                    //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //    {
                    //        String strUrl = "../../PublicApp/STD/ViewFile.ashx?ID=" + ds.Tables[0].Rows[i]["RowID"].ToString();
                    //        if (i == 0)
                    //        {
                    //            sb2.Append("<li class='inner'></li>");
                    //            sb.Append("<div class='slide'>");
                    //            sb.Append("<img src='" + strUrl + "' alt='" + ds.Tables[0].Rows[i]["FileDtl"].ToString() + "' class='active' />");
                    //            sb.Append("</div>");
                    //        }
                    //        else
                    //        {
                    //            sb2.Append("<li class='inner'></li>");
                    //            sb.Append("<div class='slide'>");
                    //            sb.Append("<img src='" + strUrl + "' alt='" + ds.Tables[0].Rows[i]["FileDtl"].ToString() + "' />");
                    //            sb.Append("</div>");
                    //        }
                    //    }
                    //sb.Append("\n");
                    //sb.Append("</div>");
                    //sb2.Append("</ol>");

                    LitBanner.Text = sb2.ToString() + sb.ToString();
                    //}
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}