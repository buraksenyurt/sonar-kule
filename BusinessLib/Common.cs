using ModelLib;
using CommonLib;
using RepositoryLib;
using CommonLib.Exceptions;
using System.Text.Json;

namespace BusinessLib;

public class Common
{
    private FileLogger _logger = new FileLogger();
    private NorthwindDbContext _context;
    public Common()
    {
        _context = new NorthwindDbContext();
    }

    public ShipmentCompany AddCompanyToSystem(string name, Country country, int level, List<City> cities, string contactFirstName, string contactLastName, string contactAddress, string contactEmail, string contactPhone)
    {
        var is_exist = _context.ShipmentCompanies.Where(c => c.Name == name).SingleOrDefault();
        if (is_exist == null)
        {
            var company = new ShipmentCompany
            {
                Name = name,
                Country = country,
                Level = level,
                ServedCities = cities,
                Contact = new Contact
                {
                    FirstName = contactFirstName,
                    LastName = contactLastName,
                    Address = contactAddress,
                    Email = contactEmail
                }
            };

            _context.ShipmentCompanies.Add(company);
            _context.SaveChangesAsync();
            return company;
        }
        return null;
    }

    public Category AddCategoryToSystem(string name, string description)
    {
        var is_exist = _context.Categories.Where(c => c.Title == name).SingleOrDefault();
        if (is_exist == null)
        {
            var category = new Category
            {
                Title = name,
                Description = description
            };
            _context.Categories.AddAsync(category);
            _context.SaveChangesAsync();
            return category;
        }
        return null;
    }

}

public enum CustomerStatusv2
{
    Available,
    Declined
}

public class Reportv2
{
    public decimal TotalSalary { get; set; }
    public decimal AverageSalaryPerDaily { get; set; }
    public int TotalUnit { get; set; }
    public int AverageUnitPerDaily { get; set; }
}

public enum Monthv2
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
