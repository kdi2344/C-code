using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20230327_homeWork_waiting
{
    class Program
    {
        static void print_waiting(Queue<string> wait)
        {
            Console.Write("현재 대기중인 사람: ");
            if (wait.Count == 0)
            {
                Console.WriteLine("없음");
            }
            else
            {
                foreach (object obj in wait)
                {
                    Console.Write($"{obj } ");
                }
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int input = 1;
            Queue<string> wait = new Queue<string>();
            while (input != 0)
            {
                try
                {
                    Console.Write("\n들어올 사람의 수를 입력해주세요: ");
                    input = int.Parse(Console.ReadLine());
                    for (int i = 0; i < input; i++)
                    {
                        Console.Write("{0}번째 사람: ", i + 1);
                        string name = Console.ReadLine();
                        wait.Enqueue(name);
                        Console.WriteLine("{0}이/가 입장합니다.", name);
                    }
                    Console.WriteLine();
                    print_waiting(wait);
                    for (int i = 0; i < input; i++)
                    {
                        Console.Write("{0}번째로 ", i + 1);
                        string name = wait.Dequeue();
                        Console.WriteLine("{0}이/가 나갑니다.\n", name);
                        print_waiting(wait);
                        Thread.Sleep(1000);
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
