using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230320_homeWork_textRPG
{
    enum PLAYERSKILL { BASIC = 1, FIRE = 2, WATER = 3, WIND = 4 }
    enum MONSTERSKILL { BASIC = 1, BITE = 2, SMASH = 3, ROLL = 4 };
    class Program
    {
        static void monster_turn(ref character slime, ref int monHit, ref character player)
        {
            if (slime.mp < 50 || monHit <= 6) //mp가 적거나 60%면 그냥 기본공격만
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
                    Console.WriteLine("            플레이어는 {0}만큼의 피해를 입었다\n                  방어력이 3 감소했다", slime.atk - player.def);
                    player.hp -= slime.atk - player.def;
                    player.def -= 3;
                    if (player.def < 0)
                    {
                        player.def = 0;
                    }
                    break;
                case MONSTERSKILL.BITE:
                    Console.WriteLine("          몬스터는 50MP를 사용해 깨물기 공격을 시전했다!");
                    slime.mp -= 50;
                    Console.WriteLine("             플레이어는 {0}만큼의 피해를 입었다\n                  방어력이 5 감소했다", 240 - player.def);
                    player.hp -= 240 - player.def;
                    player.def -= 5;
                    if (player.def < 0)
                    {
                        player.def = 0;
                    }
                    break;
                case MONSTERSKILL.SMASH:
                    Console.WriteLine("         몬스터는 50MP를 사용해 몸통박치기를 시전했다!");
                    slime.mp -= 50;
                    Console.WriteLine("            플레이어는 {0}만큼의 피해를 입었다\n                  방어력이 5 감소했다", 150 - player.def);
                    player.hp -= 150 - player.def;
                    player.def -= 5;
                    if (player.def < 0)
                    {
                        player.def = 0;
                    }
                    break;
                case MONSTERSKILL.ROLL:
                    Console.WriteLine("         몬스터는 50MP를 사용해 구르기 공격을 시전했다!");
                    slime.mp -= 50;
                    Console.WriteLine("           플레이어는 {0}만큼의 피해를 입었다\n                   방어력이 5 감소했다", 140 - player.def);
                    player.hp -= 140 - player.def;
                    player.def -= 5;
                    if (player.def < 0)
                    {
                        player.def = 0;
                    }
                    break;
            }
        }
        static void player_turn(ref character player, ref bool playerTurn, ref bool question, ref bool playerFIGHT, ref int hit, ref int monAvoid, ref int monIgnore, ref int perCri, ref character slime, ref int addCri)
        {
            while (playerTurn) //플레이어의 턴
            {
                if (question == false)
                {
                    if (player.hp <= 100)
                    {
                        Console.Write("        당신은 도주가 가능합니다\n          도망가시겠습니까?\nY / N  ");
                        question = true;
                        string answer = Console.ReadLine();
                        if (answer == "Y")
                        {
                            Console.WriteLine("겁에질린 당신은 꼴사납게 도망갔습니다\n");
                            playerFIGHT = false;
                            break;
                        }
                    }
                    if (player.hp <= 50 && player.hpPotion >= 1) //hp가 낮으면 포션 사용 물어봄
                    {
                        quest_hpp(ref player, ref question);
                    }

                    if (player.mp <= 50 && player.mpPotion >= 1) //mp가 낮으면 포션 사용 물어봄
                    {
                        quest_mpp(ref player, ref question);
                    }
                }

                Console.WriteLine("기본 공격: 1        FIRE: 2        WATER: 3        WIND: 4");
                Console.Write("               당신의 공격은? :      ");
                hit = int.Parse(Console.ReadLine());
                Console.WriteLine("========================================================");

                switch ((PLAYERSKILL)hit)
                {
                    case PLAYERSKILL.BASIC:
                        Console.WriteLine("                플레이어의 기본 공격!");
                        if (monAvoid <= 3)  //10%로 데미지 무효화
                        {
                            Console.WriteLine("        날렵한 몬스터가 당신의 공격을 회피했다");
                        }
                        else if (monIgnore == 1)
                        {
                            Console.WriteLine("    몬스터의 레어 버프 기본공격 무효화가 발동했다\n          당신의 공격은 데미지를 입히지 못했습니다");
                        }
                        else
                        {
                            if (perCri == 1) //크리티컬 성공
                            {
                                Console.WriteLine("                 크리티컬 성공!\n  추가 공격력으로 인해 몬스터에게 {0}의 데미지를 입혔다", addCri + player.atk);
                                slime.hp = slime.hp - (addCri + player.atk - slime.def);
                            }
                            else //크리티컬 실패시 기본공격만
                            {
                                Console.WriteLine("플레이어의 기본 공격으로 몬스터에게 {0}의 데미지를 입혔다", player.atk - slime.def);
                                slime.hp = slime.hp - player.atk + slime.def;
                            }
                        }
                        playerTurn = false;
                        question = false;
                        break;

                    case PLAYERSKILL.FIRE:
                        if (player.mp < 200)
                        {
                            Console.WriteLine("플레이어의 MP부족으로 해당 스킬을 사용할 수 없습니다");
                            continue;
                        }

                        if (monAvoid <= 3)  //10%로 데미지 무효화
                        {
                            Console.WriteLine("        날렵한 몬스터가 당신의 공격을 회피했다");
                            Console.WriteLine("       스킬의 사용으로 플레이어의 MP가 200 닳았다");
                            player.mp -= 200;
                        }
                        else if (monIgnore == 1) //10%로 데미지 무효화
                        {
                            Console.WriteLine("         몬스터의 레어 버프 기본공격 무효화가 발동했다\n     당신의 FIRE 스킬은 데미지를 입히지 못했다");
                            Console.WriteLine("       스킬의 사용으로 플레이어의 MP가 200 닳았다");
                            player.mp -= 200;
                        }
                        else
                        {
                            Console.WriteLine("플레이어의 FIRE 스킬로 몬스터에게 {0}의 데미지를 입혔다", 500 - slime.def);
                            slime.hp -= 500 - slime.def;
                            Console.WriteLine("     스킬의 사용으로 플레이어의 MP가 200 닳았다");
                            player.mp -= 200;
                        }
                        playerTurn = false;
                        question = false;
                        break;

                    case PLAYERSKILL.WATER:
                        if (player.mp < 100)
                        {
                            Console.WriteLine("    플레이어의 MP부족으로 해당 스킬을 사용할 수 없다");
                            continue;
                        }

                        if (monAvoid <= 3)  //10%로 데미지 무효화
                        {
                            Console.WriteLine("        날렵한 몬스터가 당신의 공격을 회피했다");
                            Console.WriteLine("      스킬의 사용으로 플레이어의 mp가 100 닳았다");
                            player.mp -= 100;
                        }
                        else if (monIgnore == 1) //10%로 데미지 무효화
                        {
                            Console.WriteLine("       몬스터의 레어 버프 기본공격 무효화가 발동했다\n당신의 WATER 스킬은 데미지를 입히지 못했다");
                            Console.WriteLine("      스킬의 사용으로 플레이어의 mp가 100 닳았다");
                            player.mp -= 100;
                        }
                        else
                        {
                            Console.WriteLine("    플레이어의 WATER 스킬로 몬스터에게 {0}의 데미지를 입혔다", 400 - slime.def);
                            slime.hp -= 400 - slime.def;
                            Console.WriteLine("      스킬의 사용으로 플레이어의 MP가 100 닳았다");
                            player.mp -= 100;
                        }
                        playerTurn = false;
                        question = false;
                        break;

                    case PLAYERSKILL.WIND:
                        if (player.mp < 50)
                        {
                            Console.WriteLine("    플레이어의 MP부족으로 해당 스킬을 사용할 수 없다");
                            continue;
                        }
                        if (monAvoid <= 3)  //10%로 데미지 무효화
                        {
                            Console.WriteLine("        날렵한 몬스터가 당신의 공격을 회피했다");
                            Console.WriteLine("      스킬의 사용으로 플레이어의 MP가 50 닳았다");
                            player.mp -= 50;
                        }
                        else if (monIgnore == 1) //10%로 데미지 무효화
                        {
                            Console.WriteLine("      몬스터의 레어 버프 기본공격 무효화가 발동했다\n           당신의 WATER 스킬은 데미지를 입히지 못했다");
                            Console.WriteLine("        스킬의 사용으로 플레이어의 MP가 50 닳았다");
                            player.mp -= 100;
                        }
                        else
                        {
                            Console.WriteLine("플레이어의 WIND 스킬로 몬스터에게 {0}의 데미지를 입혔다", 200 - slime.def);
                            slime.hp -= 200 - slime.def;
                            Console.WriteLine("      스킬의 사용으로 플레이어의 MP가 50 닳았다");
                            player.mp -= 50;
                        }
                        playerTurn = false;
                        question = false;
                        break;
                    default:
                        Console.WriteLine("          올바른 입력값으로 다시 입력해주세요");
                        break;
                }
            }
        }
        static void ending_run()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("========================================================");
            Console.WriteLine("                  이걸 도망가네,,,");
            Console.WriteLine("                     <도망엔딩>");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                                                        ");
            Console.WriteLine("            ■■■                                      ");
            Console.WriteLine("          ■      ■                                    ");
            Console.WriteLine("         ■        ■                                   ");
            Console.WriteLine("          ■      ■      ■■                              ");
            Console.WriteLine("            ■■■      ■    ■                            ");
            Console.WriteLine("    ■          ■   ■■        ■                            ");
            Console.WriteLine("      ■    ■■ ■■                                      ");
            Console.WriteLine("        ■■      ■                                     ");
            Console.WriteLine("                   ■                                     ");
            Console.WriteLine("                   ■                                     ");
            Console.WriteLine("                    ■            ■,,/          __       ");
            Console.WriteLine("                  ■  ■      ■■              /  ↘__         ");
            Console.WriteLine("              ■■      ■  ■           -------       )        ");
            Console.WriteLine("            ■            ■              ===========   )        ");
            Console.WriteLine("              ■                         -------     __) ");
            Console.WriteLine("                ■,,,/                          ↘__/   ");
            Console.WriteLine("                 <플레이어의 도주>  ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("========================================================");
            Console.ResetColor();
        }
        static void ending_lose()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("========================================================");
            Console.WriteLine("            몬스터를 죽이랬더니 너가 죽네,,,");
            Console.WriteLine("                     <패배엔딩>");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                                        ");
            Console.WriteLine("                             ■■■■                   ");
            Console.WriteLine("                          ■         ■■               ");
            Console.WriteLine("                        ■               ■             ");
            Console.WriteLine("                      ■■■               ■           ");
            Console.WriteLine("                  ■■      ■■            ■          ");
            Console.WriteLine("                ■               ■■         ■        ");
            Console.WriteLine("              ■                    ■                  ");
            Console.WriteLine("             ■    □■      □■     ■                ");
            Console.WriteLine("            ■     ■□      ■□      ■               ");
            Console.WriteLine("          ■                            ■              ");
            Console.WriteLine("          ■                ■           ■             ");
            Console.WriteLine("          ■          ■■■              ■            ");
            Console.WriteLine("        ■                              ■■            ");
            Console.WriteLine("          ■■                      ■■                ");
            Console.WriteLine("              ■■■■■■■■■■■                    ");
            Console.WriteLine("                  <몬스터의 조소>  ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("========================================================");
            Console.ResetColor();
        }
        static void quest_mpp(ref character player, ref bool question)
        {
            string answer;
            Console.Write("             플레이어의 마나가 낮습니다\n         현재 사용 가능한 MP 포션은 {0}개 입니다\n               포션을 마시겠습니까?\nY / N  ", player.mpPotion);
            question = true;
            answer = Console.ReadLine();
            if (answer == "Y")
            {
                player.mp += 200;
                player.mpPotion--;
                Console.WriteLine("     MP포션을 사용했습니다. 마나가 200 증가됩니다 \n            플레이어의 마나가 {0}이 되었습니다", player.mp);
                
            }
            else
            {
                Console.WriteLine("  포션을 사용하지 않았습니다. 계속해서 전투를 진행합니다");
            }
        }
        static void quest_hpp(ref character player,ref bool question)
        {
            string answer;
            Console.Write("            플레이어의 체력이 낮습니다\n      현재 사용 가능한 HP 포션은 {0}개 입니다\n                 포션을 마시겠습니까?\nY / N  ", player.hpPotion);
            question = true;
            answer = Console.ReadLine();
            if (answer == "Y")
            {
                player.hp += 200;
                player.hpPotion--;
                Console.WriteLine("              HP포션을 사용했습니다\n               체력이 200 증가됩니다\n     플레이어의 체력은 {0}이 되었습니다", player.hp);
            }
            else
            {
                Console.WriteLine("포션을 사용하지 않았습니다. 계속해서 전투를 진행합니다");
            }
        }
        static void show_stat(ref character player,ref character slime)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("========================================================");
            Console.WriteLine("||                                                    ||");
            Console.WriteLine("||    플레이어의   HP:     {0:D3}     /     500          ||", player.hp);
            Console.WriteLine("||    플레이어의   MP:     {0:D3}     /     300          ||", player.mp);
            Console.WriteLine("||    플레이어의   ATK:    {0:D3}     /     120          ||", player.atk);
            Console.WriteLine("||    플레이어의   DEF:    {0:D3}     /      30          ||", player.def);
            Console.WriteLine("||                                                    ||");
            Console.WriteLine("||      몬스터의   HP:     {0:D3}     /     800          ||", slime.hp);
            Console.WriteLine("||      몬스터의   MP:     {0:D3}     /     200          ||", slime.mp);
            Console.WriteLine("||      몬스터의   ATK:    {0:D3}     /      80          ||", slime.atk);
            Console.WriteLine("||      몬스터의   DEF:    {0:D3}     /      60          ||", slime.def);
            Console.WriteLine("||                                                    ||");
            Console.WriteLine("========================================================");
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("|  Inventory      |");
            Console.WriteLine("|  HP 포션: {0}개   |", player.hpPotion);
            Console.WriteLine("|  MP 포션: {0}개   |", player.mpPotion);
            Console.WriteLine("-------------------");
            Console.ResetColor();
            Console.WriteLine();
        }
        public struct character
        {
            public int hp;
            public int mp;
            public int atk;
            public int def;
            public int money;
            public int hpPotion;
            public int mpPotion;
        }
        static void Main(string[] args)
        {
            Console.SetWindowSize(60, 40);
            character player = new character();
            player.hp = 500;
            player.mp = 300;
            player.atk = 120;
            player.def = 30;
            player.money = 300;
            player.hpPotion = 2;
            player.mpPotion = 2;

            bool oneMore = true;
            while (oneMore) //onemore이 false일 동안 반복
            {
                character slime = new character();
                slime.hp = 600;
                slime.mp = 200;
                slime.atk = 80;
                slime.def = 60;
                slime.money = 150;
                bool playerTurn = true;

                int hit = 0; //플레이어의 공격 수단 판별
                bool playerFIGHT = true; //false일 시 도주로 판별
                Random random = new Random();

                Console.WriteLine("               야생의 몬스터가 나타났다!\n                       전투 시작");

                while (player.hp > 0 && slime.hp > 0 && playerFIGHT) //둘 중 한명이라도 hp가 0보다 작으면 끝, fight가 false면 끝 (도망)
                {
                    show_stat(ref player,ref slime);
                    bool question = false;
                    int monAvoid = random.Next(1, 11); //30%로 몬스터 회피;
                    int monIgnore = random.Next(1, 11);
                    int perCri = random.Next(1, 11); //크리티컬 확률: 10%
                    int addCri = random.Next(1, 1000); //크리티컬로 추가될 양은 1~999사이 랜덤

                    player_turn(ref player, ref playerTurn, ref question, ref playerFIGHT, ref hit, ref monAvoid, ref monIgnore, ref perCri, ref slime, ref addCri);

                    if (slime.hp < 0 || playerFIGHT == false)
                    {
                        break;
                    }

                    Console.WriteLine("========================================================");

                    //몬스터 턴
                    int monHit = random.Next(1, 11); //60%로 기본공격, 20%로 BITE, 10% SMASH, 10% ROLL 

                    monster_turn(ref slime, ref monHit, ref player);
                    Console.WriteLine("========================================================");
                    Console.WriteLine("             <<<Enter를 눌러 페이지 넘기기>>>");
                    Console.ReadLine();
                    Console.Clear();
                    playerTurn = true;
                }

                /////////////////////슬라임이나 플레이어가 사망해 한 판 끝
                Console.Clear();

                if (slime.hp < 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("==========================================================");
                    player.money += slime.money;
                    Console.WriteLine("                       승리하셨습니다\n            몬스터가 지니던 돈 {0}G를 얻었습니다\n                당신의 소지금은 {1}G 입니다.\n                       경축경축", slime.money, player.money);

                    Console.WriteLine("      $$            $$     $$$$$$$     $$$     $$$");
                    Console.WriteLine("      $$            $$       $$$       $$$$    $$$");
                    Console.WriteLine("      $$     $$     $$       $$$       $$$$$   $$$");
                    Console.WriteLine("       $$    $$    $$        $$$       $$$ $$  $$$");
                    Console.WriteLine("        $$  $$$$  $$         $$$       $$$  $$ $$$");
                    Console.WriteLine("         $$$$  $$$$          $$$       $$$   $$$$$");
                    Console.WriteLine("          $$    $$         $$$$$$$     $$$    $$$$");
                    Console.WriteLine("                         <승리엔딩>");
                    Console.WriteLine("==========================================================");
                    Console.ResetColor();
                    Console.Write("전투를 더 하시겠습니까? (Y / N): ");
                    char answer = char.Parse(Console.ReadLine());
                    if (answer == 'N')
                    {
                        oneMore = false;
                    }
                    else if (answer == 'Y')
                    {
                        oneMore = true;
                        Console.Clear();
                    }
                }
                else if (player.hp < 0)
                {
                    ending_lose();
                    oneMore = false;
                }
                else if (playerFIGHT == false)
                {
                    ending_run();
                    oneMore = false;
                }
            }
        }
    }
}
