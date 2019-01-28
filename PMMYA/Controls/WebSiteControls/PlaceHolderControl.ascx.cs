using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Schema;
using BL;
using System.Net;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class PlaceHolderControl : System.Web.UI.UserControl
    {
        #region Public variable declaration
        public string ControlID { get; set; }
        PlaceHolderSchema objPlaceHolderSchema = new PlaceHolderSchema();
        PlaceholderBAL objPlaceholderBAL = new PlaceholderBAL();
        DataSet ds;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void Page_PreRender(Object o, EventArgs e)
        {
            BindControl();
        }

        private void BindControl()
        {
            try
            {
                string LangID = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();
                objPlaceHolderSchema.PlaceholderId = Convert.ToInt32(ControlID);
                ds = objPlaceholderBAL.GetPlaceHolderContentDetails(objPlaceHolderSchema);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (LangID == "en-IN")
                    {
                        PContent.InnerHtml = HttpUtility.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["ShortDescription"]).Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty))); ;
                    }
                    else if (LangID == "mr-IN")
                    {
                        PContent.InnerHtml = HttpUtility.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["ShortDescription_LL"]).Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty))); ;
                    }
                    else
                    {
                        PContent.InnerHtml = HttpUtility.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["ShortDescription_UL"]).Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty))); ;
                    }

                    //if (Convert.ToInt32(ControlID) == 1001)
                    //{

                    //    if (LangID == "en-IN")
                    //    {
                    //        PContent.InnerHtml = HttpUtility.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["ShortDescription"]).Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty))); ;
                    //    }
                    //    else if (LangID == "mr-IN")
                    //    {
                    //        PContent.InnerHtml = HttpUtility.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["ShortDescription_LL"]).Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty))); ;
                    //    }
                    //    else
                    //    {
                    //        PContent.InnerHtml = HttpUtility.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["ShortDescription_UL"]).Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty))); ;
                    //    }

                    //    //for (int i = 1; i < 2; i++)
                    //    //{
                    //    //    PContent.InnerHtml = PContent.InnerHtml + "<div class='col-xs-12 col-sm-6 col-md-3 col-lg-3'><div class='weather" + i + " weather__bg'></div></div>";
                    //    //}


                    //    //PContent.InnerHtml = "<div class='row'>";
                    //    //for (int i = 1; i < 4; i++)
                    //    //{
                    //    //    PContent.InnerHtml = PContent.InnerHtml + "<div class='col-xs-12 col-sm-6 col-md-3 col-lg-3'><div class='weather" + i + " weather__bg'></div></div>";
                    //    //}

                    //    PContent.InnerHtml = PContent.InnerHtml + "</div>";
                    //}
                }
                else
                {
                    PContent.InnerHtml = "Information not Available !!!";
                }
            }
            finally
            {

            }
        }


    }

    public class WeatherInfo
    {
        public City city { get; set; }
        public List<List> list { get; set; }
    }

    public class City
    {
        public string name { get; set; }
        public string country { get; set; }
    }

    public class Temp
    {
        public double day { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public double night { get; set; }
    }

    public class Weather
    {
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class List
    {
        public Temp temp { get; set; }
        public int humidity { get; set; }
        public List<Weather> weather { get; set; }
    }
}