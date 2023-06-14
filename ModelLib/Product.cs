namespace ModelLib;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal ListPrice { get; set; }
    public int StockLevel { get; set; }
    public int CategoryId { get; set; }
    public bool OnSales { get; set; }
    public float DiscountRate { get; set; }
    public Country Country { get; set; }
    public Company Company { get; set; }
    public Order[] Orders { get; set; }
    public DateTime CreateDate { get; set; }
}

public enum Country
{
    USA,
    Canada,
    Brazil,
    Mexico,
    Argentina,
    China,
    Japan,
    India,
    SouthKorea,
    Australia,
    Germany,
    France,
    England,
    Italy,
    Netherlands,
    SouthAfrica,
    Nigeria,
    Egypt,
    Kenya,
    SaudiArabia,
    Ukrain,
    Turkey,
    UnitedArabEmirates,
    Israel,
    Singapore,
    Malaysia,
    Indonesia,
    NewZealand,
    Colombia,
    Chile,
    Peru,
    Venezuela,
    Iran
}
