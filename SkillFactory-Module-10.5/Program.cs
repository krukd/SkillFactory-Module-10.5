namespace SkillFactory_Module_10._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter 1st number");
                int number1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter 2d number");
                int number2 = Convert.ToInt32(Console.ReadLine());

                ISum sum = new Calculator();
                ILogger logger = new Calculator();

                logger.Event("Выполняем сложение двух введенных вами чисел...");
                Console.Write("Сумма равна: ");

                sum.Sum(number1, number2);
            }
            catch (Exception ex)
            {

                ILogger logger = new Calculator();
                logger.Error("Something went wrong...");
                Console.WriteLine(ex.ToString());
            }
        }
    }

    public interface ISum
    {
        void Sum(int a, int b);
    }

    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }

    public class Calculator : ISum, ILogger
    {
        public void Sum(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        void ILogger.Error(string message)
        {
           Console.BackgroundColor = ConsoleColor.Red;
           Console.WriteLine(message);
        }

        void ILogger.Event(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
        }
    }
}