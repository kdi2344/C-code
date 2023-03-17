using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230314_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //if -> 만약에
            //코드의 흐름을 제어하는 구문
            //특정 조건에 의해 선택적 실행이 가능
            //if의 동작 조건? 참일 경우 실행
            if (true) //조건이 참이면, 거짓이면 실행 X
            { //여기부터
                Console.WriteLine("참이면 실행");
            } //여기까지 코드 블럭 실행

            int num = 10;
            if (num >= 10) //num이 10보다 같거나 크다면 실행해라
            {
                Console.WriteLine(num);
            }

            //다음과 같은 if문이 있다면?
            int num1 = 10;
            if (num1 >= 10)
            {
                Console.WriteLine("첫번째 if문");
            }
            if (num1 == 10)
            {
                Console.WriteLine("두번째 if문");
            }
            if (num1 <= 10)
            {
                Console.WriteLine("세번째 if문");
            }
            //위 3개의 if문은 모든 조건을 만족해 위의 모든 출력문을 실행함
            //즉 첫번째 조건을 만족하더라도, 그 아래에 있는 if문을 모두 검사함

            int number = 5;
            if (number > 6)
            {
                Console.WriteLine("6보다 큼");
            }
            else //위의 if문이 거짓일 경우 여기 실행
            {
                Console.WriteLine("6보다 작음");
            }

            int input;
            input = int.Parse(Console.ReadLine());
            //입력받은 정수를 2로 나눈 나머지가 0이라면 == 짝수라면
            if ((input % 2) == 0) //if의 개수제한은 없음
            {
                Console.WriteLine("짝수");
            }
            else //  (input % 2) == 1도 되고 (input % 2) != 0도 됨
            //else는 하나만 가능, else위에는 if또는 else if가 있어야 함, else는 조건을 붙일 수 없음
            {
                Console.WriteLine("홀수");
            }

            //if ~ else if
            int playerHp = 10;
            if (playerHp >= 0)
            {
                Console.WriteLine("만족한다면 첫번째 if문 실행");
            }
            else if (playerHp == 10) //아래 else if가 만족해도 위의 if문이 참이라 else if, else는 다 검사안함
            {
                Console.WriteLine("만족한다면 두번째 if문 실행");
            }
            else if (playerHp <= 10)
            {
                Console.WriteLine("만족한다면 세번째 if문 실행");
            }

            int playerMp = 10;
            if (playerMp <= 0)
            {
                Console.WriteLine("첫번째 if문");
            }
            else if (playerMp >= 1)
            {
                Console.WriteLine("두번째 if문"); //>> 실행
            }
            else if (playerMp >= 2)
            {
                Console.WriteLine("세번째 if문"); //여기도 참이지만 위의 else if 가 실행되었으므로 여기부터 검사 X
            }
            else
            {
                Console.WriteLine("위 조건을 모두 만족하지 않음");
            }

            Console.Write("숫자 입력: ");
            int sojuNum = int.Parse(Console.ReadLine());
            if (sojuNum > 0)
            {
                if (sojuNum % 2 == 0) //중첩 if문, 중첩의 제한은 없으나 복잡해짐
                {
                    Console.WriteLine("입력한 결과는 양수이고 짝수임");
                }
                else
                {
                    Console.WriteLine("입력한 결과는 양수이고 홀수임");
                }
            }
            else
            {
                Console.WriteLine("0이나 음수");
            }

            //숙제
        }
    }
}
