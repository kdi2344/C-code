using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230316_homeWork_game
{
    enum PLAYERSKILL { BASIC = 1, FIRE = 2, WATER = 3, WIND = 4 }
    enum MONSTERSKILL { BASIC = 1, BITE = 2, SMASH = 3, ROLL = 4 };
    class Program
    {
        static void Main(string[] args)
        {
            int playerHP = 500;
            int playerMP = 300;
            int playerATK = 120;
            int playerDEF = 30;
            int playerMoney = 300;
            int perCri;
            int addCri;

            int hpPotion = 2;
            int mpPotion = 2;

            bool playerTurn = true;

            int monHP = 800;
            int monMP = 200;
            int monATK = 80;
            int monDEF = 60;
            int money = 150;

            int hit = 0;
            bool playerFIGHT = true;
            Random random = new Random();
            Console.WriteLine("               야생의 몬스터가 나타났다!\n                       전투 시작");

            while (playerHP > 0 && monHP > 0 && playerFIGHT) //둘중 한명이라도 hp가 0보다 작으면 끝, fight가 false면 끝 (도망)
            {

                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("========================================================");
                Console.WriteLine("||                                                    ||");
                Console.WriteLine("||    플레이어의   HP:     {0:D3}     /     500          ||", playerHP);
                Console.WriteLine("||    플레이어의   MP:     {0:D3}     /     300          ||", playerMP);
                Console.WriteLine("||    플레이어의   ATK:    {0:D3}     /     120          ||", playerATK);
                Console.WriteLine("||    플레이어의   DEF:    {0:D3}     /      30          ||", playerDEF);
                Console.WriteLine("||                                                    ||");
                Console.WriteLine("||      몬스터의   HP:     {0:D3}     /     800          ||", monHP);
                Console.WriteLine("||      몬스터의   MP:     {0:D3}     /     200          ||", monMP);
                Console.WriteLine("||      몬스터의   ATK:    {0:D3}     /      80          ||", monATK);
                Console.WriteLine("||      몬스터의   DEF:    {0:D3}     /      60          ||", monDEF); 
                Console.WriteLine("||                                                    ||");
                Console.WriteLine("========================================================");
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("|  Inventory      |");
                Console.WriteLine("|  HP 포션: {0}개   |", hpPotion);
                Console.WriteLine("|  MP 포션: {0}개   |", mpPotion);
                Console.WriteLine("-------------------");
                Console.ResetColor();
                Console.WriteLine();

                while (playerTurn) //플레이어의 턴
                {
                    if (playerHP <= 100)
                    {
                        Console.Write("        당신은 도주가 가능합니다.\n          도망가시겠습니까?\nY / N  ");
                        string answer = Console.ReadLine();
                        if (answer == "Y")
                        {
                            Console.WriteLine("겁에질린 당신은 꼴사납게 도망갔습니다.\n");
                            playerFIGHT = false;
                            break;
                        }
                    }
                    if (playerHP <= 50 && hpPotion >= 1)
                    {
                        string answer;
                        Console.Write("            플레이어의 체력이 낮습니다.\n      현재 사용 가능한 HP 포션은 {0}개 입니다.\n                 포션을 마시겠습니까?\nY / N  ", hpPotion);
                        answer = Console.ReadLine();
                        if (answer == "Y")
                        {
                            playerHP += 200;
                            hpPotion--;
                            Console.WriteLine("              HP포션을 사용했습니다.\n               체력이 200 증가됩니다.\n     플레이어의 체력은 {0}이 되었습니다.", playerHP);
                        }
                        else
                        {
                            Console.WriteLine("포션을 사용하지 않았습니다. 계속해서 전투를 진행합니다.");
                        }
                    }

                    if (playerMP <= 50 && mpPotion >= 1)
                    {
                        string answer;
                        Console.Write("             플레이어의 마나가 낮습니다.\n         현재 사용 가능한 MP 포션은 {0}개 입니다.\n               포션을 마시겠습니까?\nY / N  ", mpPotion);
                        answer = Console.ReadLine();
                        if (answer == "Y")
                        {
                            playerMP += 200;
                            mpPotion--;
                            Console.WriteLine("     MP포션을 사용했습니다. 마나가 200 증가됩니다. \n            플레이어의 마나가 {0}이 되었습니다.", playerMP);
                        }
                        else
                        {
                            Console.WriteLine("  포션을 사용하지 않았습니다. 계속해서 전투를 진행합니다.");
                        }
                    }

                    Console.WriteLine("기본 공격: 1        FIRE: 2        WATER: 3        WIND: 4");
                    hit = int.Parse(Console.ReadLine());

                    int monAvoid = random.Next(1, 11); //30%로 몬스터 회피;
                    int monIgnore = random.Next(1, 11);
                    switch ((PLAYERSKILL)hit)
                    {
                        case PLAYERSKILL.BASIC: 
                            Console.WriteLine("                플레이어의 기본 공격!");
                            perCri = random.Next(1, 11); //크리티컬 확률: 10%
                            if (monAvoid <= 3)  //10%로 데미지 무효화
                            {
                                Console.WriteLine("        날렵한 몬스터가 당신의 공격을 회피했다.");
                            }
                            else if (monIgnore == 1)
                            {
                                Console.WriteLine("    몬스터의 레어 버프 기본공격 무효화가 발동했다.\n          당신의 공격은 데미지를 입히지 못했습니다.");
                            }
                            else
                            {
                                if (perCri == 1) //크리티컬 성공
                                {
                                    addCri = random.Next(1, 1000); //크리티컬로 추가될 양은 1~999사이 랜덤
                                    Console.WriteLine("                 크리티컬 성공!\n  추가 공격력으로 인해 몬스터에게 {0}의 데미지를 입혔다.", addCri + playerATK);
                                    monHP = monHP - (addCri + playerATK - monDEF);
                                }
                                else //크리티컬 실패시 기본공격만
                                {
                                    Console.WriteLine("플레이어의 기본 공격으로 몬스터에게 {0}의 데미지를 입혔다.", playerATK - monDEF);
                                    monHP = monHP - playerATK + monDEF;
                                }
                            }
                            playerTurn = false;
                            break;

                        case PLAYERSKILL.FIRE:
                            if (playerMP < 200)
                            {
                                Console.WriteLine("플레이어의 MP부족으로 해당 스킬을 사용할 수 없습니다.");
                                continue;
                            }

                            if (monAvoid <= 3)  //10%로 데미지 무효화
                            {
                                Console.WriteLine("        날렵한 몬스터가 당신의 공격을 회피했다.");
                                Console.WriteLine("       스킬의 사용으로 플레이어의 MP가 200 닳았다.");
                                playerMP -= 200;
                            }
                            else if (monIgnore == 1) //10%로 데미지 무효화
                            {
                                Console.WriteLine("         몬스터의 레어 버프 기본공격 무효화가 발동했다.\n     당신의 FIRE 스킬은 데미지를 입히지 못했다.");
                                Console.WriteLine("       스킬의 사용으로 플레이어의 MP가 200 닳았다.");
                                playerMP -= 200;
                            }
                            else
                            {
                                Console.WriteLine("플레이어의 FIRE 스킬로 몬스터에게 {0}의 데미지를 입혔다.", 500 - monDEF);
                                monHP -= 500 - monDEF;
                                Console.WriteLine("     스킬의 사용으로 플레이어의 MP가 200 닳았다.");
                                playerMP -= 200;
                            }
                            playerTurn = false;
                            break;

                        case PLAYERSKILL.WATER:
                            if (playerMP < 100)
                            {
                                Console.WriteLine("    플레이어의 MP부족으로 해당 스킬을 사용할 수 없다.");
                                continue;
                            }

                            if (monAvoid <= 3)  //10%로 데미지 무효화
                            {
                                Console.WriteLine("        날렵한 몬스터가 당신의 공격을 회피했다.");
                                Console.WriteLine("      스킬의 사용으로 플레이어의 mp가 100 닳았다.");
                                playerMP -= 100;
                            }
                            else if (monIgnore == 1) //10%로 데미지 무효화
                            {
                                Console.WriteLine("       몬스터의 레어 버프 기본공격 무효화가 발동했다.\n당신의 WATER 스킬은 데미지를 입히지 못했다.");
                                Console.WriteLine("      스킬의 사용으로 플레이어의 mp가 100 닳았다.");
                                playerMP -= 100;
                            }
                            else
                            {
                                Console.WriteLine("    플레이어의 WATER 스킬로 몬스터에게 {0}의 데미지를 입혔다.", 400 - monDEF);
                                monHP -= 400 - monDEF;
                                Console.WriteLine("      스킬의 사용으로 플레이어의 MP가 100 닳았다.");
                                playerMP -= 100;
                            }
                            playerTurn = false;
                            break;

                        case PLAYERSKILL.WIND:
                            if (playerMP < 50)
                            {
                                Console.WriteLine("    플레이어의 MP부족으로 해당 스킬을 사용할 수 없다.");
                                continue;
                            }
                            if (monAvoid <= 3)  //10%로 데미지 무효화
                            {
                                Console.WriteLine("        날렵한 몬스터가 당신의 공격을 회피했다.");
                                Console.WriteLine("      스킬의 사용으로 플레이어의 MP가 50 닳았다.");
                                playerMP -= 50;
                            }
                            else if (monIgnore == 1) //10%로 데미지 무효화
                            {
                                Console.WriteLine("      몬스터의 레어 버프 기본공격 무효화가 발동했다.\n           당신의 WATER 스킬은 데미지를 입히지 못했다.");
                                Console.WriteLine("        스킬의 사용으로 플레이어의 MP가 50 닳았다.");
                                playerMP -= 100;
                            }
                            else
                            {
                                Console.WriteLine("플레이어의 WIND 스킬로 몬스터에게 {0}의 데미지를 입혔다.", 200 - monDEF);
                                monHP -= 200 - monDEF;
                                Console.WriteLine("      스킬의 사용으로 플레이어의 MP가 50 닳았다.");
                                playerMP -= 50;
                            }
                            playerTurn = false;
                            break;
                        default:
                            Console.WriteLine("          올바른 입력값으로 다시 입력해주세요.");
                            break;
                    }
                }
                if (monHP < 0)
                {
                    break;
                }
                if (playerFIGHT == false)
                {
                    break;
                }
                Console.WriteLine("========================================================");

                //몬스터 턴
                int monHit = random.Next(1, 11); //60%로 기본공격, 20%로 BITE, 10% SMASH, 10% ROLL 
                if (monMP < 50 || monHit <= 6) //mp가 적거나 60%면 그냥 기본공격만
                {
                    monHit = 1;
                }
                else if (monHit <= 8)
                {
                    monHit = 2;
                }
                else if (monHit == 9)
                {
                    monHit = 3;
                }
                else if (monHit == 10)
                {
                    monHit = 4;
                }
                switch ((MONSTERSKILL)monHit)
                {
                    case MONSTERSKILL.BASIC:
                        Console.WriteLine("                   몬스터의 기본 공격!");
                        Console.WriteLine("            플레이어는 {0}만큼의 피해를 입었다.\n                  방어력이 5 감소했다.", monATK - playerDEF);
                        playerHP -= monATK - playerDEF;
                        playerDEF -= 5;
                        if (playerDEF < 0)
                        {
                            playerDEF = 0;
                        }
                        break;
                    case MONSTERSKILL.BITE:
                        Console.WriteLine("          몬스터는 50MP를 사용해 깨물기 공격을 시전했다!");
                        monMP -= 50;
                        Console.WriteLine("             플레이어는 {0}만큼의 피해를 입었다.\n                  방어력이 10 감소했다.", 240 - playerDEF);
                        playerHP -= 240 - playerDEF;
                        playerDEF -= 10;
                        if (playerDEF < 0)
                        {
                            playerDEF = 0;
                        }
                        break;
                    case MONSTERSKILL.SMASH:
                        Console.WriteLine("         몬스터는 50MP를 사용해 몸통박치기를 시전했다!");
                        monMP -= 50;
                        Console.WriteLine("            플레이어는 {0}만큼의 피해를 입었다.\n                  방어력이 10 감소했다.", 150 - playerDEF);
                        playerHP -= 150 - playerDEF;
                        playerDEF -= 10;
                        if (playerDEF < 0)
                        {
                            playerDEF = 0;
                        }
                        break;
                    case MONSTERSKILL.ROLL:
                        Console.WriteLine("         몬스터는 50MP를 사용해 구르기 공격을 시전했다!");
                        monMP -= 50;
                        Console.WriteLine("           플레이어는 {0}만큼의 피해를 입었다.\n                   방어력이 10 감소했다.", 140 - playerDEF);
                        playerHP -= 140 - playerDEF;
                        playerDEF -= 10;
                        if (playerDEF < 0)
                        {
                            playerDEF = 0;
                        }
                        break;
                }

                Console.WriteLine("             <<<Enter를 눌러 페이지 넘기기>>>");
                Console.ReadLine();
                Console.Clear();
                playerTurn = true;
            }
            Console.Clear();

            if (monHP < 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("========================================================");
                playerMoney += money;
                Console.WriteLine("                     승리하셨습니다.\n          몬스터가 지니던 돈 {0}G를 얻었습니다.\n              당신의 소지금은 {1}G 입니다.\n                       경축경축", money, playerMoney);
                Console.WriteLine("                      <승리엔딩>");
                Console.WriteLine("========================================================");
                Console.ResetColor();
            }
            else if (playerHP < 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("========================================================");
                Console.WriteLine("            몬스터를 죽이랬더니 너가 죽네,,,");
                Console.WriteLine("                     <패배엔딩>");
                Console.WriteLine("========================================================");
                Console.ResetColor();
            }
            else if (playerFIGHT == false)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("========================================================");
                Console.WriteLine("                  이걸 도망가네,,,");  
                Console.WriteLine("                     <도망엔딩>");
                Console.WriteLine("========================================================");
                Console.ResetColor();
            }
        }
    }
}
