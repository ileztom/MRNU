namespace MRNU
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Уравнение: y = 2x^2 - 2x - 3");

            Func<double, double> equation = x => 2 * x * x - 2 * x - 3;

            Func<double, double> derivative = x => 4 * x - 2;

            Console.WriteLine("Введите начальное приближение:");
            double initialGuess = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите критерий останова :");
            double epsilon = Convert.ToDouble(Console.ReadLine());

            double result = NewtonRaphsonMethod(equation, derivative, initialGuess, epsilon);

            Console.WriteLine($"Решение: x = {result}");
            Console.WriteLine($"Значение уравнения в найденной точке: y = {equation(result)}");
        }
        static double NewtonRaphsonMethod(Func<double, double> equation, Func<double, double> derivative, double initialGuess, double epsilon)
        {
            double x0 = initialGuess;
            double x1 = x0 - equation(x0) / derivative(x0);

            while (Math.Abs(x1 - x0) > epsilon)
            {
                x0 = x1;
                x1 = x0 - equation(x0) / derivative(x0);
            }

            return x1;
        }
    }
}
