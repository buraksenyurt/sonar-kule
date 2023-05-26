using ModelLib;

namespace RepositoryLib;

public class DBAdapter
{
    public DBAdapter(string connString)
    {
        //TODO Will create adapter
    }
}
public class ConnectionManager
{
    private string _connectionString { get; } = "server=localhost;username=sa;password=1234!;";
    public DBAdapter CreateAdapter(string conStr)
    {
        var adapter = new DBAdapter(conStr);
        return adapter;
        //TODO: Must Used Poolling        
    }
}

public class CRUDUtility
{
    public bool CreateCategoryWithProducts(string categoryName, string categoryDescription, string productName, decimal listPrice, int stockLevel, bool onSales, DateTime createDate, float discountRate, Country country,Company company)
    {
        bool result;
        try
        {
            var connMngr = new ConnectionManager();
            var adapter = connMngr.CreateAdapter("server=localhost;database=Northwind;user_id=sa;pwd:1234;integrated security=true");
            //TODO: Insert codes will add
            return true;
        }
        catch (Exception excp)
        {
            return false;
        }
    }

    public bool AddOrdersToProductAndStartShipments(int productId, Order[] orders)
    {
        //TODO To Be Continued
        return true;
    }
}
