using System;
using System.Runtime.InteropServices;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Problem1
            /*
             * This is a simple program that adds two 
             * numbers and prints the result.
             */
            int x = 10;
            int y = 20;
            int sum = x + y; //30
            Console.WriteLine(sum);
            #endregion
            #region Problem2
            //int x = "10"; ->  //"10"
            //console.WriteLine(x + y); -> // +y
            int x = 10;
            Console.WriteLine(x);
            #endregion
            #region Problem3
            string name = "Ali Mohamed Elgamal";
            int age = 21;
            decimal salary = 100000.50m;
            bool IsStudent = true;
            #endregion
            #region Problem4
            class point
            {
                public int num;
            }
            point a = new point();
            a.num = 10;
            point b = a;
            b.num = 20;
            Console.WriteLine("a = " + a.num);
            Console.WriteLine("b = " + b.num);
            #endregion
            #region Problem5
            int x = 15;
            int y = 4;
            Console.WriteLine(x+y);
            Console.WriteLine(x-y);
            Console.WriteLine(x*y);
            Console.WriteLine(x/y);
            Console.WriteLine(x%y);
            #endregion
            #region Problem6
            int num= Convert.ToInt32(Console.ReadLine());
            bool valid = (num % 2 == 0 && num > 10) ? true : false;
            #endregion
            #region Problem7
            double num1 = Convert.ToDouble(Console.ReadLine());
            int num2 = (int)num1; //explicit
            num1=num2; //implicit
            #endregion
            #region Problem8
            Console.WriteLine("Enter your age:");
            string input = Console.ReadLine();
            int age=int.Parse(input);
            bool IsValid = age > 0?true:false;
            #endregion
            #region Problem9
            int x = 5;
            Console.WriteLine(x++);
            Console.WriteLine(x);
            x = 5;
            Console.WriteLine(++x);
            Console.WriteLine(x);
            #endregion
        }
    }
}
