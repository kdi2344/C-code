using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace _20230323_homeWork_poker
{
    public struct card
    {
        public char symbol;
        public int number;
    }
    class gamer
    {
        public card[] own = new card[7];
        public string Name;
        public int money = 100000;
    }
    class Player : gamer
    {
        public Player(string name)
        {
            Name = name;
        }
    }
    class Computer : gamer
    {
        public Computer()
        {
            Name = "컴퓨터";
        }
    }
    class Program
    {
        static void order(ref Computer you) //내림차순 정렬
        {
            for (int i = 0; i < you.own.Length - 1; i++)
            {
                for (int j = i + 1; j < you.own.Length; j++)
                {
                    if (you.own[i].number < you.own[j].number)
                    {
                        int temp = you.own[i].number;
                        char tem = you.own[i].symbol;
                        you.own[i].number = you.own[j].number;
                        you.own[i].symbol = you.own[j].symbol;
                        you.own[j].number = temp;
                        you.own[j].symbol = tem;
                    }
                }
            }
        }
        static void order(ref Player you) //내림차순 정렬
        {
            for (int i = 0; i < you.own.Length - 1; i++)
            {
                for (int j = i + 1; j < you.own.Length; j++)
                {
                    if (you.own[i].number < you.own[j].number)
                    {
                        int temp = you.own[i].number;
                        char tem = you.own[i].symbol;
                        you.own[i].number = you.own[j].number;
                        you.own[i].symbol = you.own[j].symbol;
                        you.own[j].number = temp;
                        you.own[j].symbol = tem;
                    }
                }
            }
        }
        static float check(gamer you, ref card[] result)
        {
            //같은 무늬 K Q J 10 A

            int spade = 0, dia = 0, heart = 0, clov = 0;
            for (int i = 0; i < 7; i++)
            {
                if (you.own[i].symbol == '♠')
                {
                    spade++;
                }
                else if (you.own[i].symbol == '◆')
                {
                    dia++;
                }
                else if (you.own[i].symbol == '♥')
                {
                    heart++;
                }
                else
                {
                    clov++;
                }
            }
            if (spade >= 5)
            {
                int j = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].symbol == '♠')
                    {
                        if (you.own[i].number == 13 || you.own[i].number == 12 || you.own[i].number == 11 || you.own[i].number == 10 || you.own[i].number == 1)
                        {
                            result[j].number = you.own[i].number;
                            result[j].symbol = you.own[i].symbol;
                            j++;
                        }
                    }
                }
            }
            else if (dia >= 5)
            {
                int j = 0;
                for (int i = 0; i < you.own.Length; i++)
                {
                    if (you.own[i].symbol == '◆')
                    {
                        if (you.own[i].number == 13 || you.own[i].number == 12 || you.own[i].number == 11 || you.own[i].number == 10 || you.own[i].number == 1)
                        {
                            result[j].number = you.own[i].number;
                            result[j].symbol = you.own[i].symbol;
                            j++;
                        }
                    }
                }
            }
            else if (heart >= 5)
            {
                int j = 0;
                for (int i = 0; i < you.own.Length; i++)
                {
                    if (you.own[i].symbol == '♥')
                    {
                        if (you.own[i].number == 13 || you.own[i].number == 12 || you.own[i].number == 11 || you.own[i].number == 10 || you.own[i].number == 1)
                        {
                            result[j].number = you.own[i].number;
                            result[j].symbol = you.own[i].symbol;
                            j++;
                        }
                    }
                }
            }
            else if (clov >= 5)
            {
                int j = 0;
                for (int i = 0; i < you.own.Length; i++)
                {
                    if (you.own[i].symbol == '♣')
                    {
                        if (you.own[i].number == 13 || you.own[i].number == 12 || you.own[i].number == 11 || you.own[i].number == 10 || you.own[i].number == 1)
                        {
                            result[j].number = you.own[i].number;
                            result[j].symbol = you.own[i].symbol;
                            j++;
                        }
                    }
                }
            }
            bool fir = false, sec = false, thi = false, fou = false, fif = false;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i].number == 13)
                {
                    fir = true;
                }
                if (result[i].number == 12)
                {
                    sec = true;
                }
                if (result[i].number == 11)
                {
                    thi = true;
                }
                if (result[i].number == 10)
                {
                    fou = true;
                }
                if (result[i].number == 1)
                {
                    fif = true;
                }
            }

            if (fir && sec && thi && fou && fif)
            {
                Console.WriteLine("{0}의 최종 카드는 로얄스트레이트 플러쉬입니다.", you.Name);
                if (result[0].symbol == '♠')
                {
                    return 1.0f;
                }
                else if (result[0].symbol == '◆')
                {
                    return 1.25f;
                }
                else if (result[0].symbol == '♥')
                {
                    return 1.5f;
                }
                else
                {
                    return 1.75f;
                }
            }
            ///////////////////로얄스트레이트 플러쉬

            //같은 무늬 5 4 3 2 A
            fir = false;
            sec = false;
            thi = false;
            fou = false;
            fif = false;
            if (spade >= 5)
            {
                int j = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].symbol == '♠')
                    {
                        if (you.own[i].number == 5 || you.own[i].number == 4 || you.own[i].number == 3 || you.own[i].number == 2 || you.own[i].number == 1)
                        {
                            result[j].number = you.own[i].number;
                            result[j].symbol = you.own[i].symbol;
                            j++;
                        }
                    }
                }
            }
            else if (dia >= 5)
            {
                int j = 0;
                for (int i = 0; i < you.own.Length; i++)
                {
                    if (you.own[i].symbol == '◆')
                    {
                        if (you.own[i].number == 5 || you.own[i].number == 4 || you.own[i].number == 3 || you.own[i].number == 2 || you.own[i].number == 1)
                        {
                            result[j].number = you.own[i].number;
                            result[j].symbol = you.own[i].symbol;
                            j++;
                        }
                    }
                }
            }
            else if (heart >= 5)
            {
                int j = 0;
                for (int i = 0; i < you.own.Length; i++)
                {
                    if (you.own[i].symbol == '♥')
                    {
                        if (you.own[i].number == 5 || you.own[i].number == 4 || you.own[i].number == 3 || you.own[i].number == 2 || you.own[i].number == 1)
                        {
                            result[j].number = you.own[i].number;
                            result[j].symbol = you.own[i].symbol;
                            j++;
                        }
                    }
                }
            }
            else if (clov >= 5)
            {
                int j = 0;
                for (int i = 0; i < you.own.Length; i++)
                {
                    if (you.own[i].symbol == '♣')
                    {
                        if (you.own[i].number == 5 || you.own[i].number == 4 || you.own[i].number == 3 || you.own[i].number == 2 || you.own[i].number == 1)
                        {
                            result[j].number = you.own[i].number;
                            result[j].symbol = you.own[i].symbol;
                            j++;
                        }
                    }
                }
            }
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i].number == 5)
                {
                    fir = true;
                }
                if (result[i].number == 4)
                {
                    sec = true;
                }
                if (result[i].number == 3)
                {
                    thi = true;
                }
                if (result[i].number == 2)
                {
                    fou = true;
                }
                if (result[i].number == 1)
                {
                    fif = true;
                }
            }

            if (fir && sec && thi && fou && fif)
            {
                Console.WriteLine("{0}의 최종 카드는 백스트레이트 플러쉬입니다.", you.Name);
                if (result[0].symbol == '♠')
                {
                    return 2.0f;
                }
                else if (result[0].symbol == '◆')
                {
                    return 2.25f;
                }
                else if (result[0].symbol == '♥')
                {
                    return 2.5f;
                }
                else
                {
                    return 2.75f;
                }
            }
            /////////////백 스트레이트 플러쉬

            ////같은 무늬 연속 숫자 5개
            fir = false;
            sec = false;
            thi = false;
            fou = false;
            fif = false;
            for (int i = 0; i < 5; i++)
            {
                result[i].number = -1;
                result[i].symbol = ' ';
            } //result 초기화
            if (spade >= 5)
            {
                int j = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].symbol == '♠')
                    { //같은 무늬 다 넣기
                        result[j].number = you.own[i].number;
                        result[j].symbol = you.own[i].symbol;
                        j++;
                    }
                }
            }
            else if (dia >= 5)
            {
                int j = 0;
                for (int i = 0; i < you.own.Length; i++)
                {
                    if (you.own[i].symbol == '◆')
                    {
                        result[j].number = you.own[i].number;
                        result[j].symbol = you.own[i].symbol;
                        j++;
                    }
                }
            }
            else if (heart >= 5)
            {
                int j = 0;
                for (int i = 0; i < you.own.Length; i++)
                {
                    if (you.own[i].symbol == '♥')
                    {
                        result[j].number = you.own[i].number;
                        result[j].symbol = you.own[i].symbol;
                        j++;
                    }
                }
            }
            else if (clov >= 5)
            {
                int j = 0;
                for (int i = 0; i < you.own.Length; i++)
                {
                    if (you.own[i].symbol == '♣')
                    {
                        result[j].number = you.own[i].number;
                        result[j].symbol = you.own[i].symbol;
                        j++;
                    }
                }
            }
            int count = 0;
            for (int i = 1; i < result.Length; i++)
            {
                if (result[i].number - 1 == result[i - 1].number)
                {
                    count++;
                }
            }
            if (count >= 4)
            {
                Console.WriteLine("{0}의 최종 카드는 스트레이트 플러쉬입니다.", you.Name);
                if (result[0].symbol == '♠')
                {
                    return 3.0f;
                }
                else if (result[0].symbol == '◆')
                {
                    return 3.25f;
                }
                else if (result[0].symbol == '♥')
                {
                    return 3.5f;
                }
                else
                {
                    return 3.75f;
                }
            }
            ////////////////스트레이트 플러쉬 (스티플)

            //무늬 무관 같은 숫자 4개
            int[] same = new int[13] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; //각각의 숫자 개수 세는 배열
            for (int i = 0; i < 5; i++) //result값 초기화
            {
                result[i].number = -1;
                result[i].symbol = ' ';
            }
            for (int i = 0; i < you.own.Length; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    if (j + 1 == you.own[i].number)
                    {
                        same[j]++;
                    }
                }
            }
            for (int i = 0; i < same.Length; i++)
            {
                int x = 0;
                if (same[i] >= 4)
                {
                    Console.WriteLine("{0}의 최종 카드는 포커입니다.", you.Name);
                    for (int j = 0; j < 7; j++)
                    {
                        if (you.own[j].number == i + 1)
                        {
                            result[x].symbol = you.own[j].symbol;
                            result[x].number = i + 1;
                            x++;
                        }
                    }
                }
            }
            if (result[0].number == 1)
            {
                return 4.0f;
            }
            else if (result[0].number == 13)
            {
                return 4.1f;
            }
            else if (result[0].number == 12)
            {
                return 4.2f;
            }
            else if (result[0].number == 11)
            {
                return 4.3f;
            }
            else if (result[0].number == 10)
            {
                return 4.4f;
            }
            else if (result[0].number == 9)
            {
                return 4.5f;
            }
            else if (result[0].number == 8)
            {
                return 4.6f;
            }
            else if (result[0].number == 7)
            {
                return 4.7f;
            }
            else if (result[0].number == 6)
            {
                return 4.8f;
            }
            else if (result[0].number == 5)
            {
                return 4.9f;
            }
            else if (result[0].number == 4)
            {
                return 4.92f;
            }
            else if (result[0].number == 3)
            {
                return 4.94f;
            }
            else if (result[0].number == 2)
            {
                return 4.96f;
            }
            /////////////포커

            /////////////다른 무늬 같은 숫자 3개, 2개
            for (int i = 0; i < 5; i++) //result값 초기화
            {
                result[i].number = -1;
                result[i].symbol = ' ';
            }
            fir = false;
            sec = false;
            int first = 0, second = 0;
            for (int i = 0; i < same.Length; i++)
            {
                if (same[i] >= 3)
                {
                    fir = true;
                    first = i + 1;
                }
                else if (same[i] >= 2)
                {
                    sec = true;
                    second = i + 1;
                }
            }
            if (fir && sec && (first != second))
            {
                Console.WriteLine("{0}의 최종 카드는 풀하우스입니다.", you.Name);
                int x = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].number == first)
                    {
                        result[x].number = you.own[i].number;
                        result[x].symbol = you.own[i].symbol;
                        x++;
                    }
                }
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].number == second)
                    {
                        result[x].number = second;
                        result[x].symbol = you.own[i].symbol;
                        x++;
                    }
                }
            }

            if (result[0].number == 1)
            {
                return 5.0f;
            }
            else if (result[0].number == 13)
            {
                return 5.1f;
            }
            else if (result[0].number == 12)
            {
                return 5.2f;
            }
            else if (result[0].number == 11)
            {
                return 5.3f;
            }
            else if (result[0].number == 10)
            {
                return 5.4f;
            }
            else if (result[0].number == 9)
            {
                return 5.5f;
            }
            else if (result[0].number == 8)
            {
                return 5.6f;
            }
            else if (result[0].number == 7)
            {
                return 5.7f;
            }
            else if (result[0].number == 6)
            {
                return 5.8f;
            }
            else if (result[0].number == 5)
            {
                return 5.9f;
            }
            else if (result[0].number == 4)
            {
                return 5.92f;
            }
            else if (result[0].number == 3)
            {
                return 5.94f;
            }
            else if (result[0].number == 2)
            {
                return 5.96f;
            }
            ////////////////////////////풀하우스

            /////////////같은무늬 카드 5개
            for (int i = 0; i < 5; i++) //result값 초기화
            {
                result[i].number = -1;
                result[i].symbol = ' ';
            }
            if (spade >= 5)
            {
                int x = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].symbol == '♠')
                    {
                        result[x].symbol = you.own[i].symbol;
                        result[x].number = you.own[i].number;
                        x++;
                    }
                }
                Console.WriteLine("{0}의 최종 카드는 플러쉬입니다.", you.Name);
                return 6f;
            }
            else if (dia >= 5)
            {
                int x = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].symbol == '◆')
                    {
                        result[x].symbol = you.own[i].symbol;
                        result[x].number = you.own[i].number;
                        x++;
                    }
                }
                Console.WriteLine("{0}의 최종 카드는 플러쉬입니다.", you.Name);
                return 6.25f;
            }
            else if (heart >= 5)
            {
                int x = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].symbol == '♥')
                    {
                        result[x].symbol = you.own[i].symbol;
                        result[x].number = you.own[i].number;
                        x++;
                    }
                }
                Console.WriteLine("{0}의 최종 카드는 플러쉬입니다.", you.Name);
                return 6.5f;
            }
            else if (clov >= 5)
            {
                int x = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].symbol == '♣')
                    {
                        result[x].symbol = you.own[i].symbol;
                        result[x].number = you.own[i].number;
                        x++;
                    }
                }
                Console.WriteLine("{0}의 최종 카드는 플러쉬입니다.", you.Name);
                return 6.75f;
            }
            ////////////////////////////플러쉬 6f

            ///////////////////////////무늬 무관    K Q J 10 A
            fir = false;
            sec = false;
            thi = false;
            fou = false;
            fif = false;
            for (int i = 0; i < 5; i++) //result값 초기화
            {
                result[i].number = -1;
                result[i].symbol = ' ';
            }
            for (int i = 0; i < 7; i++)
            {
                if (you.own[i].number == 13)
                {
                    fir = true;
                }
                if (you.own[i].number == 12)
                {
                    sec = true;
                }
                if (you.own[i].number == 11)
                {
                    thi = true;
                }
                if (you.own[i].number == 10)
                {
                    fou = true;
                }
                if (you.own[i].number == 1)
                {
                    fif = true;
                }
            }
            if (fir && sec && thi && fou && fif)
            {
                Console.WriteLine("{0}의 최종 카드는 마운틴입니다.", you.Name);
                int x = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].number == 13)
                    {
                        result[x].number = 13;
                        result[x].symbol = you.own[i].symbol;
                    }
                }
                x++;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].number == 12)
                    {
                        result[x].number = 12;
                        result[x].symbol = you.own[i].symbol;
                    }
                }
                x++;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].number == 11)
                    {
                        result[x].number = 11;
                        result[x].symbol = you.own[i].symbol;
                    }
                }
                x++;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].number == 10)
                    {
                        result[x].number = 10;
                        result[x].symbol = you.own[i].symbol;
                    }
                }
                x++;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].number == 1)
                    {
                        result[x].number = 1;
                        result[x].symbol = you.own[i].symbol;
                    }
                }
                if (result[0].symbol == '♠')
                {
                    return 7f;
                }
                else if (result[0].symbol == '◆')
                {
                    return 7.25f;
                }
                else if (result[0].symbol == '♥')
                {
                    return 7.5f;
                }
                else if (result[0].symbol == '♣')
                {
                    return 7.75f;
                }
            }
            //////////////////마운틴 7f;

            ///////////////////////////무늬 무관    5 4 3 2 A
            fir = false;
            sec = false;
            thi = false;
            fou = false;
            fif = false;
            for (int i = 0; i < 5; i++) //result값 초기화
            {
                result[i].number = -1;
                result[i].symbol = ' ';
            }
            for (int i = 0; i < 7; i++)
            {
                if (you.own[i].number == 5)
                {
                    fir = true;
                }
                if (you.own[i].number == 4)
                {
                    sec = true;
                }
                if (you.own[i].number == 3)
                {
                    thi = true;
                }
                if (you.own[i].number == 2)
                {
                    fou = true;
                }
                if (you.own[i].number == 1)
                {
                    fif = true;
                }
            }
            if (fir && sec && thi && fou && fif)
            {
                Console.WriteLine("{0}의 최종 카드는 백스트레이트입니다.", you.Name);
                int x = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].number == 5)
                    {
                        result[x].number = 5;
                        result[x].symbol = you.own[i].symbol;
                    }
                }
                x++;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].number == 4)
                    {
                        result[x].number = 4;
                        result[x].symbol = you.own[i].symbol;
                    }
                }
                x++;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].number == 3)
                    {
                        result[x].number = 3;
                        result[x].symbol = you.own[i].symbol;
                    }
                }
                x++;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].number == 2)
                    {
                        result[x].number = 2;
                        result[x].symbol = you.own[i].symbol;
                    }
                }
                x++;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].number == 1)
                    {
                        result[x].number = 1;
                        result[x].symbol = you.own[i].symbol;
                    }
                }
                if (result[0].symbol == '♠')
                {
                    return 8f;
                }
                else if (result[0].symbol == '◆')
                {
                    return 8.25f;
                }
                else if (result[0].symbol == '♥')
                {
                    return 8.5f;
                }
                else if (result[0].symbol == '♣')
                {
                    return 8.75f;
                }
            }
            /////////////////백스트레이트 8f;
            
            ///////////////////무늬에 무관한 연속 숫자 5개
            for (int i = 0; i < 5; i++) //result값 초기화
            {
                result[i].number = -1;
                result[i].symbol = ' ';
            }
            int che = 0;
            for (int i = 0; i < 13; i++)
            {
                int j = (i+1) % 13;
                int k = (i+2) % 13;
                int l = (i+3) % 13;
                int m = (i+4) % 13;
                if (same[i] >= 1 && same[j] >= 1 && same[k] >=1 && same[l]>=1 && same[m] >= 1)
                {
                    Console.WriteLine("{0}의 최종 카드는 스트레이트입니다.", you.Name);
                    for (int b = 0; b < 7; b++)
                    {
                        if (you.own[b].number == i + 1)
                        {
                            result[0].number = you.own[b].number;
                            result[0].symbol = you.own[b].symbol;
                            break;
                        }
                    }
                    for (int b = 0; b < 7; b++)
                    {
                        if (you.own[b].number == j + 1)
                        {
                            result[1].number = you.own[b].number;
                            result[1].symbol = you.own[b].symbol;
                            break;
                        }
                    }
                    for (int b = 0; b < 7; b++)
                    {
                        if (you.own[b].number == k + 1)
                        {
                            result[2].number = you.own[b].number;
                            result[2].symbol = you.own[b].symbol;
                            break;
                        }
                    }
                    for (int b = 0; b < 7; b++)
                    {
                        if (you.own[b].number == l + 1)
                        {
                            result[3].number = you.own[b].number;
                            result[3].symbol = you.own[b].symbol;
                            break;
                        }
                    }
                    for (int b = 0; b < 7; b++)
                    {
                        if (you.own[b].number == m + 1)
                        {
                            result[4].number = you.own[b].number;
                            result[4].symbol = you.own[b].symbol;
                            break;
                        }
                    }
                    che = i + 1;
                    if (result[0].number == 1)
                    {
                        return 9f;
                    }
                    else if (result[3].number == 13)
                    {
                        return 9.1f;
                    }
                    else if (result[3].number == 12)
                    {
                        return 9.2f;
                    }
                    else if (result[3].number == 11)
                    {
                        return 9.3f;
                    }
                    else if (result[3].number == 10)
                    {
                        return 9.4f;
                    }
                    else if (result[3].number == 9)
                    {
                        return 9.5f;
                    }
                    else if (result[3].number == 8)
                    {
                        return 9.6f;
                    }
                    else if (result[3].number == 7)
                    {
                        return 9.7f;
                    }
                    else if (result[3].number == 6)
                    {
                        return 9.8f;
                    }
                    else if (result[3].number == 5)
                    {
                        return 9.9f;
                    }
                    else if (result[3].number == 4)
                    {
                        return 9.92f;
                    }
                    else if (result[3].number == 3)
                    {
                        return 9.94f;
                    }
                    else if (result[3].number == 2)
                    {
                        return 9.96f;
                    }
                    else if (result[3].number == 1)
                    {
                        return 9.98f;
                    }
                    break;
                }
            }

            ///////////////////스트레이트9f
            
            //무늬 무관 같은 숫자 4개
            for (int i = 0; i < 5; i++) //result값 초기화
            {
                result[i].number = -1;
                result[i].symbol = ' ';
            }
            for (int i = 0; i < same.Length; i++)
            {
                int x = 0;
                if (same[i] >= 3)
                {
                    Console.WriteLine("{0}의 최종 카드는 트리플입니다.", you.Name);
                    for (int j = 0; j < 7; j++)
                    {
                        if (you.own[j].number == i + 1)
                        {
                            result[x].symbol = you.own[j].symbol;
                            result[x].number = i + 1;
                            x++;
                        }
                    }
                }
            }
            if (result[0].number == 1)
            {
                return 10.0f;
            }
            else if (result[0].number == 13)
            {
                return 10.1f;
            }
            else if (result[0].number == 12)
            {
                return 10.2f;
            }
            else if (result[0].number == 11)
            {
                return 10.3f;
            }
            else if (result[0].number == 10)
            {
                return 10.4f;
            }
            else if (result[0].number == 9)
            {
                return 10.5f;
            }
            else if (result[0].number == 8)
            {
                return 10.6f;
            }
            else if (result[0].number == 7)
            {
                return 10.7f;
            }
            else if (result[0].number == 6)
            {
                return 10.8f;
            }
            else if (result[0].number == 5)
            {
                return 10.9f;
            }
            else if (result[0].number == 4)
            {
                return 10.92f;
            }
            else if (result[0].number == 3)
            {
                return 10.94f;
            }
            else if (result[0].number == 2)
            {
                return 10.96f;
            }
            /////////////트리플 10f

            /////////////다른 무늬 같은 숫자 2개, 2개
            for (int i = 0; i < 5; i++) //result값 초기화
            {
                result[i].number = -1;
                result[i].symbol = ' ';
            }
            fir = false;
            sec = false;
            first = 0; second = 0;
            int a = 0;
            for (a = 0; a < same.Length; a++)
            {
                if (same[a] >= 2)
                {
                    sec = true;
                    second = a + 1;
                    break;
                }
            }
            for (int j = a + 1; j < same.Length; j++)
            {
                if (same[j] >= 2)
                {
                    fir = true;
                    first = j + 1;
                    break;
                }
            }
            if (fir && sec && (first != second))
            {
                Console.WriteLine("{0}의 최종 카드는 투페어입니다.", you.Name);
                int x = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].number == first)
                    {
                        result[x].number = you.own[i].number;
                        result[x].symbol = you.own[i].symbol;
                        x++;
                    }
                }
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].number == second)
                    {
                        result[x].number = second;
                        result[x].symbol = you.own[i].symbol;
                        x++;
                    }
                }
            }

            if (result[2].number == 1)
            {
                return 11.0f;
            }
            else if (result[0].number == 13)
            {
                return 11.1f;
            }
            else if (result[0].number == 12)
            {
                return 11.2f;
            }
            else if (result[0].number == 11)
            {
                return 11.3f;
            }
            else if (result[0].number == 10)
            {
                return 11.4f;
            }
            else if (result[0].number == 9)
            {
                return 11.5f;
            }
            else if (result[0].number == 8)
            {
                return 11.6f;
            }
            else if (result[0].number == 7)
            {
                return 11.7f;
            }
            else if (result[0].number == 6)
            {
                return 11.8f;
            }
            else if (result[0].number == 5)
            {
                return 1.9f;
            }
            else if (result[0].number == 4)
            {
                return 11.92f;
            }
            else if (result[0].number == 3)
            {
                return 11.94f;
            }
            else if (result[0].number == 2)
            {
                return 11.96f;
            }
            ////////////////////////////투페어 11f

            /////////////다른 무늬 같은 숫자 2개
            for (int i = 0; i < 5; i++) //result값 초기화
            {
                result[i].number = -1;
                result[i].symbol = ' ';
            }
            fir = false;
            first = 0;
            for (int i = 0; i < same.Length; i++)
            {
                if (same[i] >= 2)
                {
                    fir = true;
                    first = i + 1;
                    break;
                }
            }
            if (fir)
            {
                Console.WriteLine("{0}의 최종 카드는 원페어입니다.", you.Name);
                int x = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (you.own[i].number == first)
                    {
                        result[x].number = you.own[i].number;
                        result[x].symbol = you.own[i].symbol;
                        x++;
                    }
                }
                if (result[0].number == 1)
                {
                    return 12.0f;
                }
                else if (result[0].number == 13)
                {
                    return 12.1f;
                }
                else if (result[0].number == 12)
                {
                    return 12.2f;
                }
                else if (result[0].number == 11)
                {
                    return 12.3f;
                }
                else if (result[0].number == 10)
                {
                    return 12.4f;
                }
                else if (result[0].number == 9)
                {
                    return 12.5f;
                }
                else if (result[0].number == 8)
                {
                    return 12.6f;
                }
                else if (result[0].number == 7)
                {
                    return 12.7f;
                }
                else if (result[0].number == 6)
                {
                    return 12.8f;
                }
                else if (result[0].number == 5)
                {
                    return 12.9f;
                }
                else if (result[0].number == 4)
                {
                    return 12.92f;
                }
                else if (result[0].number == 3)
                {
                    return 12.94f;
                }
                else if (result[0].number == 2)
                {
                    return 12.96f;
                }
            }

            ////////////////////////////원페어 12f

            ///////////높은 카드 하나
            for (int i = 0; i < 5; i++) //result값 초기화
            {
                result[i].number = -1;
                result[i].symbol = ' ';
            }
            result[0].symbol = you.own[0].symbol;
            result[0].number = you.own[0].number;
            Console.WriteLine("{0}의 최종 카드는 노페어입니다.", you.Name);
            if (result[0].number == 1)
            {
                return 13.0f;
            }
            else if (result[0].number == 13)
            {
                return 13.1f;
            }
            else if (result[0].number == 12)
            {
                return 13.2f;
            }
            else if (result[0].number == 11)
            {
                return 13.3f;
            }
            else if (result[0].number == 10)
            {
                return 13.4f;
            }
            else if (result[0].number == 9)
            {
                return 13.5f;
            }
            else if (result[0].number == 8)
            {
                return 13.6f;
            }
            else if (result[0].number == 7)
            {
                return 13.7f;
            }
            else if (result[0].number == 6)
            {
                return 13.8f;
            }
            else if (result[0].number == 5)
            {
                return 13.9f;
            }
            else if (result[0].number == 4)
            {
                return 13.92f;
            }
            else if (result[0].number == 3)
            {
                return 13.94f;
            }
            else if (result[0].number == 2)
            {
                return 13.96f;
            }
            return 15f; //에러
        } //족보 처리
        static bool com_bet(ref Player you, ref int last_bet, ref int turn_money, ref Computer com)
        {
            bool die = false;
            Random rand = new Random();
            int percent = rand.Next(1, 50);
            if (percent <= 0)
            {
                Console.WriteLine("컴퓨터는 게임을 포기합니다.");
                Console.WriteLine("걸린 판돈 {0}원은 플레이어가 갖습니다.", turn_money);
                you.money += turn_money;
                die = true;
                Console.ReadLine();
                Console.Clear();
                //컴퓨터의 다이
            }
            else if (percent > 40)
            {
                Console.WriteLine("컴퓨터는 하프를 선언합니다.");
                if (com.money > last_bet && com.money < last_bet * 2)
                {
                    Console.WriteLine("{0}는 소지금이 적어 남아있는 전부를 걸었습니다.", com.Name);
                    last_bet = com.money;
                    turn_money += com.money;
                    com.money = 0;
                }
                else if (com.money == 0)
                {
                    Console.WriteLine("{0}는 이미 올인한 상태입니다.");
                }
                else if (com.money < last_bet)
                {
                    Console.WriteLine("{0}는 소지금이 적어 남아있는 전부를 걸었습니다.", com.Name);
                    turn_money += com.money;
                    com.money = 0;
                }
                else
                {
                    Console.WriteLine("{0}는 마지막에 베팅한 금액의 두 배인 {1}원을 베팅합니다.", com.Name, last_bet * 2);
                    com.money -= last_bet * 2;
                    turn_money += last_bet * 2;
                    last_bet *= 2;
                }
                //컴퓨터의 하프
            }
            else
            {
                if (com.money < last_bet)
                {
                    Console.WriteLine("{0}는 소지금이 적어 남아있는 전부를 걸었습니다.", com.Name);
                    turn_money += com.money;
                    com.money = 0;
                }
                else if (com.money == 0)
                {
                    Console.WriteLine("{0}는 이미 올인한 상태입니다.", com.Name);
                }
                else
                {
                    Console.WriteLine("마지막에 베팅한 금액만큼 {0}가 {1}원을 베팅합니다.", com.Name, last_bet);
                    com.money -= last_bet;
                    turn_money += last_bet;
                }
                //컴퓨터의 콜
            }
            return die;
        }
        static bool bet(ref Player you, ref int lastBet, ref int turn_money, ref Computer com) //플레이어 베팅
        {
            bool die = false;
            Console.WriteLine("베팅을 시작합니다. 다이 / 콜 / 하프 중 원하시는 베팅을 선택해주세요: ");
            string input = Console.ReadLine();
            while (input != "다이" && input != "콜" && input != "하프")
            {
                Console.WriteLine("다이 / 콜 / 하프 중 하나의 원하시는 베팅을 선택해주세요: ");
                input = Console.ReadLine();
            }
            if (input == "다이")
            {
                die = true;
                Console.WriteLine("{0}는 게임을 포기합니다.", you.Name);
                Console.WriteLine("걸린 판돈 {0}원은 컴퓨터가 갖습니다.", turn_money);
                com.money += turn_money;
                Console.ReadLine();
                Console.Clear();
            }
            else if (input == "콜")
            {
                if (you.money < lastBet)
                {
                    Console.WriteLine("{0}는 소지금이 적어 남아있는 전부를 걸었습니다.", you.Name);
                    turn_money += you.money;
                    you.money = 0;
                }
                else if (you.money == 0)
                {
                    Console.WriteLine("{0}는 이미 올인한 상태입니다.", you.Name);
                }
                else
                {
                    Console.WriteLine("마지막에 베팅한 금액만큼 {0}가 {1}원을 베팅합니다.", you.Name, lastBet);
                    you.money -= lastBet;
                    turn_money += lastBet;
                }
            }
            else if (input == "하프")
            {
                if (you.money > lastBet && you.money < lastBet * 2)
                {
                    Console.WriteLine("{0}는 소지금이 적어 남아있는 전부를 걸었습니다.", you.Name);
                    lastBet = you.money;
                    turn_money += you.money;
                    you.money = 0;
                }
                else if (you.money == 0)
                {
                    Console.WriteLine("{0}는 이미 올인한 상태입니다.", you.Name);
                }
                else if (you.money < lastBet)
                {
                    Console.WriteLine("{0}은 소지금이 적어 남아있는 전부를 걸었습니다.", you.Name);
                    turn_money += you.money;
                    you.money = 0;
                }
                else
                {
                    Console.WriteLine("{0}는 마지막에 베팅한 금액의 두 배인 {1}원을 베팅합니다.", you.Name, lastBet * 2);
                    you.money -= lastBet * 2;
                    turn_money += lastBet * 2;
                    lastBet *= 2;
                }
            }
            return die;
        }
        static void print(card[] arr, int i)
        {
            if (arr[i].symbol == '♠')
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("{0}", arr[i].symbol);
                Console.ResetColor();
            }
            else if (arr[i].symbol == '◆')
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("{0}", arr[i].symbol);
                Console.ResetColor();
            }
            else if (arr[i].symbol == '♥')
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0}", arr[i].symbol);
                Console.ResetColor();
            }
            else if (arr[i].symbol == '♣')
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0}", arr[i].symbol);
                Console.ResetColor();
            }

            if (arr[i].number > 1 && arr[i].number < 11)
            {
                Console.Write("{0}]  ",arr[i].number);
            }
            else if (arr[i].number == 1)
            {
                Console.Write("A]  ");
            }
            else if (arr[i].number == 11)
            {
                Console.Write("J]  ");
            }
            else if (arr[i].number == 12)
            {
                Console.Write("Q]  ");
            }
            else if (arr[i].number == 13)
            {
                Console.Write("K]  ");
            }
        }
        static card[] Change(int a, card[] arr, int i)
        {
            arr[i].number = a % 13 + 1;
            if ((a / 13) == 0)
            {
                arr[i].symbol = '♠';
            }
            else if ((a / 13) == 1)
            {
                arr[i].symbol = '◆';
            }
            else if ((a / 13) == 2)
            {
                arr[i].symbol = '♥';
            }
            else if ((a / 13) == 3)
            {
                arr[i].symbol = '♣';
            }
            else
            {
                arr[i].symbol = 'a';
            }
            return arr;
        }
        static int[] shuffle()
        {
            Random rand = new Random();
            int[] all = new int[52];
            for (int i = 0; i < 52; i++)
            {
                all[i] = i; //[0]번째 0, [1]번째 1,,, 초기화
            }
            for (int i = 0; i < 1000; i++)
            {
                int first = rand.Next(0, 52);
                int second = rand.Next(0, 52);
                int temp = all[first];
                all[first] = all[second];
                all[second] = temp;
            }
            return all;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            string name = "플레이어";
            Player you = new Player(name);
            Computer com = new Computer();
            int count = 0;
            while (you.money >= 1000 && com.money >= 1000 && count < 5) //나, 컴의 돈이 천원이상, 5판이 안되었을동안 진행
            {
                for (int i = 0; i < 7; i++)
                {
                    you.own[i].symbol = ' ';
                    you.own[i].number = -1;
                }
                bool die = false;
                int turn_money = 0;
                int last_bet = 0;
                int[] cards = new int[52];
                Console.WriteLine("포커게임을 시작합니다.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("당신의 소지금은 {0}원, 컴퓨터의 소지금은 {1}원입니다.", you.money, com.money);
                Console.ResetColor();
                Console.WriteLine("기본금으로 베팅금 1000원을 베팅합니다.\n\n52장의 카드를 무작위로 섞습니다.");
                you.money -= 1000;
                com.money -= 1000;
                turn_money += 2000;
                last_bet = 1000;
                cards = shuffle();
                //임의로 정해서 테스트
                //cards[0] = 12;
                //cards[1] = 24;
                //cards[2] = 26;
                //cards[7] = 40;
                //cards[9] = 2;
                //cards[11] = 3;
                //cards[13] = 15;
                card[] first = new card[52];

                for (int i = 0; i < 52; i++)
                {
                    first = Change(cards[i], first, i);
                }

                Console.WriteLine("당신에게 4장의 카드를 나눠줍니다.");
                Console.Write("\n당신의 카드는 ");
                for (int i = 0; i < 4; i++)
                {
                    Console.Write("{0})", i + 1);
                    print(first, i);
                }
                Console.WriteLine("입니다");
                Console.Write("버리실 카드를 입력해주세요 (1~4): ");
                int input = int.Parse(Console.ReadLine());
                while (input > 4 || input < 1)
                {
                    Console.Write("버리실 카드를 범위내로 입력해주세요 (1~4): ");
                    input = int.Parse(Console.ReadLine());
                }
                Console.WriteLine();
                print(first, input - 1);
                Console.WriteLine("카드를 버렸습니다.");
                if (input == 1)
                {
                    you.own[0].number = first[1].number;
                    you.own[0].symbol = first[1].symbol;
                    you.own[1].number = first[2].number;
                    you.own[1].symbol = first[2].symbol;
                    you.own[2].number = first[3].number;
                    you.own[2].symbol = first[3].symbol;
                }
                else if (input == 2)
                {
                    you.own[0].number = first[0].number;
                    you.own[0].symbol = first[0].symbol;
                    you.own[1].number = first[2].number;
                    you.own[1].symbol = first[2].symbol;
                    you.own[2].number = first[3].number;
                    you.own[2].symbol = first[3].symbol;
                }
                else if (input == 3)
                {
                    you.own[0].number = first[0].number;
                    you.own[0].symbol = first[0].symbol;
                    you.own[1].number = first[1].number;
                    you.own[1].symbol = first[1].symbol;
                    you.own[2].number = first[3].number;
                    you.own[2].symbol = first[3].symbol;
                }
                else if (input == 4)
                {
                    you.own[0].number = first[0].number;
                    you.own[0].symbol = first[0].symbol;
                    you.own[1].number = first[1].number;
                    you.own[1].symbol = first[1].symbol;
                    you.own[2].number = first[2].number;
                    you.own[2].symbol = first[2].symbol;
                }
                Console.ReadLine();
                Console.Clear();
                ///////////////////////////////////////////////////////////////////////////////////////////
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("$$ {0}의 잔액: {1}원   {2}의 잔액: {3}원      판돈: {4}원 $$\n", you.Name, you.money, com.Name, com.money, turn_money);
                Console.ResetColor();
                Console.WriteLine("컴퓨터의 카드 하나를 공개합니다.");
                Console.Write("컴퓨터의 카드: "); //컴퓨터는 4, 5, 6 가지고있음
                for (int i = 0; i < 3; i++)
                {
                    com.own[i].number = first[i + 4].number;
                    com.own[i].symbol = first[i + 4].symbol;
                }
                print(first, 4);
                Console.WriteLine("[///]  [///]\n");
                Console.WriteLine("두 분에게 각각 오픈카드를 하나씩 추가합니다.");
                Console.Write("플레이어에게 ");
                print(first, 7);
                Console.Write("카드를, 컴퓨터에게 ");
                print(first, 8);
                Console.WriteLine("카드를 추가합니다.");
                you.own[3].number = first[7].number;
                you.own[3].symbol = first[7].symbol;
                com.own[3].number = first[8].number;
                com.own[3].symbol = first[8].symbol;

                Console.WriteLine("\n============================================================");
                Console.Write("컴퓨터의 카드 ");
                print(com.own, 0);
                Console.Write("[///]  [///]  ");
                print(com.own, 3);

                Console.Write("\n\n당신의 카드 ");
                for (int i = 0; i < you.own.Length; i++)
                {
                    print(you.own, i);
                }
                Console.WriteLine("\n============================================================\n");

                //플레이어 베팅
                die = bet(ref you, ref last_bet, ref turn_money, ref com);
                if (die)
                {
                    continue;
                }
                bool comdie = com_bet(ref you, ref last_bet, ref turn_money, ref com);
                if (comdie)
                {
                    continue;
                }
                Console.ReadLine();
                Console.Clear();
                /////////////////////////////////////////////////////////////////////////////////
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("$$ {0}의 잔액: {1}원   {2}의 잔액: {3}원      판돈: {4}원 $$\n", you.Name, you.money, com.Name, com.money, turn_money);
                Console.ResetColor();
                Console.Write("두 분에게 각각 오픈카드를 하나씩 추가합니다.\n플레이어에게 ");
                print(first, 9);
                Console.Write("카드를, 컴퓨터에게 ");
                print(first, 10);
                Console.WriteLine("카드를 추가합니다.");
                you.own[4].number = first[9].number;
                you.own[4].symbol = first[9].symbol;
                com.own[4].number = first[10].number;
                com.own[4].symbol = first[10].symbol;

                Console.WriteLine("\n============================================================");
                Console.Write("컴퓨터의 카드 ");
                print(com.own, 0);
                Console.Write("[///]  [///]  ");
                print(com.own, 3);
                print(com.own, 4);

                Console.Write("\n\n당신의 카드 ");
                for (int i = 0; i < you.own.Length; i++)
                {
                    print(you.own, i);
                }
                Console.WriteLine("\n============================================================\n");

                die = bet(ref you, ref last_bet, ref turn_money, ref com);
                if (die)
                {
                    continue;
                }
                comdie = com_bet(ref you, ref last_bet, ref turn_money, ref com);
                if (comdie)
                {
                    continue;
                }
                Console.ReadLine();
                Console.Clear();
                ////////////////////////////////////////////////////////////////////
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("$$ {0}의 잔액: {1}원   {2}의 잔액: {3}원      판돈: {4}원 $$\n", you.Name, you.money, com.Name, com.money, turn_money);
                Console.ResetColor();
                Console.Write("두 분에게 각각 오픈카드를 하나씩 추가합니다.\n플레이어에게 ");
                print(first, 11);
                Console.Write("카드를, 컴퓨터에게 ");
                print(first, 12);
                Console.WriteLine("카드를 추가합니다.");
                you.own[5].number = first[11].number;
                you.own[5].symbol = first[11].symbol;
                com.own[5].number = first[12].number;
                com.own[5].symbol = first[12].symbol;

                Console.WriteLine("\n============================================================");
                Console.Write("컴퓨터의 카드 ");
                print(com.own, 0);
                Console.Write("[///]  [///]  ");
                print(com.own, 3);
                print(com.own, 4);
                print(com.own, 5);

                Console.Write("\n\n당신의 카드 ");
                for (int i = 0; i < you.own.Length; i++)
                {
                    print(you.own, i);
                }
                Console.WriteLine("\n============================================================\n");

                die = bet(ref you, ref last_bet, ref turn_money, ref com);
                if (die)
                {
                    continue;
                }
                comdie = com_bet(ref you, ref last_bet, ref turn_money, ref com);
                if (comdie)
                {
                    continue;
                }
                Console.ReadLine();
                Console.Clear();
                ////////////////////////////////////////////////////////////////////
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("$$ {0}의 잔액: {1}원   {2}의 잔액: {3}원      판돈: {4}원 $$\n", you.Name, you.money, com.Name, com.money, turn_money);
                Console.ResetColor();
                Console.Write("두 분에게 각각 히든카드를 하나씩 추가합니다.\n플레이어에게 ");
                print(first, 13);
                Console.WriteLine("카드를 추가합니다.");
                you.own[6].number = first[13].number;
                you.own[6].symbol = first[13].symbol;
                com.own[6].number = first[14].number;
                com.own[6].symbol = first[14].symbol;

                Console.WriteLine("\n============================================================");
                Console.Write("컴퓨터의 카드 ");
                print(com.own, 0);
                Console.Write("[///]  [///]  ");
                print(com.own, 3);
                print(com.own, 4);
                print(com.own, 5);
                Console.Write("[///]  ");

                Console.Write("\n\n당신의 카드 ");
                for (int i = 0; i < you.own.Length; i++)
                {
                    print(you.own, i);
                }
                Console.WriteLine("\n============================================================\n");

                die = bet(ref you, ref last_bet, ref turn_money, ref com);
                if (die)
                {
                    continue;
                }
                comdie = com_bet(ref you, ref last_bet, ref turn_money, ref com);
                if (comdie)
                {
                    continue;
                }
                //족보 확인해서 돈 나누기 

                order(ref you); //내림차순 정렬
                order(ref com);
                Console.WriteLine("\n");
                Console.ReadLine();
                Console.Clear();
                Console.Write("플레이어의 7장 카드: ");
                for (int i = 0; i < you.own.Length; i++)
                {
                    print(com.own, i);
                }
                Console.Write("\n컴퓨터의 7장 카드: ");
                for (int i = 0; i < you.own.Length; i++)
                {
                    print(you.own, i);
                }
                Console.WriteLine("\n");
                card[] result = new card[7];
                float player_rank = 0;
                player_rank = check(you, ref result);
                for (int i = 0; i < result.Length; i++)
                {
                    if (i > 4)
                    {
                        break;
                    }
                    print(result, i);
                }
                Console.WriteLine();
                card[] com_result = new card[7];
                float com_rank = 0;
                com_rank = check(com, ref com_result);
                for (int i = 0; i < com_result.Length; i++)
                {
                    if (i > 4)
                    {
                        break;
                    }
                    print(com_result, i);
                }

                if (player_rank < com_rank) //플레이어 승리
                {
                    Console.WriteLine("\n플레이어의 승리");
                    Console.WriteLine("플레이어가 판돈 {0}원을 획득합니다.", turn_money);
                    you.money += turn_money;
                }
                else
                {
                    Console.WriteLine("\n컴퓨터의 승리");
                    Console.WriteLine("컴퓨터가 판돈 {0}원을 획득합니다.", turn_money);
                    com.money += turn_money;
                }

                Console.ReadLine();
                Console.Clear();
            }
            if (you.money < 1000)
            {
                Console.WriteLine("플레이어의 파산");
            }
            else if (com.money < 1000)
            {
                Console.WriteLine("컴퓨터의 파산");
                
            }
        }
    }
}
