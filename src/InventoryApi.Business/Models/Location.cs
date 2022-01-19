using System.Collections.Generic;

namespace InventoryApi.Business.Models
{
    public class Location : Entity
    {
        public string Code { get; set; }
        public string Address { get; set; }

        /* EF Relations */
        public IEnumerable<Product> Products { get; set; }
    }
}