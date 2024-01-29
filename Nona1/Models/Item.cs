namespace Nona1.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int CollabId { get; set; }
        public Collab Collab { get; set; }
    }
}
