namespace APITemperaturas.Models;

public class Temperatura
{
    public double Fahrenheit { get; init; }
    public double Celsius { get; init; }
    public double Kelvin { get; init; }

    public Temperatura(double temperaturaFahrenheit)
    {
        if (temperaturaFahrenheit < -459.67)
        {
            throw new ArgumentException(
                $"Temperatura invalida na escala Fahrenheit: {temperaturaFahrenheit}");
        }

        Fahrenheit = temperaturaFahrenheit;
        Celsius = Math.Round((temperaturaFahrenheit - 32.0) / 1.8, 2);
        Kelvin = Math.Round(Celsius + 273.15, 2);
    }
}