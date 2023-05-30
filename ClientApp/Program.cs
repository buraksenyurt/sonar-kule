using ModelLib;
using RepositoryLib;

var crudUtility = new CRUDUtility();
var result = crudUtility.CreateCategoryWithProducts(
    "Books"
    , "Kitaplar ile ilgili kategori"
    , "Clean Code :P"
    , 190.30M
    , 100
    , true
    , DateTime.Now.AddYears(-20)
    , 0.0F
    , Country.USA
    , new ModelLib.Company
    {
        Country = Country.England,
        Level = 100,
        Name = "GG Book Deployer",
        CompanyId = 12

    });

Console.WriteLine("Kategori ve ürün eklendi");

// var result2 = crudUtility.AddOrdersToProductAndStartShipments(1, new Order[1]{
//     null
// });
