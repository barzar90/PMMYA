using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using BL;

namespace PMMYA.PublicApp.API
{
    public partial class MAHAITAPI : MAHAITValidate
    {
        public static List<MAHAITResponse> SetCulture(string CurrentCulture)
        {

            MAHAITResponse t_Response = new MAHAITResponse();

            LoadProfile(HttpContext.Current.Server.MapPath("~/App_Data/" + HttpContext.Current.Profile.UserName));

            t_Response.Action = "CHNGCULT";
            t_Response.FieldName = "CHNGCULT";
            t_Response.Message = "Done";

            //Added By K.P on 21-05-2018
            if (CurrentCulture == "मराठी")
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("mr-IN");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("mr-IN");
                HttpContext.Current.Profile.SetPropertyValue("Selectedlanguage", "mr-IN");
            }
            else if (CurrentCulture == "English")
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-IN");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-IN");
                HttpContext.Current.Profile.SetPropertyValue("Selectedlanguage", "en-IN");
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("hi");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("hi");
                HttpContext.Current.Profile.SetPropertyValue("Selectedlanguage", "hi");
            }

            //End

            MAHAITDBAccess.ValidationResponse.Add(t_Response);


            return MAHAITDBAccess.ValidationResponse;
        }
    }
}