using System;
using System.Collections.Generic;
using System.Linq;

namespace TestLinq
{
    class Program
    {
        //linq puzzles
        //https://www.w3resource.com/csharp-exercises/linq/index.php

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            FindNumberThatDevidedByTwo();
            FindNumbersBetweenTwoConditions();
            FindNumbersThatSquarMoreThan();
            FindCountSameNumber();
        }

        public static void ShowTheResults<T>(IEnumerable<T> list) 
        {
            foreach (var item in list)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine("\n---\n");
        }

        //task1
        public static void FindNumberThatDevidedByTwo() 
        {
            Console.WriteLine("FindNumberThatDevidedByTwo");

            int[] n1 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var d = n1.Where(n => n%2 ==0);

            // The second part is Query creation.
            // nQuery is an IEnumerable<int>
            var nQuery =
                from VrNum in n1
                where (VrNum % 2) == 0
                select VrNum;

            ShowTheResults(nQuery);
            ShowTheResults(n1.Where(n => n % 2 == 0));
        }

        //task2
        public static void FindNumbersBetweenTwoConditions() 
        {
            Console.WriteLine("FindNumbersBetweenTwoConditions");

            int[] n1 = {
                1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14
            };

            var nQuery =
                from numb in n1
                where numb > 0
                where numb < 12
                select numb;

            ShowTheResults(nQuery);
            ShowTheResults(n1.Where(n => n > 0 && n <12));
        }

        //task3
        public static void FindNumbersThatSquarMoreThan() 
        {
            Console.WriteLine("FindNumbersThatSquarMoreThan");

            var arr1 = new[] { 3, 9, 2, 8, 6, 5, 4 };

            var q = from numb in arr1 
                    let sqr = numb * numb
                    where sqr > 20
                    select new { numb, sqr };
            

            ShowTheResults(q);

            var q1 = arr1.Select(n => new { numb = n, sqr = n * n }).Where(n => n.sqr > 20);
            ShowTheResults(q1);
        }

        //task4
        public static void FindCountSameNumber() 
        {
            Console.WriteLine("FindCountSameNumber");

            int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };

            var q = from numb in arr1
                    group numb by numb into gr
                    select gr;

            //order ++++
            var q1 = from numb in arr1
                    group numb by numb into gr
                    select gr;

            //var d = q.

            Console.WriteLine("\nThe number and the Frequency are : \n");
            foreach (var arrNo in q)
            {
                Console.WriteLine("Number " + arrNo.Key + " appears " + arrNo.Count() + " times");
            }
            Console.WriteLine("\n");

        }
    }
}
