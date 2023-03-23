using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230322_homeWork_seating
{
    class Program
    {
        static void shuffle(ref int[] mix)
        {
            for (int i = 0; i < 29; i++)
            {
                mix[i] = i;
            }
            Random rand = new Random();
            for (int i = 0; i < 1000; i++)
            {
                int first = rand.Next(0, 29);
                int second = rand.Next(0, 29);
                int temp = mix[first];
                mix[first] = mix[second];
                mix[second] = temp;
            }
        }
        static void Main(string[] args)
        {
            int student_num;
            Console.Write("학생 수를 29명 이하로 입력해주세요: ");
            student_num = int.Parse(Console.ReadLine());
            while (student_num > 29 || student_num < 1)
            {
                Console.Write("학생 수를 29명 이하로 입력해주세요: ");
                student_num = int.Parse(Console.ReadLine());
            }

            int[] mix = new int[29];
            shuffle(ref mix);

            Random rand = new Random();

            string[] student = new string[29];
            student_info student_1 = new student_info("강단이 여 010-2676-3790");
            student_info student_2 = new student_info("강윤석 남 010-9913-9662");
            student_info student_3 = new student_info("경민아 여 010-2256-2104");
            student_info student_4 = new student_info("고석환 남 010-9635-0224");
            student_info student_5 = new student_info("공병현 남 010-9807-2898");
            student_info student_6 = new student_info("구윤성 남 010-6677-5821");
            student_info student_7 = new student_info("국동근 남 010-2340-2804");
            student_info student_8 = new student_info("김대현 남 010-8692-2778");
            student_info student_9 = new student_info("김민수 남 010-8802-6512");
            student_info student_10 = new student_info("김윤혜 여 010-4434-0767");
            student_info student_11 = new student_info("김현희 여 010-4043-9136");
            student_info student_12 = new student_info("노소영 여 010-9037-0225");
            student_info student_13 = new student_info("목지아 여 010-9042-7403");
            student_info student_14 = new student_info("박라현 여 010-7653-2820");
            student_info student_15 = new student_info("박상연 남 010-7528-9060");
            student_info student_16 = new student_info("박주혜 여 010-4204-9704");
            student_info student_17 = new student_info("성민경 남 010-3941-1247");
            student_info student_18 = new student_info("양경훈 남 010-2988-6736");
            student_info student_19 = new student_info("이도엽 남 010-5174-5496");
            student_info student_20 = new student_info("이상훈 남 010-3505-2135");
            student_info student_21 = new student_info("이성준 남 010-9519-1558");
            student_info student_22 = new student_info("이수민 남 010-2959-6265");
            student_info student_23 = new student_info("이유리 여 010-2094-3496");
            student_info student_24 = new student_info("임종서 남 010-7657-7526");
            student_info student_25 = new student_info("정수민 남 010-3456-6254");
            student_info student_26 = new student_info("제현준 남 010-2230-4610");
            student_info student_27 = new student_info("주성현 남 010-9524-3357");
            student_info student_28 = new student_info("최영일 남 010-2123-7048");
            student_info student_29 = new student_info("허진 여 010-4637-2880");

            Console.WriteLine();
            student_info[] name = new student_info[29] { student_1, student_2, student_3, student_4, student_5, student_6, student_7, student_8, student_9, student_10, student_11, student_12, student_13, student_14, student_15, student_16, student_17, student_18, student_19, student_20, student_21, student_22, student_23, student_24, student_25, student_26, student_27, student_28, student_29 };
            student_info[] ran = new student_info[29];

            for (int i = 0; i < 29; i++)
            {
                ran[i] = name[mix[i]];
            }

            Console.WriteLine("----------------------------------------------------------------------------");
            for (int i = 0; i < student_num; i++)
            {
                Console.Write(" {0,3}\t", ran[i].name);
                if (i % 4 == 3)
                {
                    if (i % 8 == 7)
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write("  ||||\t");
                    }
                }
            }
            Console.WriteLine("\n----------------------------------------------------------------------------");

            Console.Write("\n정보를 더 알아보려는 사람의 이름을 입력하세요 (종료시 end): ");
            string search = Console.ReadLine();
            while (search != "end")
            {
                for (int i = 0; i < student_num; i++)
                {
                    if (search.Equals(name[i].name))
                    {
                        Console.WriteLine("\n{0}의 정보를 출력합니다.", name[i].name);
                        Console.WriteLine("이름: {0}", name[i].name);
                        Console.WriteLine("성별: {0}", name[i].gender);
                        Console.WriteLine("전화번호: {0}", name[i].phone);
                        Console.Write("\n정보를 더 알아보려는 사람의 이름을 입력하세요 (종료시 end): ");
                        search = Console.ReadLine();
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.Write("\n해당하는 이름의 사람이 없습니다. 다시 입력해주세요 (종료시 end): ");
                search = Console.ReadLine();
            }
        }
    }
}
