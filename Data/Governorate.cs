namespace UserRegistration.Data
{
    public class Governorate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<City> Cities { get; set; }
    }
}
