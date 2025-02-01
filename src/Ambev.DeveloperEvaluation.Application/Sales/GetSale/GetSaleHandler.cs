using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleHandler : IRequestHandler<GetUserCommand, GetUserResult>
    {
        public GetSaleHandler()
        {
                
        }
        public Task<GetUserResult> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
