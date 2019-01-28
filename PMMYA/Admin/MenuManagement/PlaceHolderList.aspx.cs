using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using BL;
using Schema;

namespace PMMYA.Admin.MenuManagement
{
    public partial class PlaceHolderList : System.Web.UI.Page
    {
        #region Public variable declaration
       // BL.BL MAHAITDBAccess;
        DataTable dt;
        DataSet ds;
        PlaceHolderSchema objPlaceHolderSchema = new PlaceHolderSchema();
        PlaceholderBAL objPlaceholderBL = new PlaceholderBAL();
        #endregion

        protected void Page_InIt(object sender, EventArgs e)
        {
            //MAHAITDBAccess = ((MAHAITMasterPage)this.Master).MAHAITDBAccess;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            try
            {
                ds = objPlaceholderBL.GetPlaceHolderList();
                dt = ds.Tables[0];

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        GV_MenuContentList.DataSource = dt.DefaultView;
                        GV_MenuContentList.DataBind();
                    }
                    else
                    {
                        GV_MenuContentList.DataSource = null;
                        GV_MenuContentList.DataBind();
                    }
                }
                else
                {
                    GV_MenuContentList.DataSource = null;
                    GV_MenuContentList.DataBind();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        protected void GV_MenuContentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                try
                {
                    objPlaceHolderSchema.PlaceholderId= Convert.ToInt32(e.CommandArgument);
                    int count = objPlaceholderBL.DMLPlaceHolderList(objPlaceHolderSchema);
                    if (count != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Record Deleted Successfully !!!');", true);
                        BindGridView();
                    }
                    else
                    { ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Error!!!');", true); }
                }
                catch (Exception ex)
                { throw ex; }
            }
        }

        protected void GV_MenuContentList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void GV_MenuContentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_MenuContentList.PageIndex = e.NewPageIndex;
            GV_MenuContentList.DataBind();
            BindGridView();
        }


    }
}