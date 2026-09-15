using ApiProductos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiProductos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MCDController : ControllerBase
{
    private readonly MathService _mathService;

    public MCDController(MathService mathService)
    {
        _mathService = mathService;
    }

    // GET: api/mcd/48/18
    [HttpGet("{dividendo:int}/{divisor:int}")]
    public ActionResult Calcular(int dividendo, int divisor)
    {
        if (divisor == 0 && dividendo == 0)
            return BadRequest(new { mensaje = "Dividendo y divisor no pueden ser ambos 0." });

        var mcd = _mathService.CalcularMCD(dividendo, divisor);

        return Ok(new
        {
            dividendo,
            divisor,
            mcd
        });
    }
}