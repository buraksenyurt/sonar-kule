namespace ModelLib;

public class Order{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public int Quantity { get; set; }
    public ShipmentCompany ShipmentCompany { get; set; }
}