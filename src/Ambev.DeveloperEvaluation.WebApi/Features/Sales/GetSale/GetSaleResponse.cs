﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleResponse
    {
        public string SaleNumber { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public string Branch { get; set; }
        public List<GetSaleItemResponse> Items { get; set; }

        public class GetSaleItemResponse
        {
            public Guid ProductId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal Discount { get; set; }
            public decimal TotalAmount { get; set; }
        }
    }
}
