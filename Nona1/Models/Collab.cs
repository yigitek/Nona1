namespace Nona1.Models
{
    public class Collab
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Artist> Artists { get; set; } = new List<Artist>();
    }
}
