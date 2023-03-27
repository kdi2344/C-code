using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230320_homeWork_bingo
{
    class Program
    {
        static int computer_choose(int[,] computer) //현재 빙고판에 존재하는 수 중에 숫자를 골라서 return한다
        {
            Random random = new Random();
            int choose = 0;
            int i;
            int j;
            while (true)
            {
                choose = random.Next(25); //0 ~ 24중 하나 선택
                i = choose / 5;           //5로 나눈 몫을 세로
                j = choose % 5;           //5로 나눈 몫을 가로
                if (computer[i, j] != 0)  //이미 선택된 친구라면 재실행
                {
                    break;
                }
            }
            return computer[i, j];        //선택되지 않은 숫자를 return한다
        }
        static bool find_num(int[,] arr, int num)         //빙고 2차원 배열에서 해당 숫자를 찾는다
        {
            bool find = false;                            
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (num == arr[i, j])                 //2차원 배열의 원소와 일치한다면
                    {
                        find = true;                      //찾음 
                        arr[i, j] = 0;                    //해당 값을 0으로 바꿔준다 (선택됨)
                    }
                }
            }
            return find; //못찾았다면 false를 반환한다
        }
        static int check_bingo(int[,] arr) //빙고 줄이 몇 줄인지 센다
        {
            int check = 0;
            for (int i = 0; i < 5; i++)
            {
                if (arr[i, 0] == 0 && arr[i, 1] == 0 && arr[i, 2] == 0 && arr[i, 3] == 0 && arr[i, 4] == 0) //가로줄
                {
                    check++;
                }
                if (arr[0, i] == 0 && arr[1, i] == 0 && arr[2, i] == 0 && arr[3, i] == 0 && arr[4, i] == 0) //세로줄
                {
                    check++;
                }
            }
            if (arr[0, 0] == 0 && arr[1, 1] == 0 && arr[2, 2] == 0 && arr[3, 3] == 0 && arr[4, 4] == 0) //대각선
            {
                check++;
            }
            if (arr[4, 0] == 0 && arr[3, 1] == 0 && arr[2, 2] == 0 && arr[1, 3] == 0 && arr[0, 4] == 0) //대각선
            {
                check++;
            }
            return check;
        }
        static void show_bingo(int[,] arr) //5*5의 빙고판을 보여준다
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n    ========================================================");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine();
                Console.Write("    ");
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("∥   ");
                    if (arr[i, j] == 0)  //숫자라 0이라면 이미 선택된 숫자라 노란색으로 보여준다
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }
                    Console.Write(" {0, 2}   ", arr[i, j]);
                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("∥");
                Console.WriteLine("\n    ========================================================");
            }
            Console.ResetColor();
        }
        static int[,] Create_bingo()
        {
            int length = 5;
            int[,] arr = new int[length, length];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = 5 * i + (j + 1); //1~25 순서대로 [5][5]에 넣기
                }
            }
            return arr;
        }
        static int[,] shuffle(int[,] arr, int seed)  //seed없이 랜덤을 메소드에서 진행한다면 어째서인지 동일한 값이 나와 seed값을 주어 다르게 처리
        {
            Random random = new Random(seed);
            int firsti;
            int firstj;
            int secondi;
            int secondj;
            int temp;
            for (int i = 0; i < 1000; i++)
            {
                firsti = random.Next(5);  //이차원 배열에서 섞는거라 가로줄, 세로줄을 랜덤으로 골라 처리
                firstj = random.Next(5); 
                secondi = random.Next(5);
                secondj = random.Next(5);
                temp = arr[firsti, firstj];
                arr[firsti, firstj] = arr[secondi, secondj];
                arr[secondi, secondj] = temp;
            }
            return arr;
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            int seed1 = random.Next(100);
            int seed2 = random.Next(100,200);

            Console.SetWindowSize(65, 50);
            int[,] player = Create_bingo();
            Console.WriteLine();
            shuffle(player, seed1); //[5][5]에 1~25 랜덤한 값 저장됨
            int[,] computer = Create_bingo();
            shuffle(computer, seed2); //seed값과 같이 shuffle

            while (check_bingo(player) < 4 && check_bingo(computer) < 4) //둘 중 빙고수가 4 이상인 플레이어가 없을동안 반복
            {
                Console.WriteLine("두 플레이어의 빙고 현황입니다.");
                show_bingo(player);
                int a = check_bingo(player);
                Console.WriteLine("플레이어의 빙고 수: {0}", a);
                show_bingo(computer);
                int b = check_bingo(computer);
                Console.WriteLine("컴퓨터의 빙고 수: {0}", b);

                bool find = false;
                int input = 2;
                while (!find)
                {
                    Console.Write("1~25중 본인의 빙고판에서 없애고 싶으신 숫자를 입력해주세요: ");
                    input = int.Parse(Console.ReadLine());
                    if (input == 0)
                    {
                        continue;
                    }
                    find = find_num(player, input);
                }
                find_num(computer, input);
                if (check_bingo(player) >= 4 || check_bingo(computer)>=4)
                {
                    break;
                }
                int choose = computer_choose(computer);
                Console.WriteLine("컴퓨터의 선택 : {0}", choose);
                find_num(player, choose);
                find_num(computer, choose);
                Console.ReadLine();
                Console.Clear();
            }

            if (check_bingo(player) >= 4)
            {
                Console.Clear();
                Console.WriteLine("플레이어의 승리입니다.");
                Console.WriteLine("    ========================================================");

            }
            else
            {
                Console.Clear();
                Console.WriteLine("컴퓨터의 승리입니다.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("    ========================================================");
                Console.WriteLine("    ========================================================");
                Console.WriteLine("    ===                                                  ===");
                Console.WriteLine("    ===                                                  ===");
                Console.WriteLine("    ===          1101001                 0010001         ===");
                Console.WriteLine("    ===        01       00             11       00       ===");
                Console.WriteLine("    ===                                                  ===");
                Console.WriteLine("    ===                                                  ===");
                Console.WriteLine("    ===            1                         0           ===");
                Console.WriteLine("    ===             0010010101100100001001110            ===");
                Console.WriteLine("    ===              0                     1             ===");
                Console.WriteLine("    ===               1                   0              ===");
                Console.WriteLine("    ===                0110010110101000100               ===");
                Console.WriteLine("    ===                                                  ===");
                Console.WriteLine("    ========================================================");
                Console.WriteLine("    ========================================================");
                Console.WriteLine("                             ======                         ");
                Console.WriteLine("                             ======                         ");
                Console.WriteLine("                             ======                         ");
                Console.WriteLine("                             ======                         ");
                Console.WriteLine("    ========================================================");
                Console.WriteLine("    ========================================================");
                Console.ResetColor();
            }
        }
    }
}
