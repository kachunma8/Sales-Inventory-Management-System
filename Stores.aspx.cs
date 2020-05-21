using InventoryStore.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Stores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static dynamic GetStores()
    {
        InventoryBL bl = new InventoryBL();
        var result = bl.GetStores();
        return result;
    }

    [WebMethod]
    public static bool SaveStore(string id, string name, string status)
    {
        InventoryBL bl = new InventoryBL();
        tbl_Stores Store = new tbl_Stores()
        {
            Store_Id = Convert.ToInt32(id),
            Store_Name = name,
            Store_Status = status == "1" ? true : false
        };
        if (!bl.ValidateStore(Store))
        {
            bool result = bl.SaveStore(Store);
            return result;
        }
        return false;
    }

    [WebMethod]
    public static bool DeleteStore(string id)
    {
        InventoryBL bl = new InventoryBL();
        bool result = bl.DeleteStore(Convert.ToInt32(id));
        return result;
    }
}