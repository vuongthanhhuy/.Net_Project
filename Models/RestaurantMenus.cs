namespace FinalProject.Models
{
    public class RestaurantMenus
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Meal { get; set; }
        public ICollection<Accounts> Accounts { get; set; }
        public ICollection<Orderings> Orderings { get; set; }
    }
}
