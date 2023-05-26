namespace ModelLib;

public class Company
{
    public int CompanyId { get; set; }
    public string Name { get; set; }
    public Country Country { get; set; }
    public int Level { get; set; }
}