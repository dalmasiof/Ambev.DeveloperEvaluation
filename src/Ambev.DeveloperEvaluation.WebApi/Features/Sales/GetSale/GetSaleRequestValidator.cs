using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Sales;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.AddSale;
using FluentValidation;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleRequestValidator : AbstractValidator<GetSaleRequest>
{

    public GetSaleRequestValidator()
    {
        RuleFor(sale => sale.Id)
                 .NotEmpty().WithMessage(ValidatorMessages.GUID_NOT_NULL);
    }
}
