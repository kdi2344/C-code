using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230315_homeWork_rsp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string com = "";
            int result=99; //result가 0이면 플레이어 패배, 1이면 무승부, 2면 승리
            int money = 10000;
            int bet = 1;
            int round = 0;
            while (money > 0 && round <10)
            {
                Console.Write("당신의 소지금은 {0}원입니다.\n가위바위보에 베팅하실 금액을 입력해주세요: ", money);
                bet = int.Parse(Console.ReadLine());
                if (money < bet)
                {
                    Console.WriteLine("당신의 소지금보다 많은 금액을 베팅하실 수 없습니다.");
                    Console.WriteLine("=================================");
                }
                else
                {
                    Random random = new Random();
                    int randCom = random.Next(3); //0, 1, 2중에 하나 랜덤, 가위, 바위, 보
                    if (randCom == 0)
                    {
                        com = "가위";
                    }
                    else if (randCom == 1)
                    {
                        com = "바위";
                    }
                    else if (randCom == 2)
                    {
                        com = "보";
                    }

                    Console.WriteLine("컴퓨터와 가위 바위 보를 합니다.\n가위, 바위, 보 중 원하시는 것을 입력해주세요: ");
                    input = Console.ReadLine();
                    Console.WriteLine("\n플레이어: {0}", input);
                    
                    Console.WriteLine("컴퓨터: {0}", com);
                    if (input == "가위")
                    {
                        if (randCom == 1)
                        {
                            result = 0;
                        }
                        else if (randCom == 0)
                        {
                            result = 1;
                        }
                        else if (randCom == 2)
                        {
                            result = 2;
                        }
                    }
                    else if (input == "바위")
                    {
                        if (randCom == 2)
                        {
                            result = 0;
                        }
                        else if (randCom == 1)
                        {
                            result = 1;
                        }
                        else if (randCom == 0)
                        {
                            result = 2;
                        }
                    }
                    else if (input == "보")
                    {
                        if (randCom == 0)
                        {
                            result = 0;
                        }
                        else if (randCom == 2)
                        {
                            result = 1;
                        }
                        else if (randCom == 1)
                        {
                            result = 2;
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        result = 99;
                        bet = 99;
                    }
                   
                    if (result == 0 && bet != 99)
                    {
                        Console.WriteLine("플레이어의 패배입니다.\n베팅금액의 2배를 잃습니다.");
                        money -= bet * 2;
                    }
                    else if (result == 1 && bet != 99)
                    {
                        Console.WriteLine("무승부입니다.\n베팅금액만큼을 잃습니다.");
                        money -= bet;
                    }
                    else if (result == 2 && bet != 99)
                    {
                        Console.WriteLine("승리하셨습니다.\n베팅금액의 2배를 얻습니다.");
                        money += bet * 2;
                    }
                    else
                    {
                        round--;
                    }
                    round++;
                    Console.WriteLine("=================================");
                }
            }
            Console.WriteLine("당신의 소지금은 {0}원으로, 거지가 돼서 파산하셨습니다. \n축하드립니다.", money);
        }
    }
}
