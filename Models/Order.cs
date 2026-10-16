using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OneTOMany.Models;

namespace OneTOMany.Data
{
    public class Order
    {
        public enum OrderStatus
        {
            Pending,
            Processing,
            Shipped,
            Delivered,
            Cancelled
        }

        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Today;

        [Column(TypeName = "decimal(18,2)")] //specifies the precision and scale of the decimal column in the database
        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [StringLength(200)]
        public string? ShippingAddress { get; set; }

        //Foreign key to ApplicationUser
        public string ApplicationUserId { get; set; }

        [ValidateNever] //prevents validation of the navigation property
        public ApplicationUser User { get; set; } //navigation property to ApllicationUser

        [ValidateNever]
        public List<OrderItem> OrderItems { get; set; } = new(); //navigation property to OrderItem>
    }
}
