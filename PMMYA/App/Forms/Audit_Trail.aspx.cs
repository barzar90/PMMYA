using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using BL;

namespace PMMYA.App.Forms
{
    public partial class Audit_Trail : System.Web.UI.Page
    {
        #region Public variable declaration
        DataSet ds;
        AuditTrailBL objAuditTrailBL = new AuditTrailBL();
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                Get_User_Listing();
            }
        }

        public DataSet Get_User_Listing()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = objAuditTrailBL.GetAuditTrail();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdUserListing.DataSource = ds.Tables[0];
                    grdUserListing.DataBind();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {

            }
            return ds;
        }

        protected void grdUserListing_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUserListing.PageIndex = e.NewPageIndex;
            Get_User_Listing();
        }

        protected void grdUserListing_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdUserListing_RowCreated(object sender, GridViewRowEventArgs e)
        {
          
        }
    }
}