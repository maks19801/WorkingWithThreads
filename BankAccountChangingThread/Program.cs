using System;

namespace BankAccountChangingThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            bank.Name = "Privat24";
            bank.Percent = 10;
            bank.Money = 43000;
            bank.Money = 55000;

           
        }
    }
}
