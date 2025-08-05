using EtaEstimatorAPI.Models;

namespace EtaEstimatorAPI.Data
{
    public static class DataStore
    {
        public static List<Product> Products => new List<Product>
        {
            new Product { ProductId = "P1001", Name = "Washing Machine", InStock = true },
            new Product { ProductId = "P1002", Name = "Fridge", InStock = false },
            new Product { ProductId = "P1003", Name = "Dishwasher", InStock = true },
            new Product { ProductId = "P1004", Name = "Oven", InStock = false }
        };

        public static Dictionary<string, int> RegionDelays => new Dictionary<string, int>
        {
            { "North", 2 },
            { "South", 5 },
            { "East", 3 },
            { "West", 7 }
        };
    }
}
