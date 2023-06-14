using Microsoft.AspNetCore.Mvc;
using ModelLib;
using BusinessLib;

namespace ServiceApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SalesController
    : ControllerBase
{
    [HttpGet("{product/sales/report}")]
    public IEnumerable<Sales> GetSalesByProduct()
    {
        Ordering ordering = new Ordering();
        return ordering.GetSalaryReport();
    }

    [HttpPost("{product/shipment}")]
    public bool AddOrdersToProductAndStartShipments(int productId, Order[] orders)
    {
        Ordering ordering = new Ordering();
        return ordering.AddOrdersToProductAndStartShipments(productId, orders);
    }
}
