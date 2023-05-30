using Microsoft.EntityFrameworkCore;
using ModelLib;

namespace RepositoryLib
{
    public partial class NorthwindDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShipmentCompany> ShipmentCompanies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=companyDb;user=sa;password=1234!");
        }

        public void CreateCategory(Category category)
        {
            Categories.Add(category);
            SaveChanges();
        }

        public void CreateCompany(Company company)
        {
            Companies.Add(company);
            SaveChanges();
        }

        public void CreateCustomer(Customer customer)
        {
            Customers.Add(customer);
            SaveChanges();
        }

        public void CreateOrder(Order order)
        {
            Orders.Add(order);
            SaveChanges();
        }

        public void CreateProduct(Product product)
        {
            Products.Add(product);
            SaveChanges();
        }

        public void CreateShipmentCompany(ShipmentCompany shipmentCompany)
        {
            ShipmentCompanies.Add(shipmentCompany);
            SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            Categories.Remove(category);
            SaveChanges();
        }

        public void DeleteCompany(Company company)
        {
            Companies.Remove(company);
            SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            Customers.Remove(customer);
            SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            Orders.Remove(order);
            SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            Products.Remove(product);
            SaveChanges();
        }

        public void DeleteShipmentCompany(ShipmentCompany shipmentCompany)
        {
            ShipmentCompanies.Remove(shipmentCompany);
            SaveChanges();
        }

        public Category GetCategory(int categoryId)
        {
            return Categories.SingleOrDefault(c=>c.CategoryId==categoryId);
        }

        public Company GetCompany(int companyId)
        {
            return Companies.SingleOrDefault(c=>c.CompanyId==companyId);
        }

        public Customer GetCustomer(int customerId)
        {
            return Customers.SingleOrDefault(c=>c.CustomerId==customerId);
        }

        public Order GetOrder(int orderId)
        {
            return Orders.SingleOrDefault(c=>c.OrderId==orderId);
        }

        public Product GetProduct(int productId)
        {
            return Products.SingleOrDefault(c=>c.ProductId==productId);
        }

        public ShipmentCompany GetShipmentCompany(int shipmentCompanyId)
        {
            return ShipmentCompanies.SingleOrDefault(c=>c.CompanyId==shipmentCompanyId);
        }
    }
}
