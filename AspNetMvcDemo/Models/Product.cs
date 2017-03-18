using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetMvcDemo.Models
{
    /// <summary>
    /// Using model for back end task 2 as a placeholder for now
    /// </summary>
    public class Product
    {
        [Display(Name = "Product Number")]
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Category { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(0, 1000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Modified { get; set; }
    }
}