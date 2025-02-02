using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.AddSale;

/// <summary>
/// API response model for CreateUser operation
/// </summary>
public class AddSaleRequestResponse
{
    /// <summary>
    /// The unique identifier of the created user
    /// </summary>
    public Guid Id { get; set; }

  
}
