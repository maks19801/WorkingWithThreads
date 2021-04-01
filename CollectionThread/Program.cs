using System;
using System.Collections.Generic;
using System.Threading;

namespace CollectionThread
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> collection = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                collection.Add(i);
            }
            
            Thread thread = new Thread(new ParameterizedThreadStart(ShowTheCollection));
            thread.Start((object)collection);
        }

        private static void ShowTheCollection(object collection)
        {
            foreach (var item in (List<int>)collection)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
