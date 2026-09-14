using ApiProductos.Models;
using ApiProductos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiProductos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductoRepository _repository;

    public ProductosController(IProductoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Producto>>> GetAll()
    {
        var productos = await _repository.GetAllAsync();
        return Ok(productos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Producto>> GetById(int id)
    {
        var producto = await _repository.GetByIdAsync(id);
        if (producto is null)
            return NotFound(new { mensaje = $"No existe un producto con Id {id}" });

        return Ok(producto);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] ProductoDto producto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var newId = await _repository.CreateAsync(producto);
        var creado = await _repository.GetByIdAsync(newId);

        return CreatedAtAction(nameof(GetById), new { id = newId }, creado);
    }
}