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
    public bool CreateCategoryWithProducts(string categoryName, string categoryDescription, string productName, decimal listPrice, int stockLevel, bool onSales, DateTime createDate, float discountRate, Country country, Company company)
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
        bool result = false;
        Product product = null;
        try
        {
            product = GetProductById(productId);
            if (product.CategoryId == 3)
            {
                if (!product.OnSales || product.StockLevel < 10)
                {
                    return false;
                }
            }

            var calcResult = CalculateDiscountRate(product);
            if (!calcResult)
            {
                return false;
            }

            product.Orders = new Order[orders.Length];
            var index = 0;
            foreach (var order in orders)
            {
                switch (order.Customer.MemberType)
                {
                    case MemberType.Regular:
                        break;
                    case MemberType.Gold:
                        product.DiscountRate += 0.1F;
                        break;
                    case MemberType.Platinium:
                        product.DiscountRate += 0.1F;
                        break;
                }
                product.Orders[index] = order;

                switch (order.Customer.City)
                {
                    case "Istanbul":
                        order.ShipmentCompany = GetShipmentCompanyFromCity(order.Customer.City);
                        break;
                    case "Tokyo":
                        order.ShipmentCompany = GetShipmentCompanyFromCity(order.Customer.City);
                        break;
                    case "New York":
                        order.ShipmentCompany = new ShipmentCompany
                        {
                            CompanyId = 1,
                            Country = Country.USA,
                            Level = 950,
                            Name = "YupPiiEss"
                        };
                        break;
                    case "Berlin":
                        order.ShipmentCompany = new ShipmentCompany
                        {
                            CompanyId = 1,
                            Country = Country.Australia,
                            Level = 1000,
                            Name = "Doyçe Postal"
                        };
                        break;
                    default:
                        break;
                }

                if (order.PaymentType == PaymentType.DigitalCoin)
                {
                    if (!CheckCustomerStatus(order.Customer, order.PaymentType, product))
                    {
                        return false;
                    }
                }
                Waybill waybill = new Waybill
                {
                    Address = order.DestinationAddress,
                    CustomerFullName = order.Customer.Name + " " + order.Customer.MiddleName + " " + order.Customer.LastName,
                    Date = DateTime.Now,
                    PaymentType = order.PaymentType,
                    OrderId = order.OrderId
                };

                var notificationAddress = "https://nowhere.com/api/governecy/waybill_management";
                var apiKey = "123456789987654321";
                var apiPass = "P@ssw0rd";
                GovermentIntegrator integrator = new GovermentIntegrator(notificationAddress);
                var isConnected = integrator.Connect(apiKey, apiPass);
                if (isConnected)
                {
                    IntegratorResponse sendResponse = integrator.PostWaybill(waybill);
                    if (sendResponse.Status != IntegratorStatus.Success)
                    {
                        //TODO Must logged this status
                        return false;
                    }
                    else
                    {
                        if (sendResponse.Status == IntegratorStatus.FraudDetected)
                        {
                            //TODO Must logged this status
                            order.Customer.IsSuspicious = true;                            
                        }
                    }
                }
                else
                {
                    //TODO Must logged this status
                    return false;
                }

                index++;
            }

        }
        catch (Exception excp)
        {
            return false;
        }

        return true;
    }

    private bool CheckCustomerStatus(Customer customer, PaymentType paymentType, Product product)
    {
        //TODO: Check the status of customer for payment type
        throw new NotImplementedException();
    }

    private ShipmentCompany GetShipmentCompanyFromCity(string city)
    {
        //TODO: Getting from Redis by City Key
        throw new NotImplementedException();
    }

    private Product GetProductById(int productId)
    {
        return new Product
        {
            Name = "ElCi Monitor 49 Inch Ultra Super Mega Hydron HD",
            CategoryId = 3,
            ListPrice = 4599.99M,
            StockLevel = 90,
            Country = Country.Japan,
            Company = new Company
            {
                Name = "Takaşi Kovaç Associated Press And Mefrüşat Klima San",
                Country = Country.Japan
            }
        };
    }

    private bool CalculateDiscountRate(Product product)
    {
        product.DiscountRate = 0.15F;
        return true;
    }
}
