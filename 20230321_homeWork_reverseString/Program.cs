using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230321_homeWork_reverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("뒤집을 문자열을 입력해주세요: ");
            string input = Console.ReadLine();
            Console.Write("!료완 기집뒤: ");
            string reverse_input = reverse_string(input);
            Console.WriteLine(reverse_input);
        }
        static string reverse_string(string str)
        {
            char[] str_char = str.ToCharArray();
            char[] reverse_char = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                reverse_char[str.Length - i - 1] = str_char[i];
            }
            string answer = new string(reverse_char);
            return answer;
        }
    }
}
