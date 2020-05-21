using InventoryStore.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryStore.DL
{
    interface IInventoryStore
    {
        dynamic GetDashboardDetails();

        dynamic GetBrands();
        dynamic GetOrders(int userId, int groupId);
        dynamic GetProducts(int productId);

        bool ValidateBrand(tbl_Brands brand);

        bool SaveBrand(tbl_Brands brand);

        bool DeleteBrand(int id);

        dynamic GetCategories();

        bool ValidateCategory(tbl_Categories category);

        bool SaveCategory(tbl_Categories category);

        dynamic GetStores();

        bool ValidateStore(tbl_Stores store);

        bool SaveStore(tbl_Stores store);

        dynamic GetSuppliers(int supplierId);

        bool ValidateSupplier(tbl_Supplier supplier);

        bool SaveSupplier(tbl_Supplier supplier);

        dynamic GetUsers();

        bool ValidateUserName(tbl_Users user);

        bool SaveUser(tbl_Users user);

        dynamic ValidateUserLogin(string userName, string password);

        bool DeleteCategory(int id);

        bool DeleteStore(int id);

        List<tbl_Groups> GetGroups();

        bool ValidateGroup(tbl_Groups group);

        bool SaveGroup(tbl_Groups group);

        bool DeleteGroup(int id);

        bool DeleteSupplier(int id);

        tbl_Orders GetOrderDetails(int orderId);

        List<tbl_Users> GetCustomers(int customerId);

        Entities.CustomerProducts GetCustomerProducts(int customerId, string invoiceDate);
    }
}
