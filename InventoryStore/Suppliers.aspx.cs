using InventoryStore.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryStore
{
    public partial class Suppliers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static dynamic GetSuppliers()
        {
            InventoryBL bl = new InventoryBL();
            var result = bl.GetSuppliers(0);
            return result;
        }

        [WebMethod]
        public static bool SaveSupplier(string id, string name, string serviceCharge, string vat, string phone, string address, string country, string message, string currency)
        {
            InventoryBL bl = new InventoryBL();
            tbl_Supplier supplier = new tbl_Supplier()
            {
                Supplier_Id = Convert.ToInt32(id),
                Supplier_Name = name,
                Service_Charge_Value = serviceCharge,
                Vat_Charge_Value = vat,
                Phone = phone,
                Address = address,
                Country = country,
                Message = message,
                Currency = currency
            };
            if (!bl.ValidateSupplier(supplier))
            {
                bool result = bl.SaveSupplier(supplier);
                return result;
            }
            return false;
        }

        [WebMethod]
        public static bool DeleteSupplier(string id)
        {
            InventoryBL bl = new InventoryBL();
            bool result = bl.DeleteSupplier(Convert.ToInt32(id));
            return result;
        }
    }
}