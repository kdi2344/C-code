using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230313_1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //오늘 숙제
            /*
            1. 두 수를 입력을 받아 결과를 출력하자. 단, Console.WriteLine(result) 형식
            2. 플레이어가 있고, 몬스터가 있다.
            플레이어는 다음과 같은 스탯이 존재한다.
            2-1. Hp, Input(atk), 
            몬스터도 위와 같은 스탯이 있다.
            플레이어가 공격하면 몬스터의 Hp는 깎인다.
            
            플레이어가 전장을 누비던 도중 000을 만났다.      
            플레이어 공격!: 10 (공격력만큼)
            고블린이 플레이어 공격에 데미지 입음.
            몬스터의 남은 체력: ???

            */

            int first, second, result;
            Console.Write("첫번째 수를 입력해주세요: "); first = int.Parse(Console.ReadLine());
            Console.Write("두번째 수를 입력해주세요: "); second = int.Parse(Console.ReadLine());
            result = first + second; Console.WriteLine(first + " + " + second + " = " + result);
            result = first - second; Console.WriteLine(first + " - " + second + " = " + result);
            result = first * second; Console.WriteLine(first + " * " + second + " = " + result);
            result = first / second; Console.WriteLine(first + " / " + second + " = " + result);
            result = first % second; Console.WriteLine(first + " % " + second + " = " + result);
            Console.WriteLine();


            int plHp = 300, plAtk, monHp = 100, monAtk;
            string monName;
            Console.Write("몬스터의 이름을 입력하세요: "); monName = Console.ReadLine();
            Console.Write("플레이어의 공격력을 입력하세요: "); plAtk = int.Parse(Console.ReadLine());
            Console.Write("몬스터의 공격력을 입력하세요: "); monAtk = int.Parse(Console.ReadLine());
            Console.WriteLine("플레이어가 전장을 누비던 도중 " + monName + "을 만났다.");
            Console.WriteLine("플레이어 공격!: " + plAtk);
            Console.WriteLine(monName + "이 플레이어 공격에 데미지를 입었다.");
            Console.Write(monName + "의 남은 체력: "); Console.WriteLine(monHp - plAtk);



        }
    }
}
