namespace ModelLib;

public class ShipmentCompany
{
    public int CompanyId { get; set; }
    public string Name { get; set; }
    public Country Country { get; set; }
    public int Level { get; set; }
    public List<City> ServedCities { get; set; } = new List<City>();
}

public class City{
    public int Id { get; set; }
    public string Name { get; set; }
}