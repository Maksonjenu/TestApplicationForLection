using System;
using System.ComponentModel.Design;
using System.Reflection;
using System.Threading;


namespace TestApplicationForLection // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        delegate void CurrentAction();        // 1. Объявляем делегат
        static CurrentAction action;            // 2. Создаем переменную делегата

        static Thread t1 = new Thread(GetStatus);

        static void Main(string[] args)
        {
            action = MoveUp;            // 3. Присваиваем этой переменной адрес метода

            t1.Start();

            while (true)
            {
                var a = Console.ReadKey();
                switch (a.Key)
                {
                    case ConsoleKey.LeftArrow:
                        action = MoveLeft;
                        break;
                    case ConsoleKey.RightArrow:
                        action = MoveRight;
                        break;
                    case ConsoleKey.UpArrow:
                        action = MoveUp;
                        break;
                    case ConsoleKey.DownArrow:
                        action = MoveDown;
                        break;
                    case ConsoleKey.Spacebar:

                        var method = action.GetInvocationList().Any(x => x.Method.Name == "Boost");

                        if (method)
                        {
                            Console.WriteLine("Boost Removed.");
                            action -= Boost; // Если есть, удаляем Boost
                        }
                        else
                        {
                            Console.WriteLine("Boost added.");
                            action += Boost;  // Если нет, добавляем Boost
                        }
                        break;
                }

            }

            Console.ReadKey();
        }

        static void GetStatus()
        {
            while (true)
            {
                Thread.Sleep(500);
                action();
            }

        }

        static void Boost() => Console.WriteLine("BOOOOOOSTED");
        static void MoveUp() => Console.WriteLine("UP");
        static void MoveRight() => Console.WriteLine("RIGHT");
        static void MoveLeft() => Console.WriteLine("LEFT");
        static void MoveDown() => Console.WriteLine("DOWN");
    }
}


