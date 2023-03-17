using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230313_homeWork_operator
{
    class Program
    {
        static void Main(string[] args)
        {
            int first;
            int second;
            int result;
            Console.Write("첫번째 수를 입력해주세요: "); 
            first = int.Parse(Console.ReadLine());
            Console.Write("두번째 수를 입력해주세요: "); 
            second = int.Parse(Console.ReadLine());
            result = first + second; 
            Console.WriteLine($"{first} + {second} = {result}");
            result = first - second; 
            Console.WriteLine($"{first} - {second} = {result}");
            result = first * second; 
            Console.WriteLine($"{first} * {second} = {result}");
            result = first / second; 
            Console.WriteLine($"{first} / {second} = {result}");
            result = first % second; 
            Console.WriteLine($"{first} % {second} = {result}");
            Console.WriteLine();

            //////////////////////////////////////////////////////////////////////////////

            int plHp = 3000;
            int plAtk;
            int monHp = 500;
            int monAtk;
            int monHeal = 10;
            string monName;
            Console.Write("몬스터의 이름을 입력하세요: "); 
            monName = Console.ReadLine();
            Console.WriteLine($"플레이어의 기본 체력: {plHp}\n{monName}의 기본 체력: {monHp}");
            Console.Write("플레이어의 공격력을 입력하세요: "); 
            plAtk = int.Parse(Console.ReadLine());
            Console.Write("몬스터의 공격력을 입력하세요: ");
            monAtk = int.Parse(Console.ReadLine());
            Console.WriteLine($"\n플레이어가 전장을 누비던 도중 {monName}을/를 만났다.");
            Console.WriteLine($"플레이어의 공격! {plAtk}");
            Console.WriteLine($"{monName}이/가 플레이어 공격에 데미지를 입었다.");
            monHp -= plAtk;
            Console.WriteLine($"{monName}의 남은 체력: {monHp}");
            if (monHp > 0)
            {
                monHp += monHeal;
                Console.WriteLine($"살아남은 {monName}의 스킬 힐로 {monName}의 체력은 {monHp}이 되었다.");
                Console.WriteLine($"{monName}의 반격! {monAtk}");
                plHp -= monAtk;
                Console.WriteLine("플레이어의 남은 체력: {0}", plHp);
            }
            else
                Console.WriteLine("{0}이/가 죽었다.", monName);
        }
    }
}
