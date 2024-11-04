namespace UserRegistration.Data
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GovernorateId { get; set; }
        public Governorate Governorate { get; set; }
    }
}
