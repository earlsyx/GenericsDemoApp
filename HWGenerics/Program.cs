using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TakeItem(true);
            Console.ReadLine();
        }

        public static void TakeItem<T>(T item)
        {
            T doubleItem = item;
            Console.WriteLine($"Item: {doubleItem}");
        }

    }

   

}
