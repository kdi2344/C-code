using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _0230327_makeStack
{
    class Program
    {
        static void print_stack(string[] array, ref int index)
        {
            Console.WriteLine("\n당신의 스택 현황 \n");
            if (index == 0)
            {
                Console.WriteLine("   비어있음   \n");
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    Console.Write("{0}: {1}   ", i + 1, array[i]);
                }
                Console.WriteLine("\n");
            }
        }
        static string[] Push(string[] array, ref int index)
        {
            string[] result = new string[index + 1];
            for (int i = 0; i < index; i++)
            {
                result[i] = array[i];
            }
            Console.Write("\nPush할 내용을 입력해주세요: ");
            string input = Console.ReadLine();
            Console.WriteLine(".");
            Thread.Sleep(350);
            Console.WriteLine(".");
            Thread.Sleep(350);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.WriteLine("입력되었습니다.");
            result[index] = input;
            index++;
            Console.ReadLine();
            Console.Clear();
            return result;
        }
        static void Pop(string[] array, ref int index)
        {
            if (index == 0)
            {
                Console.WriteLine("\nPop할 내용이 없습니다. Push후 Pop해주세요");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("\n내용 ~{0}~을 Pop합니다.", array[index - 1]);
                Console.WriteLine(".");
                Thread.Sleep(350);
                Console.WriteLine(".");
                Thread.Sleep(350);
                Console.WriteLine(".");
                Thread.Sleep(500);
                Console.WriteLine("처리되었습니다.");
                index--;
                array[index] = " ";
                Console.ReadLine();
                Console.Clear();
            }
        }
        static void Main(string[] args)
        {
            string[] array = new string[10];
            int input = 1;
            int index = 0;
            while (input != 0)
            {
                try
                {
                    print_stack(array, ref index);
                    Console.Write("1. push         2. pop\n\n 행동을 입력해주세요: ");
                    input = int.Parse(Console.ReadLine());
                    if (input != 1 && input != 2)
                    {
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        switch (input)
                        {
                            case 1:
                                array = Push(array, ref index);
                                break;
                            case 2:
                                Pop(array, ref index);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
