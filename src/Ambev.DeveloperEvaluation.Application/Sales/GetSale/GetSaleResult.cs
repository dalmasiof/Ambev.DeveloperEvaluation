namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleResult
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount => Items.Sum(i => i.TotalAmount);
        public string Branch { get; set; }
        public List<SaleItemResult> Items { get; set; }
    }

    public class SaleItemResult
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount => (UnitPrice * Quantity);
    }
}
}
