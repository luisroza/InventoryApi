using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryApi.WebApp.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} must not be empty")]

        public Guid LocationId { get; set; }

        [Required(ErrorMessage = "The field {0} must not be empty")]
        [StringLength(200, ErrorMessage = "The field {0} must have between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} must not be empty")]
        [StringLength(1000, ErrorMessage = "The field {0} must have between {2} and {1} characters", MinimumLength = 2)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field {0} must not be empty")]
        public decimal Price { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }

        [ScaffoldColumn(false)]
        public string LocationCode{ get; set; }
    }
}