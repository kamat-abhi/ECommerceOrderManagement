using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OneTOMany.Data;

namespace OneTOMany.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")] //specifies the precision and scale of the decimal column in the database
        public decimal UnitPrice { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 1")]
        public int Quantity { get; set; }

        //Foreign keys
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        [ValidateNever]
        public Order Order { get; set; } = null!;

        [ValidateNever]
        public Product Product { get; set; } = null!;

        [NotMapped]
        public decimal TotalPrice => UnitPrice * Quantity; //calculated property

    }
}
