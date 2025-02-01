using Ambev.DeveloperEvaluation.Application.Sales.AddSale;
using Bogus;
using static Ambev.DeveloperEvaluation.Application.Sales.AddSale.AddSaleCommand;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData;

public static class CreateSaleHandlerTestData
{
    private static string[] Names = new string[]
        {
            "Product_A",
            "Product_B",
            "Product_C",
            "Product_D",
        };

    private static readonly Faker<AddSaleItemCommand> SaleItemFaker = new Faker<AddSaleItemCommand>()
       .RuleFor(u => u.UnitPrice, f => f.Random.Decimal(1.00M, 100.00M))
       .RuleFor(u => u.ProductId, new Guid())
       .RuleFor(u => u.Quantity, f => f.Random.Int(1, 20))
       .RuleFor(u => u.Discount, (f, u) => GetDiscount(u.Quantity))
       .RuleFor(u => u.ProductName, f => f.PickRandom(Names))
       .RuleFor(u => u.UnitPrice, f => f.Random.Decimal(1.00M, 100.00M));

    private static decimal GetDiscount(int quantity)
    {
        if (quantity >= 10 && quantity <= 20)
        {
            return 0.20M;
        }
        if (quantity >= 4)
        {
            return 0.10M;
        }
        return 0.00M;
    }

    private static readonly Faker<AddSaleCommand> addSaleCommandFaker = new Faker<AddSaleCommand>()
       .RuleFor(u => u.Branch, f => f.PickRandom("Branch_1", "Branch_2"))
       .RuleFor(u => u.CustomerId, new Guid())
       .RuleFor(u => u.CustomerName, f => f.Internet.UserName())
       .RuleFor(u => u.Items, SaleItemFaker.GenerateBetween(1, 20))
       .RuleFor(u => u.SaleNumber, f => f.Random.Int().ToString());

    public static AddSaleCommand GenerateValidCommand()
    {
        return addSaleCommandFaker.Generate();
    }
}
