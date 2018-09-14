using Deveel.Math;

namespace KexlesFunctions
{
    public class Calculations
    {
        public static BigDecimal FahrenheitToKexle(BigDecimal fahrenheit)
        {
            MathContext mcInt = new MathContext(9999, RoundingMode.Ceiling);
            BigDecimal f2 = fahrenheit.Subtract(27.0, mcInt);
            BigDecimal s1f2s3 = f2.Multiply(0.6, mcInt);
            BigDecimal s1f2 = new BigDecimal(2634.0).Divide(s1f2s3, mcInt);
            return s1f2.Subtract(4.0, mcInt);
        }
    }
}