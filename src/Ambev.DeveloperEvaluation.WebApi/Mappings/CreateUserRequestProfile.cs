using Ambev.DeveloperEvaluation.Application.Sales.AddSale;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.AddSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class AddSaleRequestProfile : Profile
{
    public AddSaleRequestProfile()
    {
        //CreateMap<CreateUserRequest, CreateUserCommand>();
        CreateMap<AddSaleRequest, AddSaleCommand>();

    }
}