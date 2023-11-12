namespace FinalProject.Models
{
    public class Orderings
    {
        public string Id { get; set; }
        public DateTime OrderingDate { get; set; }
        public int Quantity { get; set; }
        public float Revenue { get; set; }
        public string AccountId { get; set; }
        public string RestaurantMenuId { get; set; }
        public Accounts Accounts { get; set; }
        public RestaurantMenus RestaurantMenus { get; set; }
    }
}
