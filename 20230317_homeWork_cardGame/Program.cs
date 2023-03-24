using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230317_homeWork_cardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] card = new int[52]; //52장의 카드
            Random random = new Random();
            
            for (int i = 0; i < card.Length; i++)
            {
                card[i] = i;
            }

            for (int i = 0; i < 1000; i++)
            {
                int first = random.Next(52);
                int second = random.Next(52);
                int temp = card[first];
                card[first] = card[second];
                card[second] = temp;
            }
            //0 ~ 51까지의 숫자를 랜덤하게 섞어 card에 저장함
            Console.SetWindowSize(60, 40);
            int turn = 0;
            int money = 5000;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("○●○●○●○●○●○●○●○●○●○●○●○●○●○●○●");
            Console.WriteLine("●                                                        ○");
            Console.WriteLine("○    $$$$$$$$   $$     $$$$$$$$    $$    $$              ●");
            Console.WriteLine("●          $$   $$          $$     $$    $$              ○");
            Console.WriteLine("○          $$   $$$$      $$       $$    $$$$$$$$$$$     ●");
            Console.WriteLine("●     $$$$$$$   $$      $$  $$     $$         $$         ○");
            Console.WriteLine("○          $$   $$     $$    $$    $$         $$         ●");
            Console.WriteLine("●          $$   $$    $$      $$   $$    $$$$$$$$$$$$    ○");
            Console.WriteLine("○                                                        ●");
            Console.WriteLine("●                                                        ○");
            Console.WriteLine("○●○●○●○●○●○●○●○●○●○●○●○●○●○●○●");
            Console.ResetColor();

            while (true) //카드를 다 쓰지 않을 동안 반복
            {
                string shape1;
                string shape2;
                string playerShape;
                int num1;
                int num2;
                int playerNum;

                int bet = 0;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("●○●○●○●○●○●○●○●○●○●○●○●○●○●○●○");
                Console.WriteLine("○                    ●                                  ●");
                Console.WriteLine("●      소지금        ○               {0}    G          ○", money);
                Console.WriteLine("○                    ●                                  ●");
                Console.WriteLine("●○●○●○●○●○●○●○●○●○●○●○●○●○●○●○");
                Console.ResetColor();

                Console.Write("\n베팅할 금액을 입력해주세요 (최소 베팅금액: 100G) : ", money);
                bet = int.Parse(Console.ReadLine());
                while (bet < 100 || bet > money)
                {
                    Console.Write("소지금 내에서 최소 100G로 베팅해주세요: ");
                    bet = int.Parse(Console.ReadLine());
                }
                money -= bet;
                //////////////베팅 완료

                if (card[turn] / 13 == 0) // 0 ~ 12은 스페이드
                {
                    shape1 = "♠";
                }
                else if (card[turn] / 13 == 1) // 13 ~ 25 클로버
                {
                    shape1 = "♣";
                }
                else if (card[turn] / 13 == 2) // 26 ~ 38 다이아
                {
                    shape1 = "◆";
                }
                else //39 ~ 51 하트
                {
                    shape1 = "♥";
                }
                num1 = card[turn] % 13 + 1;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n●○●○●○●○●○●○●○●○●○●○●○●○●○●○●○");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("     □□□□□□□□□              □□□□□□□□□");
                Console.WriteLine("     □              □              □              □");

                if (num1 <= 10 && num1 > 1)
                {
                    Console.Write("     □        {0} {1,2} □              ", shape1, num1);
                }
                else if (num1 == 1)
                {
                    Console.Write("     □         {0} A □              ", shape1);
                }
                else if (num1 == 11)
                {
                    Console.Write("     □         {0} J □              ", shape1);
                }
                else if (num1 == 12)
                {
                    Console.Write("     □         {0} Q □              ", shape1);
                }
                else
                {
                    Console.Write("     □         {0} K □              ", shape1);
                }
                /////////////////////////////////////////////////////////////두번째 딜러카드
                if (card[turn+1] / 13 == 0) // 0 ~ 12은 스페이드
                {
                    shape2 = "♠";
                }
                else if (card[turn+1] / 13 == 1) // 13 ~ 25 클로버
                {
                    shape2 = "♣";
                }
                else if (card[turn+1] / 13 == 2) // 26 ~ 38 다이아
                {
                    shape2 = "◆";
                }
                else //39 ~ 51 하트
                {
                    shape2 = "♥";
                }

                num2 = card[turn+1] % 13 + 1;
                if (num2 <= 10 && num2 > 1)
                {
                    Console.WriteLine("□        {0} {1,2} □", shape2, num2);
                }
                else if (num2 == 1)
                {
                    Console.WriteLine("□         {0} A □", shape2);
                }
                else if (num2 == 11)
                {
                    Console.WriteLine("□         {0} J □", shape2);
                }
                else if (num2 == 12)
                {
                    Console.WriteLine("□         {0} Q □", shape2);
                }
                else
                {
                    Console.WriteLine("□         {0} K □", shape2);
                }

                Console.WriteLine("     □              □              □              □");
                Console.WriteLine("     □              □              □              □");
                Console.WriteLine("     □              □              □              □");
                Console.WriteLine("     □              □              □              □");
                Console.WriteLine("     □              □              □              □");
                Console.WriteLine("     □              □              □              □");
                Console.WriteLine("     □              □              □              □");
                Console.WriteLine("     □              □              □              □");
                Console.WriteLine("     □□□□□□□□□              □□□□□□□□□");
                ////////////////////////////딜러카드 공개 끝

                if (card[turn + 2] / 13 == 0) // 0 ~ 12은 스페이드
                {
                    playerShape = "♠";
                }
                else if (card[turn + 2] / 13 == 1) // 13 ~ 25 클로버
                {
                    playerShape = "♣";
                }
                else if (card[turn + 2] / 13 == 2) // 26 ~ 38 다이아
                {
                    playerShape= "◆";
                }
                else //39 ~ 51 하트
                {
                    playerShape = "♥";
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("○●○●○●○●○●○●○●○●○●○●○●○●○●○●○●");
                Console.ResetColor();
                playerNum = card[turn + 2] % 13 + 1;
                Console.Write("\n                  당신의 카드는 ");
                if (playerNum <= 10 && playerNum > 1)
                {
                    Console.WriteLine("{0}{1} 입니다", playerShape, playerNum);
                }
                else if (playerNum == 1)
                {
                    Console.WriteLine("{0}A 입니다.", playerShape);
                }
                else if (playerNum == 11)
                {
                    Console.WriteLine("{0}J 입니다.", playerShape);
                }
                else if (playerNum == 12)
                {
                    Console.WriteLine("{0}Q 입니다.", playerShape);
                }
                else
                {
                    Console.WriteLine("{0}K 입니다. ", playerShape);
                }

                if (num1 < num2) //num2가 더 크면
                {
                    if (num1 < playerNum && playerNum < num2)
                    {
                        money += bet * 5;
                        Console.WriteLine("                      승리하셨습니다.\n당신은 베팅하신 금액의 5배를 받아 {0}G가 되었습니다.", money);
                    }
                    else
                    {
                        Console.WriteLine("                      패배하셨습니다.\n당신은 베팅하신 금액을 잃어 {0}G가 되었습니다.", money);
                    }
                }
                else //num1 >= num2
                {
                    if (num1 > playerNum && playerNum > num2)
                    {
                        money += bet * 5;
                        Console.WriteLine("                     승리하셨습니다.\n당신은 베팅하신 금액의 5배를 받아 {0}G가 되었습니다.", money);
                    }
                    else
                    {
                        Console.WriteLine("                     패배하셨습니다.\n당신은 베팅하신 금액을 잃어 {0}G가 되었습니다.", money);
                    }
                }
                Console.WriteLine("<<<<<<<<<<<<<<<<<<<<Enter를 눌러 계속하기>>>>>>>>>>>>>>>>>>>>");
                Console.ReadLine();
                turn += 3;
                Console.Clear();

                if (money < 100 || turn > 50)
                {
                    break;
                }
            }

            if (money < 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                  <당신은 파산하셨습니다>\n");
                Console.WriteLine("    /$$           /$$$$$$$$$$     $$$$$$$     /$$$$$$$$$$");
                Console.WriteLine("   / $$          / $$     /$$   /$$$   $$    / $$       /");
                Console.WriteLine("  │  $$         │  $$ ￣￣ $$  │$$$   /     │  $$ ￣￣￣    ");
                Console.WriteLine("  │  $$         │  $$      $$  │  $$$$      │  $$");
                Console.WriteLine("  │  $$         │  $$      $$   ＼   $$$$   │  $$$$$$$$$$");
                Console.WriteLine("  │  $$         │  $$      $$     ＼   $$$$ │  $$       / ");
                Console.WriteLine("  │  $$         │  $$      $$       ＼   $$ │  $$ ￣￣￣");
                Console.WriteLine("  │  $$         │  $$      $$    $   │   $$ │  $$");
                Console.WriteLine("  │  $$         │  $$      $$   /$$$ /  $$$ │  $$");
                Console.WriteLine("  │  $$$$$$$$$$ │  $$$$$$$$$$  │  $$$$$$$│  │  $$$$$$$$$$");
                Console.WriteLine("  │ /        /  │ /        /   │ /       /  │ /         /     ");
                Console.WriteLine("   ￣￣￣￣￣    ￣￣￣￣￣      ￣￣￣￣     ￣￣￣￣￣       ");
                Console.ResetColor();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("○●○●○●○●○●○●○●○●○●○●○●○●○●○●○●");
                Console.WriteLine("●                                                        ○");
                Console.WriteLine("○                        게임 종료                       ●");
                Console.WriteLine("●                                                        ○");
                Console.WriteLine("○●○●○●○●○●○●○●○●○●○●○●○●○●○●○●");
                Console.ResetColor();
                Console.WriteLine("------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("●○●○●○●○●○●○●○●○●○●○●○●○●○●○●○");
                Console.WriteLine("○              ○●○●○●                              ●");
                Console.WriteLine("●   초기 금액  ●○●○●○            5000  G           ○");
                Console.WriteLine("○              ○●○●○●                              ●");
                Console.WriteLine("●○●○●○●○●○●○●○●○●○●○●○●○●○●○●○");
                Console.WriteLine("○              ○●○●○●                              ●");
                Console.WriteLine("●   현재 금액  ●○●○●○          {0, 6}  G           ○", money);
                Console.WriteLine("○              ○●○●○●                              ●");
                Console.WriteLine("●○●○●○●○●○●○●○●○●○●○●○●○●○●○●○");
                Console.ResetColor();
                Console.WriteLine("------------------------------------------------------------");
            }
        }
    }
}
