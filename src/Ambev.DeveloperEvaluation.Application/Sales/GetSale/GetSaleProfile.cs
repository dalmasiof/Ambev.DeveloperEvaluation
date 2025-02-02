using Ambev.DeveloperEvaluation.Domain.Sales.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleProfile : Profile
    {
        public GetSaleProfile()
        {
            CreateMap<Guid, GetSaleQuery>()
                .ConstructUsing(id => new GetSaleQuery(id));

            CreateMap<Sale, GetSaleResult>();
        }

    }
}
