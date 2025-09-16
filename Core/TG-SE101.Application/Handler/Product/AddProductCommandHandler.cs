using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TG_SE101.Application.Commands.Product;
using TG_SE101.Infrastructure.Product;
using TG_SE101.Infrastructure.Repository.UnitOfWork;

namespace TG_SE101.Application.Handler.Product
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.Model.Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                CategoryId = request.CategoryId
            };

            _productRepository.Insert(product);
            await _unitOfWork.SaveChangesAsync();
            return product.Id;
        }
    }
}
