using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230316_homeWork_star
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("숫자를 입력해주세요: ");

            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n=========================\n");

            for (int i = 1; i <= num; i++)
            {
                for (int j = num-i; j >= 1; j--)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n=========================\n");

            for (int i = num; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n=========================\n");

            for (int i = num; i >= 1; i--)  //i = 5 4 3 2 1
            {
                for (int j = 1; j<=num-i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
