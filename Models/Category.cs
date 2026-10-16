using System.ComponentModel.DataAnnotations;

namespace OneTOMany.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(200)]
        public string CategoryName { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        // One category has many products
        public List<Product> Products { get; set; } = new(); //navigation property
    }
}
