using Ambev.DeveloperEvaluation.Domain.Sales;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleValidator : AbstractValidator<GetSaleQuery>
    {

        public GetSaleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ValidatorMessages.GUID_NOT_NULL);
        }
    }
}
