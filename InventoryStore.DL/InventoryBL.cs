using InventoryStore.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryStore.DL
{
    public class InventoryBL : IInventoryStore
    {
        InventoryDL dl;

        public InventoryBL()
        {
            dl = new InventoryDL();
        }

        public bool SaveOrder(tbl_Orders orders)
        {
            return dl.SaveOrder(orders);
        }
        public bool SaveProduct(tbl_Products product)
        {
            return dl.SaveProduct(product);
        }
        public bool SaveBrand(tbl_Brands brand)
        {
            return dl.SaveBrand(brand);
        }

        public bool DeleteBrand(int id)
        {
            return dl.DeleteBrand(id);
        }

        public bool SaveCategory(tbl_Categories category)
        {
            return dl.SaveCategory(category);
        }

        public bool SaveStore(tbl_Stores store)
        {
            return dl.SaveStore(store);
        }

        public bool SaveSupplier(tbl_Supplier supplier)
        {
            return dl.SaveSupplier(supplier);
        }

        public bool SaveUser(tbl_Users user)
        {
            return dl.SaveUser(user);
        }

        public dynamic GetOrders(int userId, int groupId)
        {
            return dl.GetOrders(userId, groupId).Select(x => new
            {
                Order_Id = x.Order_Id,
                Customer_Name = x.Customer_Name,
                Product_Name = x.tbl_Products != null ? x.tbl_Products.Product_Name : "",
                Items_Count = x.Items_Count,
                NetAmount = x.NetAmount,
                Service_Charge = x.Service_Charge,
                Vat_Charge = x.Vat_Charge
            }).ToList();
        }

        public tbl_Orders GetOrderDetails(int orderId)
        {
            return dl.GetOrderDetails(orderId);
        }
        public dynamic GetProducts(int productId)
        {
            return dl.GetProducts(productId).Select(products => new
            {
                Product_ID = products.Product_ID,
                Product_Name = products.Product_Name,
                SKU = products.SKU,
                Supplier_Id = products.Supplier_Id,
                Product_Description = products.Product_Description,
                Product_Quantity = products.Product_Quantity,
                Price = products.Price,
                ExpiryDate = products.ExpiryDate.ToShortDateString(),
                Availability = products.Availability,
                IsExpiresInOneMonth = (DateTime.Now.AddDays(30)) >= products.ExpiryDate
            }).ToList();
        }

        public dynamic GetNotifications(int parlevel)
        {
            return dl.GetNotifications(parlevel).Select(x => new
            {
                //  Product_ID = x.Product_ID,
                Product_Name = x.Product_Name,
                Supplier_Id = x.Supplier_Id,
                Supplier_Name = x.Supplier_Name,
                Product_Quantity = x.RemainingQuantity,
                ExpiryDate = x.ExpiryDate.ToShortDateString(),
                IsExpiresInOneMonth = (DateTime.Now.AddDays(30)) >= x.ExpiryDate
                // Availability = products.Availability
            }).ToList();
        }
        public dynamic GetBrands()
        {
            return dl.GetBrands().Select(x => new
            {
                Brand_Id = x.Brand_Id,
                Brand_Name = x.Brand_Name,
                Brand_Status = x.Brand_Status,
                Category_id = x.tbl_Categories != null ? x.tbl_Categories.Category_Id : 0,
                Category_Name = x.tbl_Categories != null ? x.tbl_Categories.Category_Name : "",
                Company_Name = x.Company_Name
            }).ToList();
        }

        public dynamic GetCategories()
        {
            return dl.GetCategories().Select(x => new
            {
                Category_Id = x.Category_Id,
                Category_Name = x.Category_Name,
                Category_Status = x.Category_Status
            }).ToList();
        }

        public dynamic GetDashboardDetails()
        {
            return dl.GetDashboardDetails();
        }

        public dynamic GetStores()
        {
            return dl.GetStores().Select(x => new
            {
                Store_Id = x.Store_Id,
                Store_Name = x.Store_Name,
                Store_Status = x.Store_Status
            }).ToList();
        }

        public dynamic GetSuppliers(int supplierId)
        {
            return dl.GetSuppliers(supplierId).Select(x => new
            {
                Supplier_Id = x.Supplier_Id,
                Supplier_Name = x.Supplier_Name,
                Service_Charge_Value = x.Service_Charge_Value,
                Vat_Charge_Value = x.Vat_Charge_Value,
                Address = x.Address,
                Phone = x.Phone,
                Country = x.Country,
                Message = x.Message,
                Currency = x.Currency
            }).ToList();
        }

        public dynamic GetUsers()
        {
            return dl.GetUsers().Select(x => new
            {
                User_Id = x.User_Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Gender = x.Gender,
                Phone = x.Phone,
                Email_Id = x.Email_Id,
                IsActive = x.IsActive,
                GroupId = x.Group_Id
            }).ToList();
        }

        public bool ValidateBrand(tbl_Brands brand)
        {
            return dl.ValidateBrand(brand);
        }

        public bool ValidateCategory(tbl_Categories category)
        {
            return dl.ValidateCategory(category);
        }

        public bool ValidateStore(tbl_Stores store)
        {
            return dl.ValidateStore(store);
        }
        public bool ValidateProduct(tbl_Products product)
        {
            return dl.ValidateProduct(product);
        }
        public bool ValidateSupplier(tbl_Supplier supplier)
        {
            return dl.ValidateSupplier(supplier);
        }

        public dynamic ValidateUserLogin(string userName, string password)
        {
            return dl.ValidateUserLogin(userName, password);
        }

        public bool ValidateUserName(tbl_Users user)
        {
            return dl.ValidateUserName(user);
        }


        public bool DeleteCategory(int id)
        {
            return dl.DeleteCategory(id);
        }

        public bool DeleteStore(int id)
        {
            return dl.DeleteStore(id);
        }


        public List<tbl_Groups> GetGroups()
        {
            return dl.GetGroups();
        }

        public bool ValidateGroup(tbl_Groups group)
        {
            return dl.ValidateGroup(group);
        }
        public bool SaveGroup(tbl_Groups group)
        {
            return dl.SaveGroup(group);
        }

        public bool DeleteGroup(int id)
        {
            return dl.DeleteGroup(id);
        }

        public bool DeleteSupplier(int id)
        {
            return dl.DeleteSupplier(id);
        }

        public string GetPropertyValue(dynamic obj, string property)
        {
            var val = obj.GetType().GetProperty(property).GetValue(obj, null);
            return val != null ? Convert.ToString(val) : "";
        }

        public List<tbl_Users> GetCustomers(int customerId)
        {
            return dl.GetCustomers(customerId);
        }

        public Entities.CustomerProducts GetCustomerProducts(int customerId, string invoiceDate)
        {
            return dl.GetCustomerProducts(customerId, invoiceDate);
        }
    }
}
