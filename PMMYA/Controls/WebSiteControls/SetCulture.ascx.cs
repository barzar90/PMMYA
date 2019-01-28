using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class SetCulture : System.Web.UI.UserControl
    {

        public LinkButton MAHAITCurrentCultureID;

        public event EventHandler ButtonClickedLarger;
        public event EventHandler ButtonClickedLarge;
        public event EventHandler ButtonClickedMedium;
        public event EventHandler ButtonClickedSmall;
        public event EventHandler ButtonClickedSmallest;
        public event EventHandler ButtonClickedABlack;
        public event EventHandler ButtonClickedAWhite;
        public event EventHandler ButtonClickedCultureSheet;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btn_Larger_Click1(object sender, EventArgs e)
        {
            HttpContext.Current.Profile.SetPropertyValue("FontLevel", "larger");
            RaiseButtonClickBrightest(sender, e);
        }

        public void RaiseButtonClickBrightest(object sender, EventArgs e)
        {
            if (ButtonClickedLarger != null)
            {
                ButtonClickedLarger(sender, e);
            }
        }

        //protected void btn_Large_Click(object sender, EventArgs e)
        //{
        //    HttpContext.Current.Profile.SetPropertyValue("FontLevel", "large");
        //    RaiseButtonClickLarge(sender, e);
        //}

        public void RaiseButtonClickLarge(object sender, EventArgs e)
        {
            if (ButtonClickedLarge != null)
            {
                ButtonClickedLarge(sender, e);
            }
        }

        protected void btn_Medium_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Profile.SetPropertyValue("FontLevel", "medium");
            RaiseButtonClickMedium(sender, e);
        }

        public void RaiseButtonClickMedium(object sender, EventArgs e)
        {
            if (ButtonClickedMedium != null)
            {
                ButtonClickedMedium(sender, e);
            }
        }

        protected void btn_Small_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Profile.SetPropertyValue("FontLevel", "small");
            RaiseButtonClickSmall(sender, e);
        }

        public void RaiseButtonClickSmall(object sender, EventArgs e)
        {
            if (ButtonClickedSmall != null)
            {
                ButtonClickedSmall(sender, e);
            }
        }

        //protected void btn_Smallest_Click(object sender, EventArgs e)
        //{
        //    HttpContext.Current.Profile.SetPropertyValue("FontLevel", "smaller");
        //    RaiseButtonClickSmallest(sender, e);
        //}

        public void RaiseButtonClickSmallest(object sender, EventArgs e)
        {
            if (ButtonClickedSmallest != null)
            {
                ButtonClickedSmallest(sender, e);
            }
        }

        protected void btnABlack_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Profile.SetPropertyValue("ColorLevel", @"../../Styles/LayoutBlack.css");
            RaiseButtonClickBlack(sender, e);
        }

        public void RaiseButtonClickBlack(object sender, EventArgs e)
        {
            if (ButtonClickedABlack != null)
            {
                ButtonClickedABlack(sender, e);
            }
        }

        protected void btnAWhite_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Profile.SetPropertyValue("ColorLevel", @"../../Styles/Layout.css");
            RaiseButtonClickAWhite(sender, e);
        }

        public void RaiseButtonClickAWhite(object sender, EventArgs e)
        {
            if (ButtonClickedAWhite != null)
            {
                ButtonClickedAWhite(sender, e);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //if (LinkButton1.Text == "मराठी")
            //{
            //    LinkButton1.Text = "English";
            //    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("mr-IN");
            //    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("mr-IN");
            //    HttpContext.Current.Profile.SetPropertyValue("Selectedlanguage", "mr-IN");
            //}
            //else
            //{
            //    LinkButton1.Text = "मराठी";
            //    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-IN");
            //    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-IN");
            //    HttpContext.Current.Profile.SetPropertyValue("Selectedlanguage", "en-IN");
            //}
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {

            //Added By K.P on 21-05-2018
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "en-IN")
            {
                btn_Language.Text = "मराठी";
                DDL_Language.SelectedValue = "English";
            }
            else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "mr-IN")
            {
                btn_Language.Text = "English";
                DDL_Language.SelectedValue = "मराठी";
            }
            else
            {
                DDL_Language.SelectedValue = "हिन्दी";
            }

            MAHAITUserControl _MAHAITUC = new MAHAITUserControl();          
            btn_Language.Text = _MAHAITUC.GetResourceValue("Common", "btn_Language", "");
            btn_Larger.ToolTip = _MAHAITUC.GetResourceValue("Common", "btn_LargerToolTip", "");
            //btn_Large.ToolTip = _MAHAITUC.GetResourceValue("Common", "btn_LargeToolTip", "");
            btn_Medium.ToolTip = _MAHAITUC.GetResourceValue("Common", "btn_MediumToolTip", "");
            //btn_Small.ToolTip = _MAHAITUC.GetResourceValue("Common", "btn_SmallToolTip", "");
            btn_Smallest.ToolTip = _MAHAITUC.GetResourceValue("Common", "btn_SmallestToolTip", "");
            btnAWhite.ToolTip = _MAHAITUC.GetResourceValue("Common", "btnAWhiteToolTip", ""); ;
            btnABlack.ToolTip = _MAHAITUC.GetResourceValue("Common", "btnABlackToolTip", ""); ;


            btn_Larger.Text = _MAHAITUC.GetResourceValue("Common", "btn_Larger", "");
           // btn_Large.Text = _MAHAITUC.GetResourceValue("Common", "btn_Large", "");
            btn_Medium.Text = _MAHAITUC.GetResourceValue("Common", "btn_Medium", "");
           // btn_Small.Text = _MAHAITUC.GetResourceValue("Common", "btn_Small", "");
            btn_Smallest.Text = _MAHAITUC.GetResourceValue("Common", "btn_Smallest", "");
            btnABlack.Text = _MAHAITUC.GetResourceValue("Common", "btnABlack", "");
            btnAWhite.Text = _MAHAITUC.GetResourceValue("Common", "btnAWhite", "");
        }


        protected void btn_Language_Click(object sender, EventArgs e)
        {
            PMMYA.PublicApp.API.MAHAITAPI.SetCulture(btn_Language.Text);

            RaiseButtonClickedCultureSheet(sender, e);

        }
        public void RaiseButtonClickedCultureSheet(object sender, EventArgs e)
        {
            if (ButtonClickedCultureSheet != null)
            {
                ButtonClickedCultureSheet(sender, e);
            }
        }

        protected void DDL_Language_SelectedIndexChanged(object sender, EventArgs e)
        {

            PMMYA.PublicApp.API.MAHAITAPI.SetCulture(DDL_Language.SelectedValue);

            RaiseButtonClickedCultureSheet(sender, e);
        }
    }
}