using Microsoft.EntityFrameworkCore;
using MiniInventory.Application.Interfaces;
using MiniInventory.Domain.Entities;
using MiniInventory.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniInventory.Infrastructure.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Supplier>> SearchByNameAsync(string keyword)
        {
            return await _context.Suppliers
                .Where(s => s.SupplierName.Contains(keyword) ||
                           (s.Email != null && s.Email.Contains(keyword)) ||
                           (s.ContactNumber != null && s.ContactNumber.Contains(keyword)))
                .ToListAsync();
        }

        public async Task<IEnumerable<Supplier>> GetActiveSuppliersAsync()
        {
            return await _context.Suppliers
                .Where(s => s.IsActive)
                .ToListAsync();
        }
    }
}