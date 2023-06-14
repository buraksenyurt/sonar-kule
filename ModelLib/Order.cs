namespace ModelLib;

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public int Quantity { get; set; }
    public ShipmentCompany ShipmentCompany { get; set; }
    public Customer Customer { get; set; }
    public string DestinationAddress { get; set; }
    public PaymentType PaymentType { get; set; }
    public bool IsCompleted { get; set; }
    public int ProductId { get; set; }
    public byte[] InvoiceDocument { get; set; }
}