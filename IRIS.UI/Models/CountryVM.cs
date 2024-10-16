namespace IRIS.UI.Models
{
    public class CountryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StateVM> States { get; set; }
    }

    public class StateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public List<CityVM> Cities { get; set; }
    }

    public class CityVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
    }

}
