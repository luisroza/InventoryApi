using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryApi.WebApp.ViewModels
{
    public class LocationViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} must not be empty")]
        [StringLength(100, ErrorMessage = "The field {0} must have between {2} and {1} characters", MinimumLength = 2)]
        public string Code { get; set; }

        [Required(ErrorMessage = "The field {0} must not be empty")]
        [StringLength(300, ErrorMessage = "The field {0} must have between {2} and {1} characters", MinimumLength = 1)]
        public string Address { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}