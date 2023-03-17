using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230313
{
    class Program   
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("개행 있는 애"); //출력 담당
            //Console.Write("개행 없는 애");

            //변수란 무엇인가 -> 데이터를 담는 공간 (플밍적 관점) 1+1 = 2 => 할당식의 왼쪽은 변수, 속성, 인덱서 오류
            //수학의 = 같다 / 플밍의 = 대입 변수로 변경 number = 2=> 현재 컨텍스트에 없다 오류 2의 크기를 모름, 알아야지만 컴퓨터가 저장가능, 메모리
            //int number; 데이터의 형식 int 부호있는 32비트 정수 => 4byte, number = 변수의 이름, ;: 문장의 끝 => 컴파일러한테 변수 선언
            /* 변수 이름의 규칙
            1. 변수의 첫 글자는 반드시 문자로 지정 int 1 (X)
            2. 공백이 올 수 없음
            3. C#에서 제공하는 예약어 / 키워드 / 메소드 이름들은 변수의 이름으로 사용 불가
            =========================================================================================
            @. 대소문자 구분, int number != int Number
            @. 변수는 일반적으로 소문자로 시작
            @. 변수 이름 한글도 되긴 됨,, 처음 알았,, but 협업을 위해 한글 쓰지말고 영어로 짓자,,,
            @. 변수 이름을 지을때는 이름만 봐도 어떤 데이터를 나타내는지 알아볼 수 있게 짓자 (a, b, c / num1, num2 금지)
            =========================================================================================
            관례로 통상적으로 지키는 이름 표기법, 회사마다 커스텀해서 사용하기도
            1. 카멜 표기법: 단어가 여러개가 붙을 때 맨 앞을 제외한 단어의 첫 글자를 대문자로 표기 (낙타 등같이 오르락 내리락) => playerNumber
            2. 파스칼 표기법: 모든 단어의 첫 글자를 대문자로 (변수일때는 잘 안씀) - 클래스, 함수 etc
            3. 스네이크 표기법: 단어 사이에 _ (underscore) 붙이기, player_Number (뱀같이 보인다나 모라나) 
            4. 헝가리안 표기법: 예약어의 단어 하나를 맨 앞에 붙이기, int number => int inumber 식으로 (요즘은 안쓰는 추세)
            alt + 위 / 아래: 한 줄 이동, ctrl+D: 한 줄 복제
             */

            //int number; // 변수 선언만 한 상태, (변수 값을 할당할 때 변수 이름 모름, 저장된 주소를 불러와서 가져옴)
            //int number; => 같은 이름은 중복선언이 불가.
            //Console.WriteLine(number); //=> 초기화(어떠한 값 최초 할당)가 안 된 상태라 오류 발생 

            int number1; //선언
            number1 = 10; //데이터 할당
            Console.WriteLine(number1); //number1에 할당되어 있는 값 출력

            int number2 = 50; //선언과 동시에 할당
            Console.WriteLine(number2);

            //int a, b, c; //같은 데이터 타입 변수 동시에 선언 가능, 이름이 길고 많다면 잘 안씀, 코드는 누가봐도 알 수 있게 짜야 좋은 코드
            //int d = 3, e = 4; //선언과 동시에 초기화를 한번에 여러 개 하는 것도 가능 

            /*
            숫자 데이터 형식
            - C#에서는 숫자 형식의 데이터를 다룰 때 사용하는 int 키워드를 포함하여 여러가지 키워드를 제공함.
              숫자 데이터 형식은 크게 정수형과 실수형.
              다시 부호가 있는 숫자와 없는 숫자로 나눔.
            - 정수 데이터는 음의 정수, 0, 양의 정수가 전부임.
            - 프로그래머가 코드에 사용될 데이터가 얼마냐를 가늠하고 데이터 형식을 선택함으로써 메모리를 효율적으로 사용하기 위해 다양한 종류를 제공. 2byte쓰는데 int쓰면 2byte 낭비니깐.
            
            데이터 형식                        크기 (byte)
            byte                                 1
            sbyte(short byte)                    1
            short                                2
            ushort(unsigned 부호X)               2 
            int                                  4   컴퓨터는 연산 속도가 4byte씩 끊어서 계산하는게 훨 빠름.
            uint                                 4
            long                                 8
            ulong                                8


            부동 소수점 형식 (실수형이라고 생각)
            - 정수뿐만 안이라 유리수를 포함하는 실수 영역에서 데이터를 다룬다. (정수 타입보다 느리다.)
            - 정수 형식을 대체하지 못한다.
            
            float(4byte)   : 단일 정밀도 부동 소수점 형식 (7자릿수만 다룰 수 있음)
            double(8byte)  : 복수 정밀도 부동 소수점 형식 
            decimal(16byte)

             + 메모리 패딩 설명
             */

            float pi = 3.1415_9265_3589_7932_3846f; //구분자로 사용하는 _, 반올림해서 데이터 자르고
            double pi_2 = 3.1415_9265_3589_7932_3846; //실수 데이터는 오차 발생이 불가피함, 데이터 잘림
            decimal pi_3 = 3.1415_9265_3589_7932_3846M; //데이터 범위 넓은 걸 쓰면 정밀도 면에서 좀 나아짐
            Console.WriteLine(pi);
            Console.WriteLine(pi_2);
            Console.WriteLine(pi_3);

            //문자
            char a = '안'; //"안" 은 안됨 ""는 문자열, char는 단일 문자라 안됨.
            char b = '녕';
            char c = '하';
            char d = '세';
            char e = '야';
            //int tntwk = 'A'; //출력시 아스키코드로 65 나옴
            Console.Write(a);
            Console.Write(b);
            Console.Write(c);
            Console.Write(d);
            Console.WriteLine(e);

            //문자열
            string str = "배고프다";
            string str1 = "많이 배고프다";
            Console.WriteLine(str);
            Console.WriteLine(str1);

            //논리형식, 참과 거짓을 표현 (true, false)
            //어떤 작업이 성공했는지, 비교 데이터가 일치하는지 판단할 때 사용.
            bool isDamage = true;
            bool isCheck = false; //0 false, 나머지 true로 인식
            Console.WriteLine(isDamage);
            Console.WriteLine(isCheck);


            //입력 받기
            //Console.ReadLine(); 읽는게 string type, 입력받기 전까지 여기서 대기
            string inputStr; //문자열 타입의 변수 선언
            inputStr = Console.ReadLine(); //입력받은 데이터를 문자열 변수에 할당
            Console.WriteLine(inputStr); //저장한 데이터 출력
            int inputNum;
            //inputNum = Console.ReadLine(); 숫자를 받고싶은데 타입이 안맞아 불가
            inputNum = int.Parse(Console.ReadLine()); //=> int.parse는 string type을 매개변수로 받아 int로 바꿔줌
            Console.Write("입력한 숫자 : "); Console.WriteLine(inputNum);

            int hp, mp, att, def, cri;
            string playerName;

            Console.Write("플레이어 이름을 입력해주세요: ");  
            playerName =  Console.ReadLine();
            Console.Write("플레이어의 HP를 입력해주세요: ");  
            hp =  int.Parse(Console.ReadLine());
            Console.Write("플레이어의 MP를 입력해주세요: ");  
            mp =  int.Parse(Console.ReadLine());
            Console.Write("플레이어의 공격력을 입력해주세요: ");  
            att =  int.Parse(Console.ReadLine());
            Console.Write("플레이어의 방어력을 입력해주세요: ");  
            def =  int.Parse(Console.ReadLine());
            Console.Write("플레이어의 크리티컬을 입력해주세요: ");  
            cri =  int.Parse(Console.ReadLine()); 
            Console.WriteLine();

            Console.WriteLine(playerName+ "의 기본 능력치");
            Console.WriteLine(playerName + "의 HP: " + hp);
            Console.WriteLine(playerName + "의 MP: " + mp);
            Console.WriteLine(playerName + "의 att: " + att);
            Console.WriteLine(playerName + "의 def: " + def);
            Console.WriteLine(playerName + "의 cri: " + cri);
        }
    }
}