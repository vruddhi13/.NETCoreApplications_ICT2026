namespace Assign3_MVC_Core_GenericTuples.Models
{
    public class VehicleData
    {
        public static List<Tuple<int, string, string, int, decimal>> vehicles = new List<Tuple<int, string, string, int, decimal>>()
        {
            new Tuple<int, string, string, int, decimal>(1, "Toyota", "Corolla", 2020, 20000m),
            new Tuple<int, string, string, int, decimal>(2, "Honda", "Civic", 2019, 22000m),
            new Tuple<int, string, string, int, decimal>(3, "Ford", "Mustang", 2021, 35000m),
            new Tuple<int, string, string, int, decimal>(4, "Tesla", "Model 3", 2022, 45000m),
            new Tuple<int, string, string, int, decimal>(5, "BMW", "X5", 2018, 55000m)
        };
    }
}
