using FluentValidation;
using MediatR;
using ServiceStore.Api.ShoppingCart.Models;
using ServiceStore.Api.ShoppingCart.Persistence;

namespace ServiceStore.Api.ShoppingCart.Application;

public class NewRequest
{
    public class RunRequest : IRequest
    {
        public DateTime SessionCreationDate { get; set; }

        public List<string> ProductList { get; set; }
    }

    public class ManagerRequest : IRequestHandler<RunRequest>
    {
        private readonly CartContext _cartContext;

        public ManagerRequest(CartContext context)
        {
            _cartContext = context;
        }

        public async Task<Unit> Handle(RunRequest request, CancellationToken cancellationToken)
        {
            var cartsession = new CartSession
            {
                CreateDate = request.SessionCreationDate
            };

            _cartContext.CartSessions.Add(cartsession);
            var value = await _cartContext.SaveChangesAsync();

            if (value == 0)
            {
                throw new Exception("Errores en la inserción de datos en el carrito");
            }

            int id = cartsession.CartSessionId;

            foreach (var obj in request.ProductList)
            {
                var sessionDetail = new CartSessionDetail
                {
                    CreateDate = DateTime.Now,
                    CartSessionId = id,
                    SelectedBook = obj
                };

                _cartContext.CartSessionDetails.Add(sessionDetail);
            }

            value = await _cartContext.SaveChangesAsync();

            if (value > 0)
            {
                return Unit.Value;
            }

            throw new Exception("No se pudo insertar el detalle en el carrito.");
        }
    }
}