using System;

namespace InventoryApi.Business.Models
{
    public class Product : Entity
    {
        public Guid LocationId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }

        /* EF Relations */
        public Location Location { get; set; }
    }
}