namespace ModelLib;

public class ShipmentCompany
{
    public int CompanyId { get; set; }
    public string Name { get; set; }
    public Country Country { get; set; }
    public int Level { get; set; }
    public List<City> ServedCities { get; set; } = new List<City>();
    public Contact Contact {get;set;}
}

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Contact
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}