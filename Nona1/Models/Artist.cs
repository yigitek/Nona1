namespace Nona1.Models
{
    public class Artist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        //public List<Item>? Items { get; set; } = new List<Item>();
        //public List<Collab>? Collabs { get; set; } = new List<Collab>();
    }
}
