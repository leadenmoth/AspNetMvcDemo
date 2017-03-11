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
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime Modified { get; set; }
    }
}