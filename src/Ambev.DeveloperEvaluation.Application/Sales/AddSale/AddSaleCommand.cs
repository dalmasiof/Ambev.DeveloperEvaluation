using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.AddSale
{
    public class AddSaleCommand : IRequest<AddSaleResult>
    {
        public string SaleNumber { get; set; } = Guid.NewGuid().ToString().Substring(0, 8);
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount => Items.Sum(i => i.TotalAmount);
        public string Branch { get; set; }
        public List<AddSaleItemCommand> Items { get; set; }

        public class AddSaleItemCommand
        {
            public Guid ProductId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal Discount { get; set; }
            public decimal TotalAmount => (UnitPrice * Quantity) * (1 - Discount);
        }
    }
}
