using MiniInventory.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniInventory.Application.Interfaces
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        Task<IEnumerable<Supplier>> SearchByNameAsync(string keyword);
        Task<IEnumerable<Supplier>> GetActiveSuppliersAsync();
    }
}