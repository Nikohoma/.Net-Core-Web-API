using Service1.Data;
using Service1.Models;

namespace Service1.Services
{
    public class CatalogServices
    {
        public static List<Catalog> GetAllCatalogs()
        {
            var catalogs = CatalogData.catalogs;
            return catalogs;
        }

        public void AddCatalog(int id, string name, decimal price)
        {
            CatalogData.catalogs.Add(new Catalog() { Id = id, Name = name, Price = price });
            Console.WriteLine("Added into Catalog");
        }

    }
}
