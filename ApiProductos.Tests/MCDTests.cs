using ApiProductos.Services;
using Xunit;

namespace ApiProductos.Tests;

public class MCDTests
{
    [Fact]
    public void CalcularMCD_48y18_DebeRetornar6()
    {
        // Arrange
        var mathService = new MathService();

        // Act
        var resultado = mathService.CalcularMCD(48, 18);

        // Assert
        Assert.Equal(6, resultado);
    }

    [Fact]
    public void CalcularMCD_20y8_DebeRetornar4()
    {
        // Arrange
        var mathService = new MathService();

        // Act
        var resultado = mathService.CalcularMCD(20, 8);

        // Assert
        Assert.Equal(4, resultado);
    }

    [Theory]
    [InlineData(48, 18, 6)]
    [InlineData(20, 8, 4)]
    [InlineData(17, 5, 1)]
    [InlineData(100, 10, 10)]
    public void CalcularMCD_VariosCasos_DebeRetornarValorEsperado(int dividendo, int divisor, int esperado)
    {
        // Arrange
        var mathService = new MathService();

        // Act
        var resultado = mathService.CalcularMCD(dividendo, divisor);

        // Assert
        Assert.Equal(esperado, resultado);
    }
}