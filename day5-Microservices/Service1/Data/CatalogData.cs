using Service1.Models;

namespace Service1.Data
{
    public class CatalogData
    {
        public static List<Catalog> catalogs { get; set; } = new List<Catalog>()
        {
            new Catalog {Id = 1, Name = "Chair", Price = 1000},
            new Catalog {Id = 2, Name = "Table", Price = 2300},
            new Catalog {Id = 3, Name = "Pen", Price = 350},
            new Catalog {Id = 4, Name = "Hammer", Price = 800},
            new Catalog {Id = 5, Name = "Mouse", Price = 1300},
        };
    }
}
