using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.AddSale
{
    public class AddSaleRequest
    {
        public string SaleNumber { get; set; } = Guid.NewGuid().ToString().Substring(0, 8);
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount => Items.Sum(i => i.TotalAmount);
        public string Branch { get; set; }
        public List<AddSaleItemRequest> Items { get; set; }

        public class AddSaleItemRequest
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
