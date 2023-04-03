using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230324_homeWork_inventory
{
    class Program
    {
        static void show_hand(List<string> hand)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\n|당신이 장착한 아이템: ");
            Console.WriteLine("{0}|", hand[0]);
            Console.ResetColor();
        }
        static void Off_item(List<string> inv, List<string> hand)
        {
            if (hand.Count > 0) //장착한 아이템이 있다면 해제가능
            {
                string item = hand[0];
                inv.Add(item);
                hand.RemoveAt(0);
                Console.Write("{0}을/를 해제했습니다. 아이템을 버리시겠습니까? Y / N: ", item);
                string result = Console.ReadLine();
                if (result == "Y")
                {
                    Console.WriteLine("불쌍한 {0}은/는 바닥에 버려졌습니다.", item);
                    inv.Remove(item);
                }
                else if (result == "N") 
                {
                    Console.WriteLine("{0}을/를 다시 인벤토리에 넣었습니다.", item);
                }
                else
                {
                    Console.WriteLine("잘못된 값을 입력하여 아이템을 버리지 않았습니다.");
                }
            }
            else //장착한 아이템이 없다면 해제 불가능
            {
                Console.WriteLine("해제할 아이템이 없습니다.");
            }
        }
        static void On_item(List<string> inv, List<string> hand)
        {
            if (hand.Count > 0) //이미 장착한 아이템이 있다면
            {
                Console.Write("장착할 아이템의 명칭을 입력해주세요\n 아이템: ");
                string item = Console.ReadLine();
                bool exist = false;
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i] == item)
                    {
                        exist = true;
                    }
                }
                if (exist) //아이템이 인벤토리에 존재한다면
                {
                    string hand_item = hand[0];
                    hand.RemoveAt(0);
                    hand.Add(item);
                    inv.Add(hand_item);
                }
                else
                {
                    Console.Write("해당 아이템은 존재하지 않습니다.");
                }
            }
            else //현재 내가 장착한 아이템이 없다면
            {
                Console.Write("장착할 아이템의 명칭을 입력해주세요\n 아이템: ");
                string item = Console.ReadLine();
                bool exist = false;
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i] == item)
                    {
                        exist = true;
                    }
                }
                if (exist) //아이템이 인벤토리에 존재한다면
                {
                    hand.Add(item);
                    inv.Remove(item);
                }
                else
                {
                    Console.Write("해당 아이템은 존재하지 않습니다.");
                }
            }
        }
        static void Delete_item(List<string> inv)
        {
            Console.Write("삭제하실 아이템의 명칭을 적어주세요\n 아이템: ");
            string item = Console.ReadLine();
            bool exist = false;
            for (int i = 0; i < inv.Count; i++)
            {
                if (inv[i] == item)
                {
                    exist = true;
                }
            }
            if (exist)
            {
                inv.Remove(item);
            }
            else
            {
                Console.WriteLine("해당 아이템은 존재하지 않습니다.");
            }
        }
        static void Create_item(List<string> inv)
        {
            Console.Write("생성하실 아이템의 명칭을 적어주세요\n 아이템: ");
            string item = Console.ReadLine();
            inv.Add(item);
        }
        static void show_inventory(List<string> inv)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("인벤토리");
            Console.Write("||  ");
            for (int i = 0; i < inv.Count; i++)
            {
                Console.Write("<{0}>  ", inv[i]);
            }
            Console.WriteLine("||\n");
            Console.ResetColor();
        }
        static int Action(List<string> inv)
        {
            int input;
            Console.WriteLine("┌────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│ 1. 아이템 생성  2. 아이템 삭제  3. 아이템 착용  4. 아이템 해제 │");
            Console.WriteLine("└────────────────────────────────────────────────────────────────┘");
            if (inv.Count < 1)
            {
                Console.WriteLine("인벤토리에 아이템이 없습니다.");
                Console.WriteLine("자동으로 아이템 생성을 선택합니다.");
                input = 1;
                return input;
            }
            else
            {
                show_inventory(inv);
                Console.WriteLine("어떤 행동을 하시겠습니까? ");
                input = int.Parse(Console.ReadLine());
                if (input >= 1 && input <= 4)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("해당하지 않는 값의 입력으로 아이템을 생성을 선택합니다.");
                    input = 1;
                    return input;
                }
            }
        }
        static void Main(string[] args)
        {
            List<string> inv = new List<string>();
            List<string> hand = new List<string>();
            //행동창 출력
            while (true)
            {
                try
                {
                    if (hand.Count > 0)
                    {
                        show_hand(hand);
                        //장착한 아이템 출력
                    }
                    int choose = Action(inv);
                    if (choose == 1)
                    {
                        Create_item(inv);
                        //아이템 생성
                    }
                    else if (choose == 2)
                    {
                        Delete_item(inv);
                        //아이템 삭제
                    }
                    else if (choose == 3)
                    {
                        On_item(inv, hand);
                        //아이템 착용
                    }
                    else
                    {
                        Off_item(inv, hand);
                        //아이템 해제
                    }
                    Console.WriteLine("Press Enter>>");
                    Console.ReadLine();
                    Console.Clear();
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
