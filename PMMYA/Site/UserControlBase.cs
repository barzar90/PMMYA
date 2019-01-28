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


namespace PMMYA.Site
{
    public class UserControlBase : System.Web.UI.UserControl
    {
        public void SetUICulture(Hashtable controls)
        {
            string cultureName = null;
            try
            {
                cultureName = (string)Session["CurrentCulture"];
                Page.UICulture = cultureName;

                foreach (DictionaryEntry entry in controls)
                {
                    switch (entry.Key.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.Button":
                            ((Button)entry.Key).Text = GetGlobalResourceObject("Resource", entry.Value.ToString()).ToString();
                            break;
                        case "System.Web.UI.WebControls.Label":
                            ((Label)entry.Key).Text = GetGlobalResourceObject("Resource", entry.Value.ToString()).ToString();
                            break;
                        case "System.Web.UI.RadioButtonList":
                            ((RadioButtonList)entry.Key).Text = GetGlobalResourceObject("Resource", entry.Value.ToString()).ToString();
                            break;
                        case "System.Web.UI.RadioButton":
                            ((RadioButton)entry.Key).Text = GetGlobalResourceObject("Resource", entry.Value.ToString()).ToString();
                            break;
                        case "System.Web.UI.WebControls.LinkButton":
                            ((LinkButton)entry.Key).Text = GetGlobalResourceObject("Resource", entry.Value.ToString()).ToString();
                            break;
                        case "System.Web.UI.WebControls.DataControlFieldHeaderCell":
                            ((DataControlFieldHeaderCell)entry.Key).Text = GetGlobalResourceObject("Resource", entry.Value.ToString()).ToString();
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