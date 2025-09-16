using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TG_SE101.Application.Commands.Product
{
    public class AddProductCommand : IRequest<int> 
    {
        [Required]
        [MaxLength(255)]
        [RegularExpression(@"^[a-zA-Z0-9çÇğĞıİöÖşŞüÜ\s]+$", ErrorMessage = "Ürün adında sadece harf, rakam ve boşluk kullanılabilir.")]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Fiyat 0 veya daha büyük olmalıdır.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stok 0 veya daha büyük olmalıdır.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Kategori zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Kategori 1 veya daha büyük olmalıdır.")]
        public int CategoryId { get; set; }
    }
}
