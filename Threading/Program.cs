using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Programm
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            var mainTrhead = Thread.CurrentThread.Name = "MainThread";
            Console.WriteLine($"Основной поток запущен {mainTrhead}");

            // Метод в отдельном потоке
            Task task = new Task(Print);

            

            task.Start();

            // Вычисления в основном потоке
            for (int i = 0; i < 60; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(".");
                Thread.Sleep(100);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Основной поток завершен {mainTrhead}");
            Console.ReadLine();
        }

        static void Print()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var methodTrhead = Thread.CurrentThread.Name = "MethodThread";
            Console.WriteLine($"Поток метода запущен: {methodTrhead}");

            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"В методе {methodTrhead} подсчет равен " + count);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Поток метода завершен {methodTrhead}");
        }
    }
}