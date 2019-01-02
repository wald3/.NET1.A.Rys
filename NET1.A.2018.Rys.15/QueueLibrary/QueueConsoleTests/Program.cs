﻿using System;
using QueueLibrary;

using System.Collections.Generic;

namespace QueueConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueLibrary.Queue<int> q = new QueueLibrary.Queue<int>();

            int[] a = new[] {1, 2, 3, 4, 5, 6, 7, 8};

            foreach (var num in a)
            {
                q.Enqueue(num);
            }

            var s = q.GetEnumerator();
            foreach (var q_item in q)
            {
                Console.WriteLine(q_item);
            }

        }
    }
}