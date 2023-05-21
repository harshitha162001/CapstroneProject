namespace CapstoneProject.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Seller { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
    }
}
