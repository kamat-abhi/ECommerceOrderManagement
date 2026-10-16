using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace OneTOMany.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(200)]
        public string ProductName { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")] //specifies the precision and scale of the decimal column in the database
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        public bool IsActive { get; set; } = true;


        //Foreign key to Category
        public int CategoryId { get; set; }

        [ValidateNever]
        public Category Category { get; set; } = null!;

        public List<OrderItem> OrderItems { get; set; } = new(); //navigation property to OrderItem
    }
}
