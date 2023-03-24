using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230317_homeWork_numBaseball
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             1. 숫자야구게임
1~9 랜덤하게 숫자가 나옴 3개
ex)
7 8 1
7 8 1 숫자도 같고 자리도 같으면 strike, 
1 7 8 숫자는 같은데 자리만 다르면 ball
3 strike -> 1out

조건
1. 유저는 1~9까지만 입력 가능, 예외처리 필요
2. 10판 가능 
3. 3 out이면 종료

             */
            Random random = new Random();
            int over = 0;
            int[] num = new int[9];
            int first;
            int second;
            int temp;

            Console.WriteLine("숫자 야구 게임을 시작합니다.\n세 자리의 숫자를 맞추시면 정답입니다.");

            while (over < 3) //out이 3번이 아닐때 실행
            {
                Console.WriteLine("==========================================================");
                Console.WriteLine("3 over가 되면 게임을 종료합니다. 현재 over: {0} / 3", over);
                bool correct = false;
                for (int i =0; i < 9; i++)
                {
                    num[i] = i+1;
                }
                for (int i = 0; i < 1000; i++)
                {
                    first = random.Next(9);
                    second = random.Next(9);
                    temp = num[first];
                    num[first] = num[second];
                    num[second] = temp;
                }

                int[] answer = new int[3];

                for (int i = 0; i < 3; i++)
                {
                    answer[i] = num[i];
                }
                int round = 1;
                while (!correct)
                {
                    int strike = 0;
                    int ball = 0;
                    int[] input = new int[3];
                    Console.WriteLine("\n기회는 10번입니다. {0} / 10", round);
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write("1부터 9까지의 수 중 겹치지 않게 {0}번째 수를 입력해주세요: ", i + 1);
                        input[i] = int.Parse(Console.ReadLine());
                        int dup = 0;
                        for (int j = 0; j < i; j++)
                        {
                            if (input[i] == input[j])
                            {
                                dup = 1;
                            }
                        }
                        while (input[i] > 9 || input[i] < 1 || dup == 1)
                        {
                            Console.Write("1부터 9까지로 겹치지 않게 {0}번째 수를 다시 입력해주세요: ", i + 1);
                            dup = 0;
                            input[i] = int.Parse(Console.ReadLine());
                            for (int j = 0; j < i; j++)
                            {
                                if (input[i] == input[j])
                                {
                                    dup = 1;
                                }
                            }
                        }
                    }
                    //중복없이, 종류에 맞게 입력 받기 완료
                    if (input[0] == answer[0] && input[1] == answer[1] && input[2] == answer[2])
                    {
                        Console.WriteLine("3strike로 정답입니다.");
                        correct = true;
                        over++;
                    }
                    else
                    {
                        if (input[0] == answer[0])
                        {
                            strike++;
                        }
                        if (input[1] == answer[1])
                        {
                            strike++;
                        }
                        if (input[2] == answer[2])
                        {
                            strike++;
                        }
                        if (input[0] == answer[1] || input[0] == answer[2])
                        {
                            ball++;
                        }
                        if (input[1] == answer[0] || input[1] == answer[2])
                        {
                            ball++;
                        }
                        if (input[2] == answer[0] || input[2] == answer[1])
                        {
                            ball++;
                        }
                        Console.WriteLine("{0}strike, {1}ball", strike, ball);
                    }
                    round++;
                    if (round == 11)
                    {
                        Console.WriteLine("숫자 맞추기에 실패하셨습니다.\n정답은 {0} {1} {2}였습니다.", answer[0], answer[1], answer[2]);
                        break;
                    }
                }
                Console.WriteLine("<Enter를 누르면 넘어갑니다>");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
