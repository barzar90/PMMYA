using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace PMMYA
{
    public partial class demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        private void BindGrid()
        {
            gvProducts.DataSource = GetUserProductOrder();
            gvProducts.DataBind();
        }

        protected void gvProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProducts.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProducts.EditIndex = -1;
            BindGrid();
        }

        protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlMake = (DropDownList)e.Row.FindControl("ddlProductMake");
                    ddlMake.DataSource = GetProductMakes();
                    ddlMake.DataValueField = "ProductMakeID";
                    ddlMake.DataTextField = "Make";
                    ddlMake.DataBind();

                    ddlMake.SelectedValue = gvProducts.DataKeys[e.Row.RowIndex].Value.ToString();

                    DropDownList ddlModel = (DropDownList)e.Row.FindControl("ddlProductModel");
                    ddlModel.DataSource = GetProductModelByMake(Convert.ToInt32(gvProducts.DataKeys[e.Row.RowIndex].Value));
                    ddlModel.DataValueField = "ProductModelID";
                    ddlModel.DataTextField = "Model";
                    ddlModel.DataBind();

                    ddlModel.SelectedValue = GetProductModelByMake(Convert.ToInt32(gvProducts.DataKeys[e.Row.RowIndex].Value))
                                             .FirstOrDefault().ProductModelID.ToString();

                }
            }
        }

        protected void ddlProductMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlMake = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlMake.NamingContainer;
            if (row != null)
            {
                if ((row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlModel = (DropDownList)row.FindControl("ddlProductModel");
                    ddlModel.DataSource = GetProductModelByMake(Convert.ToInt32(ddlMake.SelectedValue));
                    ddlModel.DataValueField = "ProductModelID";
                    ddlModel.DataTextField = "Model";
                    ddlModel.DataBind();
                }
            }
        }

        protected void ddlProductModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlModel = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlModel.NamingContainer;
            if (row != null)
            {
                if ((row.RowState & DataControlRowState.Edit) > 0)
                {
                    row.Cells[3].Text = string.Format("{0:C}", GetProductModels()
                                        .Where(o => o.ProductModelID == Convert.ToInt32(ddlModel.SelectedValue))
                                        .FirstOrDefault().Price);
                }
            }
        }


        //grid bind data
        private List<ProductOrder> GetUserProductOrder()
        {
            List<ProductOrder> orders = new List<ProductOrder>();
            ProductOrder po = new ProductOrder
            {
                ProductOrderID = 1,
                ProductMakeID = 1,
                ProductModelID = 1,
                Make = "Apple",
                Model = "iPhone 4",
                Quantity = 2,
                Price = 499
            };
            orders.Add(po);

            po = new ProductOrder
            {
                ProductOrderID = 2,
                ProductMakeID = 2,
                ProductModelID = 4,
                Make = "Samsung",
                Model = "Galaxy S2",
                Quantity = 1,
                Price = 449
            };
            orders.Add(po);

            po = new ProductOrder
            {
                ProductOrderID = 3,
                ProductMakeID = 3,
                ProductModelID = 7,
                Make = "Nokia",
                Model = "Lumia",
                Quantity = 1,
                Price = 549
            };
            orders.Add(po);

            return orders;

        }

        private List<ProductMake> GetProductMakes()
        {

            List<ProductMake> products = new List<ProductMake>();
            ProductMake p = new ProductMake
            {
                ProductMakeID = 1,
                Make = "Apple"
            };
            products.Add(p);

            p = new ProductMake
            {
                ProductMakeID = 2,
                Make = "Samsung"
            };
            products.Add(p);

            p = new ProductMake
            {
                ProductMakeID = 3,
                Make = "Nokia"
            };
            products.Add(p);

            return products;
        }

        private List<ProductModel> GetProductModels()
        {
            List<ProductModel> productModels = new List<ProductModel>();
            ProductModel pm = new ProductModel
            {
                ProductMakeID = 1,
                ProductModelID = 1,
                Model = "iPhone 4",
                Price = 499
            };
            productModels.Add(pm);

            pm = new ProductModel
            {
                ProductMakeID = 1,
                ProductModelID = 2,
                Model = "iPhone 4s",
                Price = 599
            };
            productModels.Add(pm);

            pm = new ProductModel
            {
                ProductMakeID = 1,
                ProductModelID = 3,
                Model = "iPhone 5",
                Price = 699
            };
            productModels.Add(pm);

            pm = new ProductModel
            {
                ProductMakeID = 2,
                ProductModelID = 4,
                Model = "Galaxy S2",
                Price = 449
            };
            productModels.Add(pm);

            pm = new ProductModel
            {
                ProductMakeID = 2,
                ProductModelID = 5,
                Model = "Galaxy S3",
                Price = 549
            };
            productModels.Add(pm);

            pm = new ProductModel
            {
                ProductMakeID = 2,
                ProductModelID = 6,
                Model = "Galaxy Note2",
                Price = 619
            };
            productModels.Add(pm);

            pm = new ProductModel
            {
                ProductMakeID = 3,
                ProductModelID = 7,
                Model = "Nokia Lumia",
                Price = 659
            };
            productModels.Add(pm);

            return productModels;

        }

        private List<ProductModel> GetProductModelByMake(int productMakeID)
        {
            IEnumerable<ProductModel> models = (from p in GetProductModels()
                                                where p.ProductMakeID == productMakeID
                                                select p);

            return models.ToList();
        }
    }
}

public class ProductMake
{
    public int ProductMakeID { get; set; }
    public string Make { get; set; }
}
public class ProductModel
{
    public int ProductModelID { get; set; }
    public int ProductMakeID { get; set; }
    public string Model { get; set; }
    public decimal Price { get; set; }
}
public class ProductOrder
{
    public int ProductOrderID { get; set; }
    public int ProductMakeID { get; set; }
    public int ProductModelID { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public short Quantity { get; set; }
    public decimal Price { get; set; }
}

