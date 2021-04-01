using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace BankAccountChangingThread
{
    public class Bank
    {
        private string _name;
        private decimal _money;
        private double _percent;
        public decimal Money
        {
            get { return _money; }
            set
            {
                _money = value;
                ThreadStart ts = new ThreadStart(Save);
                Thread t = new Thread(ts);
                t.Start();
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                ThreadStart ts = new ThreadStart(Save);
                Thread t = new Thread(ts);
                t.Start();
            }
        }
        public double Percent
        {
            get { return _percent; }
            set
            {
                _percent = value;
                ThreadStart ts = new ThreadStart(Save);
                Thread t = new Thread(ts);
                t.Start();
            }
        }
        public void Save()
        {
            lock (this)
            {
                using (StreamWriter sw = new StreamWriter("bank.txt", false))
                {
                    sw.WriteLine($"p = { Percent} %");
                    sw.WriteLine($"name = {Name}");
                    sw.WriteLine($"money = {Money} $");
                }
            }
        }
    }
}

