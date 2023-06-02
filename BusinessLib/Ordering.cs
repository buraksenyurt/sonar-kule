using ModelLib;
using CommonLib;
using RepositoryLib;
using CommonLib.Exceptions;
using System.Text.Json;

namespace BusinessLib;

public class Ordering
{
    private FileLogger _logger = new FileLogger();
    private NorthwindDbContext _context;
    public Ordering()
    {
        _context = new NorthwindDbContext();
    }
    private bool CalculateDiscountRate(Product product)
    {
        product.DiscountRate = 0.15F;
        return true;
    }
    private ShipmentCompany GetShipmentCompanyFromCity(string city)
    {
        return _context.ShipmentCompanies.Where(c => c.ServedCities.Any(sc => sc.Name == city)).SingleOrDefault();
    }
    private bool CheckCustomerStatus(Customer customer, PaymentType paymentType, Product product)
    {
        //TODO: Check the status of customer for payment type
        throw new NotImplementedException();
    }
    public bool AddOrdersToProductAndStartShipments(int productId, Order[] orders)
    {
        bool result = false;
        Product product = null;
        try
        {
            product = _context.GetProduct(productId);
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
                        _logger.WarnAsync("Unsuccess the integrator calll", "AddOrdersToProductAndStartShipments Function");
                        return false;
                    }
                    else
                    {
                        if (sendResponse.Status == IntegratorStatus.FraudDetected)
                        {
                            _logger.WarnAsync("Fraud detected", "AddOrdersToProductAndStartShipments Function");
                            order.Customer.IsSuspicious = true;
                        }
                    }
                }
                else
                {
                    //TODO Must logged this status
                    throw new IntegratorException("Could not connect to Integrator");
                    return false;
                }
                index++;
            }
        }
        catch (Exception excp)
        {
            throw new ShippingException();
        }

        return true;
    }

    public async Task<string> GetSalaryReportByMonth(Month month)
    {
        string reportPath = "http://izmprsrv01/reports/api/salary/" + month.ToString();
        HttpClient client = new HttpClient();
        HttpResponseMessage responseMessage = await client.GetAsync(reportPath);
        var body = await responseMessage.Content.ReadAsStringAsync();
        var report = JsonSerializer.Deserialize<Report>(body);
        string result = @"<table id='Table1\' style='border-width:1; border-color:Black' runat='server'><tr>
                            <th>
                            TotalSalary
                            </th>
                            <th>
                            AverageSalaryPerDaily
                            </th>
                            <th>
                            TotalUnit
                            </th>
                        </tr>
                        <tr>
                            <td>" + report.TotalSalary.ToString("C2") + @"</td>
                            <td>
                            " + report.AverageSalaryPerDaily.ToString("C2") + @"
                            </td>
                            <td>"
                            + report.TotalUnit.ToString() + @"</td>
                        </tr>
                        </table>";

        return result;
    }

}

public class Report
{
    public decimal TotalSalary { get; set; }
    public decimal AverageSalaryPerDaily { get; set; }
    public int TotalUnit { get; set; }
    public int AverageUnitPerDaily { get; set; }
}

public enum Month
{
    Jan,
    Feb,
    Mar,
    Apr,
    May,
    Jun,
    Jul,
    Aug,
    Sep,
    Oct,
    Now,
    Dec
}
