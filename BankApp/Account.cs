using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{

    public delegate void AccountHandler(string message);

    public class Account
    {
        //Переменная делегата
        AccountHandler? taken;
        AccountHandler? added;

        public event AccountHandler Notify;

        int sum;

        public int Sum
        {
            get
            {
                return sum;
            }
            set
            {
                sum = value;
                OnSumChanged();
            }
        }

        // через конструктор устанавливается начальная сумма на счете
        public Account(int sum)
        {
            this.sum = sum;
        }

        void OnSumChanged()
        {
            Notify?.Invoke(Sum.ToString());
        }

            // добавить средства на счет
            public void Add(int sum)
        {
            this.Sum += sum;
            added?.Invoke($"На счет поступило {sum} Р");
        }

        // взять деньги с счета
        public void Take(int sum)
        {
            if (this.Sum >= sum)
            {
                this.Sum -= sum;
                // вызываем делегат, передавая ему сообщение
                taken?.Invoke($"Со счета списано {sum} Р");
            }
            else
            {
                taken?.Invoke($"Нельзя снять {sum}. Баланс: {this.Sum} Р");
            }
        }


        public void RegisterHandlerTaken(AccountHandler del)
        {
            taken = del;
        }

        public void RegisterHandlerAdded(AccountHandler del)
        {
            added = del;
        }

        void LogThatDeligateBeenInvoked(AccountHandler del)
        {
            Console.WriteLine($">>>>>Invoking delegate {del?.Method.Name}");
        }

    }
}
