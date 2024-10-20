using System;
using System.Threading;


namespace TestApplicationForLection // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        delegate int Operation(int a, int b);
        static void Main(string[] args)
        {
            
            Console.WriteLine("Пример номер 1");
            sample1();

            Console.WriteLine("-----------------------------------------------");

            Console.WriteLine("Пример номер 2");
            sample2();

        }

        static void sample1()
        {
            Operation operation = Add; // делегат указывает на метод Add
            int result1 = operation(4, 5); // фактически Сложение(4, 5)

            operation = Multiply; // теперь делегат указывает на метод Multiply
            int result2 = operation(4, 5); // фактически Умножение(4, 5)

            Console.WriteLine(result1); // 9
            Console.WriteLine(result2); // 20

            int Add(int x, int y) => x + y;

            int Multiply(int x, int y) => x * y;

            Console.ReadKey();
        }

        static void sample2()
        {
            // Присваиваем делегату метод Add
            Operation operation = Add;

            // Добавляем еще один метод Multiply к делегату
            operation += Multiply;

            // Вызываем делегат с аргументами 4 и 5
            int result = operation(4, 5);  // фактически вызывается Add(4, 5), затем Multiply(4, 5)

            // Результат работы последнего метода (Multiply)
            Console.WriteLine(result);  // Выведет 20, так как Multiply(4, 5) вернет 20
            // Метод сложения
            int Add(int x, int y)
            {
                Console.WriteLine($"Add: {x} + {y} = {x + y}");
                return x + y;
            }

            // Метод умножения
            int Multiply(int x, int y)
            {
                Console.WriteLine($"Multiply: {x} * {y} = {x * y}");
                return x * y;
            }

        }
    }
}


