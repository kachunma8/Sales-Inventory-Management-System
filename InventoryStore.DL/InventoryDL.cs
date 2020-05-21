using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryStore.DL
{
    public class InventoryDL
    {
        private InventoryStoreEntityConnection dbContext = new InventoryStoreEntityConnection();

        public dynamic GetDashboardDetails()
        {
            try
            {
                int activeBrandsCount = dbContext.tbl_Brands.Where(x => x.Brand_Status == true).Count();
                int activeCategoriesCount = dbContext.tbl_Categories.Where(x => x.Category_Status == true).Count();
             int activeStoresCount = dbContext.tbl_Stores.Where(x => x.Store_Status == true).Count();
                int orderCount = dbContext.tbl_Orders.Count();
                int productsCount = dbContext.tbl_Products.Count();
                return new
                {
                    BrandsCount = activeBrandsCount,
                    CategoriesCount = activeCategoriesCount,
                    StoresCount = activeStoresCount,
                    OrdersCount = orderCount,
                    ProductsCount = productsCount
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Orders> GetOrders(int userid, int groupId)
        {
            try
            {
                if (groupId == 3)//customer
                    return dbContext.tbl_Orders.Include("tbl_Products").Where(x => x.User_Id == userid).ToList();
                else
                    return dbContext.tbl_Orders.Include("tbl_Products").ToList();

                //return dbContext.tbl_Orders.Where(x => x.User_Id == userid).Select(x => new
                //{
                //    OrderId = x.Order_Id,
                //    CustomerName = x.Customer_Name,
                //    Quantity = x.Items_Count,
                //    Amount = x.Amount,
                //    GrossAmount = x.Gross_Amount,
                //    ServiceCharge = x.Service_Charge,
                //    Vat = x.Vat_Charge,
                //});
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tbl_Orders GetOrderDetails(int orderId)
        {
            try
            {
                return dbContext.tbl_Orders.Include("tbl_Products").FirstOrDefault(x => x.Order_Id == orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Products> GetProducts(int productId)
        {
            try
            {
                //var result = from products in dbContext.tbl_Products
                //             join supplier in dbContext.tbl_Supplier on products.Supplier_Id equals supplier.Supplier_Id
                //             join brand in dbContext.tbl_Brands on products.Brand_Id equals brand.Brand_Id
                //             join category in dbContext.tbl_Categories on products.Category_Id equals category.Category_Id
                //             join store in dbContext.tbl_Stores on products.Store_Id equals store.Store_Id
                //             select new tbl_Products
                //             {
                //                 c
                //             };

                var result = dbContext.tbl_Products.ToList();

                if (productId > 0)
                {
                    return result.Where(x => x.Product_ID == productId).ToList();
                }

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_NotificationsByLevel_Result> GetNotifications(int parlevel)
        {
            try
            {

                var result = dbContext.sp_NotificationsByLevel(parlevel).ToList();

                //if (parlevel > 0)
                //{
                //    return result.Where(x => x.Product_Quantity == parlevel).ToList();
                //}

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Brands> GetBrands()
        {
            try
            {
                return dbContext.tbl_Brands.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ValidateBrand(tbl_Brands brand)
        {
            try
            {
                if (brand.Brand_Id > 0)
                    return dbContext.tbl_Brands.Any(x => x.Brand_Name == brand.Brand_Name && x.Brand_Id != brand.Brand_Id);
                else
                    return dbContext.tbl_Brands.Any(x => x.Brand_Name == brand.Brand_Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SaveBrand(tbl_Brands brand)
        {
            try
            {
                var result = dbContext.SP_SaveBrand(brand.Brand_Id, brand.Brand_Name, brand.Brand_Status, brand.Category_id, brand.Company_Name).ToList();
                if (result.Any())
                {
                    if (result.FirstOrDefault().Result == 1)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteBrand(int id)
        {
            try
            {
                var exBrand = dbContext.tbl_Brands.FirstOrDefault(x => x.Brand_Id == id);
                if (exBrand != null)
                {
                    dbContext.tbl_Brands.Remove(exBrand);
                    dbContext.SaveChanges();
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Categories> GetCategories()
        {
            try
            {
                return dbContext.tbl_Categories.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ValidateCategory(tbl_Categories category)
        {
            try
            {
                if (category.Category_Id > 0)
                    return dbContext.tbl_Categories.Any(x => x.Category_Name == category.Category_Name && x.Category_Id != category.Category_Id);
                else
                    return dbContext.tbl_Categories.Any(x => x.Category_Name == category.Category_Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SaveCategory(tbl_Categories category)
        {
            try
            {
                var result = dbContext.SP_SaveCategory(category.Category_Id, category.Category_Name, category.Category_Status).ToList();
                if (result.Any())
                {
                    if (result.FirstOrDefault().Result == 1)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Stores> GetStores()
        {
            try
            {
                return dbContext.tbl_Stores.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ValidateStore(tbl_Stores store)
        {
            try
            {
                if (store.Store_Id > 0)
                    return dbContext.tbl_Stores.Any(x => x.Store_Name == store.Store_Name && x.Store_Id != store.Store_Id);
                else
                    return dbContext.tbl_Stores.Any(x => x.Store_Name == store.Store_Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SaveStore(tbl_Stores store)
        {
            try
            {
                var result = dbContext.SP_SaveStore(store.Store_Id, store.Store_Name, store.Store_Status).ToList();
                if (result.Any())
                {
                    if (result.FirstOrDefault().Result == 1)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Supplier> GetSuppliers(int supplierId)
        {
            try
            {
                if (supplierId > 0)
                    return dbContext.tbl_Supplier.Where(x => x.Supplier_Id == supplierId).ToList();
                else
                    return dbContext.tbl_Supplier.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ValidateSupplier(tbl_Supplier supplier)
        {
            try
            {
                if (supplier.Supplier_Id > 0)
                    return dbContext.tbl_Supplier.Any(x => x.Supplier_Name == supplier.Supplier_Name && x.Supplier_Id != supplier.Supplier_Id);
                else
                    return dbContext.tbl_Supplier.Any(x => x.Supplier_Name == supplier.Supplier_Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SaveSupplier(tbl_Supplier supplier)
        {
            try
            {
                dbContext.tbl_Supplier.Add(supplier);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteSupplier(int id)
        {
            try
            {
                var exBrand = dbContext.tbl_Supplier.FirstOrDefault(x => x.Supplier_Id == id);
                if (exBrand != null)
                {
                    dbContext.tbl_Supplier.Remove(exBrand);
                    dbContext.SaveChanges();
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #region Users
        public List<tbl_Users> GetUsers()
        {
            try
            {
                return dbContext.tbl_Users.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ValidateUserName(tbl_Users user)
        {
            try
            {
                return dbContext.tbl_Users.Any(x => x.User_Name == user.User_Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SaveUser(tbl_Users user)
        {
            try
            {
                //For staff default password
                if (user.Group_Id == 2)
                {
                    user.Password = "Password@123";
                }
                var result = dbContext.SP_SaveUser(user.User_Id, user.FirstName, user.LastName, (user.Gender.Length > 0 ? user.Gender[0].ToString() : ""),
                    user.Phone, user.Password, user.Email_Id, user.Group_Id, user.IsActive).ToList();
                if (result.Any())
                {
                    if (result.FirstOrDefault().Result == 1)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public dynamic ValidateUserLogin(string userName, string password)
        {
            tbl_Users user;
            try
            {
                user = dbContext.tbl_Users.FirstOrDefault(x => x.User_Name == userName && x.Password == password);
                if (user != null)
                {
                    var group = dbContext.tbl_Groups.FirstOrDefault(x => x.Group_Id == user.Group_Id);
                    return new
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserId = user.User_Id,
                        UserName = user.User_Name,
                        Email = user.Email_Id,
                        MenuAccess = group != null ? group.Menu_Access : "",
                        GroupId = user.Group_Id
                    };
                }

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public bool DeleteCategory(int id)
        {
            try
            {
                var exCategory = dbContext.tbl_Categories.FirstOrDefault(x => x.Category_Id == id);
                if (exCategory != null)
                {
                    dbContext.tbl_Categories.Remove(exCategory);
                    dbContext.SaveChanges();
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteStore(int id)
        {
            try
            {
                var exStore = dbContext.tbl_Stores.FirstOrDefault(x => x.Store_Id == id);
                if (exStore != null)
                {
                    dbContext.tbl_Stores.Remove(exStore);
                    dbContext.SaveChanges();
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<tbl_Groups> GetGroups()
        {
            try
            {
                return dbContext.tbl_Groups.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ValidateGroup(tbl_Groups Group)
        {
            try
            {
                if (Group.Group_Id > 0)
                    return dbContext.tbl_Groups.Any(x => x.Group_Name == Group.Group_Name && x.Group_Id != Group.Group_Id);
                else
                    return dbContext.tbl_Groups.Any(x => x.Group_Name == Group.Group_Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SaveGroup(tbl_Groups Group)
        {
            try
            {
                var result = dbContext.SP_SaveGroup(Group.Group_Id, Group.Group_Name, Group.Menu_Access).ToList();
                if (result.Any())
                {
                    if (result.FirstOrDefault().Result == 1)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteGroup(int id)
        {
            try
            {
                var exStore = dbContext.tbl_Groups.FirstOrDefault(x => x.Group_Id == id);
                if (exStore != null)
                {
                    dbContext.tbl_Groups.Remove(exStore);
                    dbContext.SaveChanges();
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidateProduct(tbl_Products product)
        {
            try
            {
                if (product.Product_ID > 0)
                    return dbContext.tbl_Products.Any(x => x.Product_Name == product.Product_Name && x.Product_ID != product.Product_ID);
                else
                    return dbContext.tbl_Products.Any(x => x.Product_Name == product.Product_Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SaveProduct(tbl_Products product)
        {
            try
            {
                var result = dbContext.SP_SaveProduct(product.Product_ID, product.Product_Name, product.SKU, product.Supplier_Id, product.Category_Id, product.Brand_Id, product.Store_Id, product.Product_Description, product.Product_Quantity, product.Price, product.ExpiryDate, product.Availability).ToList();
                if (result.Any())
                {
                    if (result.FirstOrDefault().Result == 1)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveOrder(tbl_Orders Order)
        {
            try
            {
                var result = dbContext.SP_SaveOrder(Order.Order_Id, Order.Product_Id, Order.Items_Count, Order.Product_Cost, Order.Amount, Order.Bill_No, Order.Customer_Name,
Order.Customer_Address, Order.Customer_Phone, Order.CreatedDate, Order.Gross_Amount, Order.Service_Charge,
Order.Vat_Charge, Order.Discount, Order.NetAmount, Order.Paid_Status, Order.User_Id).ToList();
                if (result.Any())
                {
                    if (result.FirstOrDefault().Result == 1)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Users> GetCustomers(int customerId)
        {
            try
            {
                if (customerId > 0)
                {
                    var result = dbContext.tbl_Users.Where(x => x.Group_Id == 3 && x.User_Id == customerId);
                    return result.ToList();
                }
                else
                {
                    var result = dbContext.tbl_Users.Where(x => x.Group_Id == 3);
                    return result.ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Entities.CustomerProducts GetCustomerProducts(int customerId, string invoiceDate)
        {
            try
            {
                var customer = dbContext.tbl_Users.FirstOrDefault(x => x.User_Id == customerId);
                var result = new Entities.CustomerProducts();
                if (customer != null)
                {
                    result.CustomerId = customer.User_Id;
                    result.CustomerName = customer.FirstName + " " + customer.LastName;
                    result.Phone = customer.Phone;
                    DateTime dtInvoiceDate = Convert.ToDateTime(invoiceDate);

                    var orders = dbContext.tbl_Orders.Where(x => x.User_Id == customerId && (x.CreatedDate.Value.Day == dtInvoiceDate.Day &&
                    x.CreatedDate.Value.Month == dtInvoiceDate.Month && x.CreatedDate.Value.Year == dtInvoiceDate.Year)).ToList();
                    result.Products = orders.Select(x => new Entities.Products
                    {
                        ProductId = x.Product_Id.Value,
                        ProductName = dbContext.tbl_Products.FirstOrDefault(p => p.Product_ID == x.Product_Id) != null ? dbContext.tbl_Products.FirstOrDefault(p => p.Product_ID == x.Product_Id).Product_Name : "",
                        Quantity = x.Items_Count.Value,
                        Cost = x.Product_Cost.Value,
                        Amount = x.Amount.Value,
                        Gross = x.Gross_Amount.Value,
                        SCharge = x.Service_Charge.Value,
                        Vat = x.Vat_Charge.Value,
                        NetAmount = x.NetAmount.Value
                    }).ToList();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
