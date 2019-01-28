using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Collections.Specialized;
using BL;

namespace PMMYA.WebServices.Address
{
    /// <summary>
    /// Summary description for Address
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class Address : MAHAITWebServices
    {
        
        public Address()
        {
            
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        
        [WebMethod()]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] BindDistrict(string knownCategoryValues, string category)
        {
            DataTable t_DT = MAHAITDBAccess.GetDistricts();
            List<AjaxControlToolkit.CascadingDropDownNameValue> Districtdetails = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            foreach (DataRow dtrow in t_DT.Rows)
            {
                string DistrictCode = dtrow["DistrictCode"].ToString();
                string Districtname = dtrow["Districtname"].ToString();
                Districtdetails.Add(new AjaxControlToolkit.CascadingDropDownNameValue(Districtname, DistrictCode));
            }
            return Districtdetails.ToArray();
        }




        [WebMethod()]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] BindSubDistrict(string knownCategoryValues, string category)
        {
            List<AjaxControlToolkit.CascadingDropDownNameValue> SubDistrictDetails = new List<AjaxControlToolkit.CascadingDropDownNameValue>();            
            
            string DistrictCode = "";
            //undefined: 520;
            var str = knownCategoryValues.Split(':');
            knownCategoryValues = "DistrictCode:" + str[1];
            DistrictCode = str[1].ToString().Substring(0, str[1].ToString().Length - 1);

            StringDictionary District = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

            DataTable t_DT = null;
            t_DT = MAHAITDBAccess.GetSubDistricts(DistrictCode);
            foreach (DataRow dtstaterow in t_DT.Rows)
            {
                string Subdistrictcode = dtstaterow["Subdistrictcode"].ToString();
                string SubDistrictname = dtstaterow["SubDistrictname"].ToString();
                SubDistrictDetails.Add(new AjaxControlToolkit.CascadingDropDownNameValue(SubDistrictname, Subdistrictcode));
            }
             
            return SubDistrictDetails.ToArray();            
        }

        
        [WebMethod()]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] BindVillage(string knownCategoryValues, string category)
        {
            List<AjaxControlToolkit.CascadingDropDownNameValue> VillageDetails = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            
            string SubDistrictCode = "";
            var str = knownCategoryValues.Split(':');
            StringDictionary SubDistrict = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            if (str[0].ToString() != "undefined")
            {
                knownCategoryValues = "SubDistrictCode:" + str[2];
                SubDistrictCode = str[2].ToString().Substring(0, str[2].ToString().Length - 1);
            }
            else
            {
                knownCategoryValues = "SubDistrictCode:" + str[1];
                SubDistrictCode = str[1].ToString().Substring(0, str[1].ToString().Length - 1);
            }

            DataTable t_DT = null;
            t_DT = MAHAITDBAccess.GetVillages(SubDistrictCode);
            foreach (DataRow dtstaterow in t_DT.Rows)
            {
                string Villagecode = dtstaterow["Villagecode"].ToString();
                string Villagename = dtstaterow["Villagename"].ToString();
                VillageDetails.Add(new AjaxControlToolkit.CascadingDropDownNameValue(Villagename, Villagecode));
            }
            
            return VillageDetails.ToArray();
        }
        
    }
}
