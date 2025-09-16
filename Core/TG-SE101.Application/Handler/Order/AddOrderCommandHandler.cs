using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TG_SE101.Application.Commands.Order;
using TG_SE101.Domain.Model;
using TG_SE101.Infrastructure.Product;
using TG_SE101.Infrastructure.Repository.Order;
using TG_SE101.Infrastructure.Repository.UnitOfWork;

namespace TG_SE101.Application.Handler.Order
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public AddOrderCommandHandler(IUnitOfWork unitOfWork, IProductRepository productRepository,IOrderRepository orderRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var failedProductIds = new List<int>();

            foreach (var item in request.Items)
            {
                var product = _productRepository.GetById(item.ProductId);
                if (product == null || product.Stock < item.Quantity)
                {
                    failedProductIds.Add(item.ProductId);
                }
            }
            if (!failedProductIds.Any())
            {
                var order = new Domain.Model.Order
                {
                    CustomerId = request.CustomerId,
                    Number = $"ORD-{DateTime.UtcNow.Ticks}",
                    Items = new List<OrderItem>()
                };
                foreach (var item in request.Items)
                {
                    var product = _productRepository.GetById(item.ProductId);
                    product.Stock -= item.Quantity;

                    _productRepository.Update(product);

                    order.Items.Add(new OrderItem
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        ProductName = product.Name,
                        OrderId = order.Id,
                        UnitPrice = product.Price*item.Quantity
                    });
                }
                order.Waybill= new Domain.Model.Waybill
                {
                    WaybillNumber = $"WB-{DateTime.UtcNow.Ticks}",
                    IsSend = false,
                    OrderId = order.Id,
                };
                _orderRepository.Insert(order);
                await _unitOfWork.SaveChangesAsync();
                return order.Id;
            }
            return -1;
        }
    }
}
