using System;
using QueueLibrary;

using System.Collections.Generic;

namespace QueueConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueLibrary.Queue<int> q = new QueueLibrary.Queue<int>();
            int[] a = new[] {1, 2, 3, 4, 5, 6, 7, 8,8};


   
            foreach (var num in a)
            {
                q.Enqueue(num);
                //Console.Write("0 ");
            }
            q.Enqueue(9);// resize
            q.Dequeue();
            q.Dequeue();
            q.Enqueue(10);
            q.Dequeue();
            q.Enqueue(12);
            q.Enqueue(13);
            q.Enqueue(14);
            q.Enqueue(15);
            q.Enqueue(16);
            q.Enqueue(17);
            q.Enqueue(18);//resize
            q.Enqueue(19);
            Console.WriteLine(q.ToString()); 
            Console.WriteLine();

            string str = "";
            foreach (var _q in q)
            {
                str += _q.ToString()+", ";
            }
            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
