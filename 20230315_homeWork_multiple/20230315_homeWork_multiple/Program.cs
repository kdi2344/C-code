using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230315_homeWork_multiple
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;
            Console.Write("출력하고 싶으신 구구단 숫자를 입력해주세요: ");
            input = int.Parse(Console.ReadLine());
            int n = 1;
            while (n < 10)
            {
                Console.WriteLine("{0} * {1} = {2}",input, n,  input * n);
                n++;
            }
        }
    }
}
