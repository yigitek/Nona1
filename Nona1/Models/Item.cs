﻿namespace Nona1.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public List<Artist> Artists { get; set; } = new List<Artist>();
        public int CollabId { get; set; }
        public Collab Collab { get; set; }
    }
}
