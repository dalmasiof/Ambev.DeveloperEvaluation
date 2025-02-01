using Ambev.DeveloperEvaluation.Domain.Sales.Entities;
using Ambev.DeveloperEvaluation.Domain.Sales.Repositories;
using Ambev.DeveloperEvaluation.ORM.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly SalesContext _context;

        public SaleRepository(SalesContext context)
        {
            _context = context;
        }
        public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(sale, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return sale;
        }

        public async Task<Sale> DeleteAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync(cancellationToken);

            return sale;
        }

        public async Task<Sale> GetSale(Guid saleId, CancellationToken cancellationToken = default)
        {
            return await _context.Sales.FirstOrDefaultAsync(x => x.Id == saleId);
        }

        public async Task<IEnumerable<Sale>> GetSalesByUserId(Guid userId, CancellationToken cancellationToken = default)
        {
            return _context.Sales.Where(x => x.CustomerId == userId);
        }

        public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync(cancellationToken);
           
            return sale;
        }
    }
}
