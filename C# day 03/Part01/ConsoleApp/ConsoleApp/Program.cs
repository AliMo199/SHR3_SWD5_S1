using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Problem1
            //string input;
            //int x;
            //Console.Write("input: ");
            //input = Console.ReadLine();
            //try
            //{
            //    x = Convert.ToInt32(input);
            //    Console.WriteLine("x = " + x);
            //    x=int.Parse(input);
            //    Console.WriteLine("x = " + x);
            //}

            //catch (Exception ex)
            //{
            //    Console.WriteLine("An error occurred: " + ex.Message);

            //}
            #endregion
            #region Problem2
            //string x;
            //Console.Write("Enter: ");
            //x = Console.ReadLine();
            //if (int.TryParse(x, out int result))
            //{
            //    Console.WriteLine("Valid integer: " + result);
            //}
            //else
            //{
            //    Console.WriteLine("Invalid input, not an integer.");
            //}
            #endregion
            #region Problem3
            //object obj;
            //obj = 10;
            //Console.WriteLine(obj.GetHashCode());
            //obj = "Hello";
            //Console.WriteLine(obj.GetHashCode());
            //obj = 10.555544;
            //Console.WriteLine(obj.GetHashCode());
            #endregion
            #region Problem4
            //StringBuilder sb = new StringBuilder("ali");
            //object obj1 = new object();
            //obj1 = sb;
            //object obj2 = obj1;
            //obj2 = sb.Append(" and ahmed");
            //Console.WriteLine(obj1);
            //Console.WriteLine(obj2);
            #endregion
            #region Problem5
            //string st = "ali";
            //Console.WriteLine(st.GetHashCode());
            //st = st + " ,Hi Willy";
            //Console.WriteLine(st.GetHashCode());
            #endregion
            #region Problem6
            //StringBuilder sb = new StringBuilder("Text");
            //Console.WriteLine(sb.GetHashCode());
            //sb.Append(" ,Hi Willy");
            //Console.WriteLine(sb.GetHashCode());
            #endregion
            #region Problem7
            //int x;
            //int y;
            //Console.Write("Enter first number: ");
            //x = int.Parse(Console.ReadLine());
            //Console.Write("Enter second number: ");
            //y = int.Parse(Console.ReadLine());
            //Console.WriteLine("sum of " + x +" + "+ y+" = "+(x+y));
            //string Msg = string.Format("sum of {0} + {1} = {2}", x, y, (x + y));
            //Console.WriteLine(Msg);
            //Console.WriteLine($"Sum of {x} + {y} = {x + y}");
            #endregion
            #region Problem8
            //StringBuilder sb = new StringBuilder();
            //Console.Write("Add Text: ");
            //sb.Append(Console.ReadLine());
            //Console.Write("Replace Text: ");
            //string replaceText = Console.ReadLine();
            //Console.Write("With: ");
            //string withText = Console.ReadLine();
            //sb.Replace(replaceText, withText);
            //Console.Write("Insert text: ");
            //string insertText = Console.ReadLine();
            //Console.Write("Insert at index: ");
            //int index = int.Parse(Console.ReadLine());
            //sb.Insert(index, insertText);
            //Console.Write("Remove text:");
            //string removeText = Console.ReadLine();
            //Console.Write("Remove at index: ");
            //int removeIndex = int.Parse(Console.ReadLine());
            //sb.Remove(removeIndex, removeText.Length);
            //Console.WriteLine(sb);
            #endregion

        }
    }
}