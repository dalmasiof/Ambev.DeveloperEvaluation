using Ambev.DeveloperEvaluation.Domain.Sales;
using Ambev.DeveloperEvaluation.Domain.Sales.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.AddSale
{
    public class AddSaleValidator : AbstractValidator<AddSaleCommand>
    {
        public AddSaleValidator()
        {
            RuleFor(sale => sale.Items)
                .NotEmpty().WithMessage(ValidatorMessages.SALE_SHOULD_HAVE_ONE_ITEM);

            RuleForEach(sale => sale.Items)
                .Must(item => item.Quantity <= 20)
                .WithMessage(ValidatorMessages.SALE_SHOULD_NOT_HAVE_TWENTY_ITENS);

            RuleFor(sale => sale.TotalAmount)
                .Equal(sale => sale.Items.Sum(i => i.TotalAmount))
                .WithMessage(ValidatorMessages.SALE_TOTAL_AMOUNT_EQUAL_TOTAL_ITENS);
        }
    }
}
