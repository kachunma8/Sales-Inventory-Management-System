using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryStore.DL.Entities
{
    public class CustomerProducts
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public List<Products> Products { get; set; }
    }

    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public decimal Amount { get; set; }
        public decimal Gross { get; set; }
        public decimal SCharge { get; set; }
        public decimal Vat { get; set; }
        public decimal NetAmount { get; set; }
    }
    public class ProductsNotifications
    {
        public List<tbl_Orders> Orders { get; set; }
        public List<tbl_Supplier> Suppliers { get; set; }

        public List<tbl_Products> Products { get; set; }
    }
}
