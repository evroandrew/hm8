using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask8
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArrayList<int> myList = new MyArrayList<int>();
            myList.Add(10);
            myList.Add(11);
            myList.Add(12);
            myList.Insert(0, 123);
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
            }
        }
    }
}
