using System.Data;
using Microsoft.Data.SqlClient;

namespace ApiProductos.Data;

public class DapperContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("SqlServerConnection")
            ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'SqlServerConnection'.");
    }

    public IDbConnection CreateConnection()
        => new SqlConnection(_connectionString);
}