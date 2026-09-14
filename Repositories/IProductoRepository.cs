using ApiProductos.Models;

namespace ApiProductos.Repositories;

public interface IProductoRepository
{
    Task<IEnumerable<Producto>> GetAllAsync();
    Task<Producto?> GetByIdAsync(int id);
    Task<int> CreateAsync(ProductoDto producto);
}