namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // создаем банковский счет
            Account account = new Account(200);

            account.Notify += PrintBalance;

            account.Take(150);
            // Добавляем в делегат ссылку на метод PrintSimpleMessage
            account.RegisterHandlerTaken(PrintSimpleMessage);
            // Два раза подряд пытаемся снять деньги
            account.Take(100);
            account.Take(150);

            account.RegisterHandlerAdded(PrintAddInfo);

            account.Add(150);
            account.RegisterHandlerTaken(PrintBeautifulMessage);
            account.Take(100);
            account.Take(100);

            //account.Notify("123");
            //account.taken("123");


            void PrintSimpleMessage(string message) => Console.WriteLine(message);

            void PrintBeautifulMessage(string message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"***{message}***");
                Console.ForegroundColor = ConsoleColor.White;
            }

            void PrintAddInfo(string message)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.White;
            }

            void PrintBalance(string bal)
            {
                Console.WriteLine($"Ваш баланс - {bal} Р");
            }

        }
    }
}
