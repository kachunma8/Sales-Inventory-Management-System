using InventoryStore.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryStore
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["ProductId"] != null ? Request.QueryString["ProductId"].ToString() : "0";
            hdnProductId.Value = id;

            if (!Page.IsPostBack)
                LoadDropdowns();
        }

        public void LoadDropdowns()
        {
            InventoryBL bl = new InventoryBL();
            var supplier = bl.GetSuppliers(0);
            var categories = bl.GetCategories();
            var brands = bl.GetBrands();
            var stores = bl.GetStores();

            ddlSupplier.Items.Add(new ListItem("Select", "0"));
            ddlCategory.Items.Add(new ListItem("Select", "0"));
            ddlBrand.Items.Add(new ListItem("Select", "0"));
            ddlStore.Items.Add(new ListItem("Select", "0"));

            foreach (var sup in supplier)
            {
                ddlSupplier.Items.Add(new ListItem(bl.GetPropertyValue(sup, "Supplier_Name"), bl.GetPropertyValue(sup, "Supplier_Id")));
            }
            foreach (var item in categories)
            {
                ddlCategory.Items.Add(new ListItem(bl.GetPropertyValue(item, "Category_Name"), bl.GetPropertyValue(item, "Category_Id")));
            }
            foreach (var item in brands)
            {
                ddlBrand.Items.Add(new ListItem(bl.GetPropertyValue(item, "Brand_Name"), bl.GetPropertyValue(item, "Brand_Id")));
            }
            foreach (var item in stores)
            {
                ddlStore.Items.Add(new ListItem(bl.GetPropertyValue(item, "Store_Name"), bl.GetPropertyValue(item, "Store_Id")));
            }

        }

        protected void btnSaveProduct_Click(object sender, EventArgs e)
        {
            InventoryBL bl = new InventoryBL();
            tbl_Products product = new tbl_Products()
            {
                Product_ID = Convert.ToInt32(hdnProductId.Value),
                Product_Name = txtProductName.Text,
                SKU = txtSKU.Text,
                Supplier_Id = Convert.ToInt32(ddlSupplier.SelectedValue),
                Category_Id = Convert.ToInt32(ddlCategory.SelectedValue),
                Brand_Id = Convert.ToInt32(ddlBrand.SelectedValue),
                Store_Id = Convert.ToInt32(ddlStore.SelectedValue),
                Product_Description = txtDescription.Text,
                Product_Quantity = Convert.ToInt32(txtQuantity.Text),
                Price = Convert.ToInt32(txtPrice.Text),
                ExpiryDate = !string.IsNullOrEmpty(txtExpiryDate.Text) ? Convert.ToDateTime(txtExpiryDate.Text) : DateTime.MaxValue,
                Availability = Convert.ToBoolean(ddlActive.SelectedValue)
            };

            //if (!bl.ValidateProduct(product))
            //{
            bool result = bl.SaveProduct(product);
            if (result == true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "product error", "alert('Product Saved successfully!');", true);
                Response.Redirect("products.aspx");
            }
            // }


        }

        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int supplierId = Convert.ToInt32(ddlSupplier.SelectedItem.Value);
            //if (supplierId > 0)
            //{
            //    InventoryBL bl = new InventoryBL();
            //    var supplier = bl.GetSuppliers(supplierId);
            //    if (supplier.Any())
            //    {

            //    }
            //}
        }
    }
}