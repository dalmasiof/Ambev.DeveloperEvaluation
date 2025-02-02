using Ambev.DeveloperEvaluation.Application.Sales.AddSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.AddSale;
using AutoMapper;
using static Ambev.DeveloperEvaluation.Application.Sales.AddSale.AddSaleCommand;
using static Ambev.DeveloperEvaluation.WebApi.Features.Sales.AddSale.AddSaleRequest;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

/// <summary>
/// Profile for mapping between Application and API CreateUser responses
/// </summary>
public class AddSaleRequestProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser feature
    /// </summary>
    public AddSaleRequestProfile()
    {
        CreateMap<AddSaleRequest, AddSaleCommand>();
        CreateMap<AddSaleItemRequest, AddSaleItemCommand>();

        CreateMap<AddSaleResult, AddSaleRequestResponse>();
    }
}
