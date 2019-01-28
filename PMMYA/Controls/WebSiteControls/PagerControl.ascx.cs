using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class PagerControl : System.Web.UI.UserControl
    {

        /// <summary>
        /// Occurs when the pager linkbutton is clicked.
        /// </summary>
        public event EventHandler PagerControl_PageIndexChanged;

        protected void Page_Load(object sender, EventArgs e)
        {
            /// since the pagination link buttons are dynamic controls we need to recreate them after postback
            if (IsPostBack)
            {
                if (PageMode == LinkType.LinkButton)
                {
                    CreateLinkButtonPagination();
                }
            }
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets the offset of the pagination number
        /// </summary>
        public int IndexDisplayOffset
        {
            get { return ViewState["IndexDisplayOffset"] == null ? 1 : (int)ViewState["IndexDisplayOffset"]; }
            set { ViewState["IndexDisplayOffset"] = value; }
        }

        /// <summary>
        /// Gets or sets the mode of pagination buttons to render
        /// </summary>
        public LinkType PageMode
        {
            get { return ViewState["PageMode"] == null ? LinkType.HyperLink : (LinkType)ViewState["PageMode"]; }
            set { ViewState["PageMode"] = value; }
        }

        /// <summary>
        /// Gets or sets the total number of rows in the datasource
        /// </summary>
        public int TotalItems
        {
            get { return ViewState["TotalItems"] == null ? 0 : (int)ViewState["TotalItems"]; }
            set { ViewState["TotalItems"] = value; }
        }

        /// <summary>
        /// The number of items per page. The maximum number of pages is calculated by 
        /// dividing the number of items by items_per_page (rounded up, minimum 1). Default: 10
        /// </summary>
        public int PageSize
        {
            get { return ViewState["PageSize"] == null ? 10 : (int)ViewState["PageSize"]; }
            set { ViewState["PageSize"] = value; }
        }

        /// <summary>
        /// The page that is selected when the pagination is initialized. Default: 0
        /// </summary>
        public int CurrentPageIndex //made the paginator with start index from 0 and later changed to 1 - with this simple patch ;)
        {
            get { return _CurrentPageIndex + 1; }
            set { _CurrentPageIndex = value - 1; }
        }
        private int _CurrentPageIndex
        {
            get { return ViewState["CurrentPageIndex"] == null ? 0 : (int)ViewState["CurrentPageIndex"]; }
            set { ViewState["CurrentPageIndex"] = value; }
        }

        /// <summary>
        /// Maximum number of pagination links that are visible. Set to 0 to display a
        /// simple "Previous/Next"-Navigation. Default: 10
        /// </summary>
        public int DisplayEntriesCount
        {
            get { return ViewState["DisplayEntriesCount"] == null ? 10 : (int)ViewState["DisplayEntriesCount"]; }
            set { ViewState["DisplayEntriesCount"] = value; }
        }

        /// <summary>
        /// If this number is set to 1, links to the first and the last page are always shown
        /// , independent of the current position and the visibility constraints set by num_display_entries
        /// . You can set it to bigger numbers to show more links. Default is 2
        /// </summary>
        public int EdgeEntriesCount
        {
            get { return ViewState["EdgeEntriesCount"] == null ? 2 : (int)ViewState["EdgeEntriesCount"]; }
            set { ViewState["EdgeEntriesCount"] = value; }
        }

        /// <summary>
        /// Link target of the pagination links when the PageMode = HyperLink. Default: ?p=
        /// Priority goes for TargetLinkFormatString
        /// </summary>
        public string TargetLink
        {
            get { return ViewState["TargetLink"] == null ? "?p=" : ViewState["TargetLink"].ToString(); }
            set { ViewState["TargetLink"] = value; }
        }

        /// <summary>
        /// SEO friendly link target of the pagination links when the PageMode = HyperLink. Default is empty
        /// </summary>
        public string TargetLinkFormatString
        {
            get { return ViewState["TargetLinkFormat"] == null ? string.Empty : ViewState["TargetLinkFormat"].ToString(); }
            set { ViewState["TargetLinkFormat"] = value; }
        }

        /// <summary>
        /// Text for the "Previous"-link that decreases the current page number by 1. 
        /// Leave blank to hide the link. Default: « prev
        /// </summary>
        public string PreviousPageText
        {
            get { return ViewState["PreviousPageText"] == null ? "&laquo; prev" : ViewState["PreviousPageText"].ToString(); }
            set { ViewState["PreviousPageText"] = value; }
        }

        /// <summary>
        /// Text for the "Next"-link that increases the current page number by 1. 
        /// Leave blank to hide the link. Default: next »
        /// </summary>
        public string NextPageText
        {
            get { return ViewState["NextPageText"] == null ? "next &raquo;" : ViewState["NextPageText"].ToString(); }
            set { ViewState["NextPageText"] = value; }
        }

        /// <summary>
        /// When there is a gap between the numbers created by EdgeEntriesCount and the displayed number interval
        /// , this text will be inserted into the gap (inside a Label/span tag).
        /// </summary>
        public string EllipseText
        {
            get { return ViewState["EllipseText"] == null ? "..." : ViewState["EllipseText"].ToString(); }
            set { ViewState["EllipseText"] = value; }
        }

        /// <summary>
        /// Get or set the css class name for the pagination div. Default: 'pagination'
        /// </summary>
        public string CssClass
        {
            get { return pnlPager.Attributes["class"]; }
            set { pnlPager.Attributes["class"] = value; }
        }

        #endregion

        #region enums
        /// <summary>
        /// Specifies the types of buttons to render
        /// </summary>
        public enum LinkType
        {
            HyperLink, LinkButton
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Bind the data to a control and generate the pagination.
        /// </summary>
        /// <param name="bindControl">Type of DataList, Repeater, DataGrid or GridView</param>
        /// <param name="data">The datatable to bind</param>
        public void BindDataWithPaging(Control bindControl, DataTable data)
        {
            DataView dv = data.DefaultView;

            //saving the total items count in Viewstate for later use
            TotalItems = data.Rows.Count;

            PagedDataSource dsP = new PagedDataSource();
            dsP.AllowPaging = true;
            dsP.PageSize = PageSize;
            dsP.DataSource = dv;

            //current page index shld be set before calling this function - especially in the case of HyperLinks        
            //if the current pagfe index is greater than the number of pages availanble. make the current page index as the last page
            if (_CurrentPageIndex > dsP.PageCount - 1)
                _CurrentPageIndex = dsP.PageCount - 1;
            else if (_CurrentPageIndex < 0)
                _CurrentPageIndex = 0;
            dsP.CurrentPageIndex = _CurrentPageIndex;

            //Binding data to the controls
            if (bindControl is DataList)
                ((DataList)bindControl).DataSource = dsP;
            else if (bindControl is Repeater)
                ((Repeater)bindControl).DataSource = dsP;
            else if (bindControl is DataGrid)
                ((DataGrid)bindControl).DataSource = dsP;
            else if (bindControl is GridView)
                ((GridView)bindControl).DataSource = dsP;
            else if (bindControl is ListView)
                ((ListView)bindControl).DataSource = dsP;

            bindControl.DataBind();

            CreatePagination();
        }

        /// <summary>
        /// Create the pagination as per the TotalItems available and the PageSize
        /// Call this function directly after setting TotalItems and PagSize if you want to generate the pagination without binding data to a specific control
        /// </summary>
        public void CreatePagination()
        {
            if (TotalPages() > 1)
            {
                this.Visible = true;
                if (PageMode == LinkType.HyperLink)
                    CreateHyperLinkPagination();
                else
                    CreateLinkButtonPagination();
            }
            else
            {
                this.Visible = false;
            }
        }

        /// <summary>
        /// Function to calculate the total number of pages depending on TotalItems and PageSize
        /// </summary>
        public int TotalPages()
        {
            return int.Parse(Math.Ceiling(decimal.Parse(TotalItems.ToString())
                / decimal.Parse(PageSize.ToString())).ToString());
        }

        #endregion

        #region CreateHyperLinkPagination
        //create the pagination as Hyperlinks
        private void CreateHyperLinkPagination()
        {
            string ellipses = "<li class=\"plain\">" + EllipseText + "</li>";

            //this string builder will hold the pagination string and later we will add this to a div 
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            //finidng the central postion of display entries. The current page will be shown in the center
            int ne_half = int.Parse(Math.Ceiling(decimal.Parse(DisplayEntriesCount.ToString()) / 2).ToString());
 
            //retrieving the number of pages
            int np = TotalPages();

            int upper_limit = np - DisplayEntriesCount;

            //finding the start position
            int start = _CurrentPageIndex > ne_half ? Math.Max(Math.Min(_CurrentPageIndex - ne_half, upper_limit), 0) : 0;

            //finding the end position
            int end = _CurrentPageIndex > ne_half ? Math.Min(_CurrentPageIndex + ne_half, np) : Math.Min(DisplayEntriesCount, np);

            // Begin by creating the 'Previous' Link 
            if (PreviousPageText.Length > 0)
            {
                sb.Append(CreateLink(_CurrentPageIndex - 1, PreviousPageText, _CurrentPageIndex == 0 ? "disabled" : "")).Append(System.Environment.NewLine);
            }

            // Generate begining edge entries - The first EdgeEntriesCount of page links will be generated 
            if (start > 0 && EdgeEntriesCount > 0)
            {
                //till where the edge entries created
                int edgeEnd = Math.Min(EdgeEntriesCount, start);
                for (int i = 0; i < edgeEnd; i++)
                {
                    sb.Append(CreateLink(i, (i + 1).ToString(), "")).Append(System.Environment.NewLine);
                }
                //if there is a gap between edge entries and start,, ellipse text will be shown bw them
                if (EdgeEntriesCount < start && EllipseText.Length > 0)
                {
                    sb.Append(ellipses).Append(System.Environment.NewLine);
                }
            }

            // Generate interval links - the pagination links based on DisplayEntriesCount will generated here
            //links will be printed from the calculated start and end values
            for (int i = start; i < end; i++)
            {
                sb.Append(CreateLink(i, (i + 1).ToString(), "")).Append(System.Environment.NewLine);
            }

            // Generate ending edge entries - The final EdgeEntriesCount of page links will be generated 
            if (end < np && EdgeEntriesCount > 0)
            {
                //if there is a gap between end link and edge entries the EllipseText will be shown
                if (np - EdgeEntriesCount > end && EllipseText.Length > 0)
                {
                    sb.Append(ellipses).Append(System.Environment.NewLine);
                }

                //from where the edge entries should start
                int begin = Math.Max(np - EdgeEntriesCount, end);
                for (int i = begin; i < np; i++)
                {
                    sb.Append(CreateLink(i, (i + 1).ToString(), "")).Append(System.Environment.NewLine);
                }
            }

            // Finish the pagination with 'Next' Link
            if (NextPageText.Length > 0)
            {
                sb.Append(CreateLink(_CurrentPageIndex + 1, NextPageText, _CurrentPageIndex == end - 1 ? "disabled" : "")).Append(System.Environment.NewLine);
            }

            pnlPager.InnerHtml = sb.ToString();
        }

        // Helper function for generating a single link (or a span tag if it's the current page)
        string CreateLink(int pageNumber, string displayText, string className)
        {
            string link = "";
            //retrive total number of pages available
            int np = TotalPages();

            //if the passed value is < 0 set it as zero.. else if the passed value is greater than total pages set it as total pages - 1
            pageNumber = pageNumber < 0 ? 0 : (pageNumber < np ? pageNumber : np - 1);

            //if its the current page make it a span
            if (pageNumber == _CurrentPageIndex)
            {
                //if no class name is passed, set current as class name
                link = string.Format("<li class='{0}'>{1}</li>"
                    , className.Length > 0 ? className : "current"
                    , displayText);
            }
            else //make it as a link
            {
                if (TargetLinkFormatString.Length > 0) //if SEO friendly page target is specified - use it
                {
                    link = string.Format(TargetLinkFormatString, pageNumber + IndexDisplayOffset);
                    link = string.Format("<li><a href='{0}'>{1}</a></li>", link, displayText);
                }
                else
                    link = string.Format("<li><a href='{0}{1}'>{2}</a></li>", TargetLink, pageNumber + IndexDisplayOffset, displayText);

            }

            return link;
        }
        #endregion

        #region CreateLinkButtonPagination

        //create the pagination as LinkButtons
        private void CreateLinkButtonPagination()
        {
            pnlPager.Controls.Clear();

            //finidng the central postion of display entries. The current page will be shown in the center
            int ne_half = int.Parse(Math.Ceiling(decimal.Parse(DisplayEntriesCount.ToString()) / 2).ToString());

            //retrieving the number of pages
            int np = TotalPages();

            int upper_limit = np - DisplayEntriesCount;

            //finding the start position of the main pager strip
            int start = _CurrentPageIndex > ne_half ? Math.Max(Math.Min(_CurrentPageIndex - ne_half, upper_limit), 0) : 0;

            //finding the end position of the main pager strip
            int end = _CurrentPageIndex > ne_half ? Math.Min(_CurrentPageIndex + ne_half, np) : Math.Min(DisplayEntriesCount, np);

            // Begin by creating the 'Previous' Link 
            if (PreviousPageText.Length > 0)
                CreateButton(_CurrentPageIndex - 1, PreviousPageText, _CurrentPageIndex == 0 ? "disabled" : "");

            // Generate begining edge entries - The first EdgeEntriesCount of page links will be generated 
            if (start > 0 && EdgeEntriesCount > 0)
            {
                //till where the edge entries created
                int edgeEnd = Math.Min(EdgeEntriesCount, start);
                for (int i = 0; i < edgeEnd; i++)
                {
                    CreateButton(i, (i + 1).ToString(), "");
                }
                //if there is a gap between edge entries and start,, ellipse text will be shown bw them
                if (EdgeEntriesCount < start && EllipseText.Length > 0)
                {
                    CreateLabel(EllipseText, "plain");
                }
            }

            // Generate interval links - the pagination links based on DisplayEntriesCount will generated here
            //links will be printed from the calculated start and end values
            for (int i = start; i < end; i++)
            {
                CreateButton(i, (i + 1).ToString(), "");
            }

            // Generate ending edge entries - The final EdgeEntriesCount of page links will be generated 
            if (end < np && EdgeEntriesCount > 0)
            {
                //if there is a gap between end link and edge entries the EllipseText will be shown
                if (np - EdgeEntriesCount > end && EllipseText.Length > 0)
                {
                    CreateLabel(EllipseText, "plain");
                }

                //from where the edge entries should start
                int begin = Math.Max(np - EdgeEntriesCount, end);
                for (int i = begin; i < np; i++)
                {
                    CreateButton(i, (i + 1).ToString(), "");
                }
            }

            // Finish the pagination with 'Next' Link
            if (NextPageText.Length > 0)
                CreateButton(_CurrentPageIndex + 1, NextPageText, _CurrentPageIndex == end - 1 ? "disabled" : "");

        }

        private void CreateButton(int pageNumber, string displayText, string className)
        {
            //retrive total number of pages available
            int np = TotalPages();

            //if the passed value is < 0 set it as zero.. else if the passed value is greater than total pages set it as total pages - 1
            pageNumber = pageNumber < 0 ? 0 : (pageNumber < np ? pageNumber : np - 1);

            //if its the current page make it a Label
            if (pageNumber == _CurrentPageIndex)
            {
                //if no class name is passed, set current as class name
                CreateLabel(displayText, className.Length > 0 ? className : "current");
            }
            else //make it as a linkbutton
            {
                CreateLinkButton(displayText, pageNumber);
            }
        }

        private void CreateLinkButton(string title, int index)
        {
            Literal litNewLine = new Literal();
            litNewLine.Text = System.Environment.NewLine;
            pnlPager.Controls.Add(litNewLine);

            LinkButton lnk = new LinkButton();

            if (title == PreviousPageText)
                lnk.ID = "-1";
            else if (title == NextPageText)
                lnk.ID = TotalItems.ToString();
            else
                lnk.ID = index.ToString();

            lnk.Text = title;
            lnk.CommandArgument = index.ToString();
            lnk.Click += new EventHandler(lnkPager_Click);
            HtmlGenericControl li = new HtmlGenericControl("li");
            li.Controls.Add(lnk);

            pnlPager.Controls.Add(li);
        }

        private void CreateLabel(string title, string cssClass)
        {
            Literal litNewLine = new Literal();
            litNewLine.Text = System.Environment.NewLine;
            pnlPager.Controls.Add(litNewLine);

            Label lbl = new Label();
            lbl.ID = System.Guid.NewGuid().ToString("N");
            lbl.Text = title;
            HtmlGenericControl li = new HtmlGenericControl("li");
            li.Attributes.Add("class", cssClass);
            li.Controls.Add(lbl);

            pnlPager.Controls.Add(li);
        }

        protected void lnkPager_Click(object sender, EventArgs e) //Page index changed function
        {
            LinkButton lnk = (LinkButton)sender;
            _CurrentPageIndex = int.Parse(lnk.CommandArgument);

            if (PagerControl_PageIndexChanged != null)
                PagerControl_PageIndexChanged(this, e);

        }

        #endregion
    }
}