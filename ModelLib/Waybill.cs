namespace ModelLib;

public class Waybill
{
    public string Address { get; set; }
    public string CustomerFullName { get; set; }
    public DateTime Date { get; set; }
    public object PaymentType { get; set; }
}

public enum PaymentType
{
    CreditCard,
    DebitCard,
    DigitalCoin
}