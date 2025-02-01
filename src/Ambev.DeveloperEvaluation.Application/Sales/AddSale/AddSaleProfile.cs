using Ambev.DeveloperEvaluation.Domain.Sales.Entities;
using AutoMapper;
using static Ambev.DeveloperEvaluation.Application.Sales.AddSale.AddSaleCommand;

namespace Ambev.DeveloperEvaluation.Application.Sales.AddSale
{
    public class AddSaleProfile : Profile
    {
        public AddSaleProfile()
        {
            CreateMap<AddSaleCommand, Sale>();
            CreateMap<AddSaleItemCommand, SaleItem>();

            CreateMap<Sale, AddSaleResult>();
            CreateMap<SaleItem, AddSaleItemCommand>();
        }
    
    }
}
