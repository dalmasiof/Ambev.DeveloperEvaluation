using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleQuery : IRequest<GetSaleResult>
    {
        public Guid Id { get; set; }
        public GetSaleQuery(Guid guid)
        {
            this.Id = guid;
        }
        public GetSaleQuery()
        {
            
        }
    }
}
