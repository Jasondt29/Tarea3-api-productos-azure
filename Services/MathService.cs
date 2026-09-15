namespace ApiProductos.Services;

public class MathService
{
    public int CalcularMCD(int dividendo, int divisor)
    {
        while (divisor != 0)
        {
            int residuo = dividendo % divisor;
            dividendo = divisor;
            divisor = residuo;
        }

        return dividendo;
    }
}