using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG_SE101.Application.Commands.Order
{
    public class AddOrderCommand : IRequest<int>
    {
        [Required(ErrorMessage = "CustomerId zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "CustomerId 1 veya daha büyük olmalıdır.")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Sipariş kalemleri zorunludur.")]
        [MinLength(1, ErrorMessage = "En az bir sipariş kalemi olmalıdır.")]
        public List<OrderItemDto> Items { get; set; }
        [Required(ErrorMessage = "Adres zorunludur.")]
        [MaxLength(250, ErrorMessage = "Adres en fazla 250 karakter olabilir.")]
        public string Address { get; set; }
        [MaxLength(500, ErrorMessage = "Not en fazla 500 karakter olabilir.")]
        public string Note { get; set; }
    }
    public class OrderItemDto
    {
        [Required(ErrorMessage = "ProductId zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "ProductId 1 veya daha büyük olmalıdır.")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Quantity zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity 1 veya daha büyük olmalıdır.")]
        public int Quantity { get; set; }
    }
}
