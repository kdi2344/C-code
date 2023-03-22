using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230316_homeWork_diamond
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("홀수를 입력해주세요: ");
            int num = int.Parse(Console.ReadLine());
            while (num % 2 == 0)
            {
                Console.Write("홀수로 다시 입력해주세요: ");
                num = int.Parse(Console.ReadLine());
            }

            for (int i = 1; i <= num; i++)
            {
                if (i <= num / 2) //위에 삼각형
                {
                    for (int j = num/2-i+1; j >= 1; j--)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 1; j <= i*2-1; j++)
                    {
                        Console.Write("*");
                    }
                }
                else //중간부터 아래 삼각형
                {
                    for (int j = 1; j<i-(num/2); j++)
                    {
                        Console.Write(" ");
                    }
                    for (int j = (num-i)*2+1; j >= 1; j--)
                    {
                        Console.Write("*");
                    }
                }
                
                Console.WriteLine();
            }

        }
    }
}
