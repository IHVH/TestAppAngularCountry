namespace EntitiesDAL.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public List<Province> Provinces { get; set; } = new();
        public List<User> Users { get; set; } = new();
    }
}
