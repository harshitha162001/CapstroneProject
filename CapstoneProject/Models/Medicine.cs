namespace CapstoneProject.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Seller { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
