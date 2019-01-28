using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using PMMYA;
using BL;

namespace PMMYA.Site
{
    public class PageBase:MAHAITPage
    {
        public void SetUICulture(Hashtable controls)
        {
            string cultureName = null;
            try
            {             
                foreach (DictionaryEntry entry in controls)
                {
                    switch (entry.Key.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.Button":
                            ((Button)entry.Key).Text = GetResourceValue("Resource", entry.Value.ToString(), "");
                            break;
                        case "System.Web.UI.WebControls.Label":
                            ((Label)entry.Key).Text = GetResourceValue("Resource", entry.Value.ToString(), "");
                            break;
                        case "System.Web.UI.RadioButtonList":
                            ((RadioButtonList)entry.Key).Text = GetResourceValue("Resource", entry.Value.ToString(), "");
                            break;
                        case "System.Web.UI.RadioButton":
                            ((RadioButton)entry.Key).Text = GetResourceValue("Resource", entry.Value.ToString(), "");
                            break;
                        case "System.Web.UI.WebControls.LinkButton":
                            ((LinkButton)entry.Key).Text = GetResourceValue("Resource", entry.Value.ToString(), "");
                            break;
                        case "System.Web.UI.WebControls.DataControlFieldHeaderCell":
                            ((DataControlFieldHeaderCell)entry.Key).Text = GetResourceValue("Resource", entry.Value.ToString(), "");
                            break;
                        case "System.Web.UI.HtmlControls.HtmlGenericControl":
                            ((HtmlGenericControl)entry.Key).InnerHtml = GetResourceValue("Resource", entry.Value.ToString(), "");
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }
    }
}