using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using BL;
using Schema;
using System.Configuration;
using System.Security.Cryptography;

namespace PMMYA
{
    public partial class Default : MAHAITPage 
    {
        #region Public variable declaration
        MenuSchema objMenuSchema = new MenuSchema();
        MenuBL objMenuBL = new MenuBL();
        DataSet ds;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
          //  string connstr = DecryptText(System.Configuration.ConfigurationManager.ConnectionStrings[ConfigurationSettings.AppSettings["APPID"].ToString()].ToString(), "SilverAmreli");



            objMenuSchema.MenuName = "Home";
            ds = objMenuBL.GetMenuDetails(objMenuSchema);

            if (ds.Tables[0].Rows.Count > 0)
            {
                String strHomePageLink = HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty) + "/" + Convert.ToString(ds.Tables[0].Rows[0]["MenuID"]) + "/";
                strHomePageLink += Convert.ToString(ds.Tables[0].Rows[0]["MenuName"]).TrimStart().TrimEnd().Replace(" ", "-");
                Response.Redirect(HttpUtility.UrlDecode(strHomePageLink, System.Text.Encoding.UTF8));
            }
            else
            {
                Response.Redirect("~/Site/Home/Index.aspx");
            }
        }

        #region "Decrypt Connection String"
        private static string DecryptText(string Text, string Key)
        {
            return Decrypt(Text, Key);
        }

        /// <summary>
        /// Decrypts the specified STR text.
        /// </summary>
        /// <param name="strText">The STR text.</param>
        /// <param name="sDecrKey">The s decr key.</param>
        /// <returns>Representing Decrypted Text</returns>
        /// <remarks></remarks>
        private static string Decrypt(string strText, string sDecrKey)
        {
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] inputByteArray = new byte[strText.Length + 1];

            byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }

        #endregion
    }
}