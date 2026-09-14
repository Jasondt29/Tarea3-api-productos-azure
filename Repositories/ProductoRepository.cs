using ApiProductos.Data;
using ApiProductos.Models;
using Dapper;

namespace ApiProductos.Repositories;

public class ProductoRepository : IProductoRepository
{
    private readonly DapperContext _context;

    public ProductoRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Producto>> GetAllAsync()
    {
        const string query = "SELECT Id, Nombre, Precio, Cantidad FROM Productos ORDER BY Id";
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Producto>(query);
    }

    public async Task<Producto?> GetByIdAsync(int id)
    {
        const string query = "SELECT Id, Nombre, Precio, Cantidad FROM Productos WHERE Id = @Id";
        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Producto>(query, new { Id = id });
    }

    public async Task<int> CreateAsync(ProductoDto producto)
    {
        const string query = @"
            INSERT INTO Productos (Nombre, Precio, Cantidad)
            VALUES (@Nombre, @Precio, @Cantidad);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<int>(query, producto);
    }
}