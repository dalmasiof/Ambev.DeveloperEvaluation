using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Sales;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.AddSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

/// <summary>
/// Validator for CreateUserRequest that defines validation rules for user creation.
/// </summary>
public class AddSaleRequestRequestValidator : AbstractValidator<AddSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateUserRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be valid format (using EmailValidator)
    /// - Username: Required, length between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be Unknown
    /// - Role: Cannot be None
    /// </remarks>
    public AddSaleRequestRequestValidator()
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