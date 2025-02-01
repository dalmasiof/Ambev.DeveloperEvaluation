using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Sales.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        /// <summary>
        /// Tests that when a suspended user is activated, their status changes to Active.
        /// </summary>
        [Fact(DisplayName = "Calculate 10% of discount")]
        public void Given_4_Identical_Items_should_Apply_10descount()
        {
            // Arrange
            var sales = SalesTestData.GenerateWithNumberOfItems(4);

            // Act
            var totalValue = sales.Items.Sum(x => x.Quantity * x.UnitPrice);
            var discountValue = totalValue * 0.10M;
            var totalWithDiscount = totalValue - discountValue;

            // Assert
            Assert.Equal(sales.TotalAmount, totalWithDiscount, precision: 2);
        }

        [Fact(DisplayName = "Calculate 20% of discount")]
        public void Given_20_Identical_Items_should_Apply_20descount()
        {
            // Arrange
            var sales = SalesTestData.GenerateWithNumberOfItems(15);

            // Act
            var totalValue = sales.Items.Sum(x => x.Quantity * x.UnitPrice);
            var discountValue = totalValue * 0.20M;
            var totalWithDiscount = totalValue - discountValue;

            // Assert
            Assert.Equal(sales.TotalAmount, totalWithDiscount, precision: 2);
        }

        [Fact(DisplayName = "Sale should be equal to the sum of item totals")]
        public void Should_TotalAmount_Equal_ItemsTotal()
        {
            // Arrange
            var sales = SalesTestData.GenerateDefault();

            // Act
            var totalValue = sales.Items.Sum(x => x.TotalAmount);

            // Assert (com tolerância para evitar erros de arredondamento)
            Assert.Equal(totalValue, sales.TotalAmount, precision: 2);
        }

        [Fact(DisplayName = "Sale should not have discount on less then 4 itens")]
        public void Should_not_have_discount_on_less_4_itens()
        {
            // Arrange
            var sales = SalesTestData.GenerateWithNumberOfItems(2);

            // Act
            var totalValue = sales.Items.Sum(x => x.TotalAmount);

            // Assert (com tolerância para evitar erros de arredondamento)
            Assert.True(sales.Items.Where(x => x.Quantity < 4 && x.Discount > 0).Count() == 0);
        }

        [Fact(DisplayName = "Sale should not have more than 20 same itens")]
        public void Should_not_have_more_then_20_itens()
        {
            // Arrange
            var sales = SalesTestData.GenerateWithNumberOfItems(19);

            Assert.Throws<ArgumentException>(() => sales.AddItem(new SaleItem() { }));



        }
    }
}
