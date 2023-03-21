using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230315_homeWork_rsp_switch.ver_
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;
            string com = "";
            int result = 99; //result가 0이면 플레이어 패배, 1이면 무승부, 2면 승리
            int money = 10000;
            int bet = 1;
            int round = 0;
            while (money > 0 && round < 10)
            {
                Console.Write("당신의 소지금은 {0}원입니다.\n가위바위보에 베팅하실 금액을 입력해주세요: ", money);
                bet = int.Parse(Console.ReadLine());
                switch (money < bet)
                {
                    case true:
                        Console.WriteLine("당신의 소지금보다 많은 금액을 베팅하실 수 없습니다.");
                        Console.WriteLine("=================================");
                        break;
                    case false:

                        Random random = new Random();
                        int randCom = random.Next(3); //0, 1, 2중에 하나 랜덤, 가위, 바위, 보
                        switch (randCom)
                        {
                            case 0:
                                com = "가위";
                                break;
                            case 1:
                                com = "바위";
                                break;
                            case 2:
                                com = "보";
                                break;
                        }

                        Console.WriteLine("컴퓨터와 가위 바위 보를 합니다.\n가위를 원하시면 1, 바위를 원하시면 2, 보를 원하시면 3을 입력해주세요: ");
                        input = int.Parse(Console.ReadLine());
                        switch (input)
                        {
                            case 1: //플: 가위
                                switch (randCom)
                                {
                                    case 0: //컴 가위
                                        result = 1;
                                        break;
                                    case 1:
                                        result = 0;
                                        break;
                                    case 2:
                                        result = 2;
                                        break;
                                }
                                break;
                            case 2: //플: 바위
                                switch (randCom)
                                {
                                    case 0: //컴 가위
                                        result = 2;
                                        break;
                                    case 1:
                                        result = 1;
                                        break;
                                    case 2:
                                        result = 0;
                                        break;
                                }
                                break;
                            case 3: //플: 보
                                switch (randCom)
                                {
                                    case 0: //컴 가위
                                        result = 0;
                                        break;
                                    case 1:
                                        result = 2;
                                        break;
                                    case 2:
                                        result = 1;
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine("잘못된 입력입니다.");
                                break;
                        }
                        Console.WriteLine("=================================");
                        Console.WriteLine("컴퓨터: {0}", com);

                        switch (result)
                        {
                            case 0:
                                {
                                    Console.WriteLine("플레이어의 패배입니다.\n베팅금액의 2배를 잃습니다.");
                                    money -= bet * 2;

                                }
                                break;
                            case 1:
                                {
                                    Console.WriteLine("무승부입니다.\n베팅금액만큼을 잃습니다.");
                                    money -= bet;
                                }
                                break;
                            case 2:
                                {
                                    Console.WriteLine("승리하셨습니다.\n베팅금액의 2배를 얻습니다.");
                                    money += bet * 2;
                                }
                                break;
                        }
                        result = 99;
                        round++;
                        Console.WriteLine("=================================");
                        break;
                }

            }

            switch (money < 0)
            {
                case true:
                    Console.WriteLine("당신의 소지금은 {0}원으로, 거지가 돼서 파산하셨습니다. \n축하드립니다.", money);
                    break;
            }
        }
    }
}
