using System;

namespace app.Data
{
    public class CatalogItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; } = true;
    }
}