using System;

//키워드: 프로그래밍적 관점에서 봤을때 프로그래밍 언어의 규격에 의해 미리 정의되어있는 특별한 단어
//System: C#코드가 기본적으로 필요로하는 class를 담고있는 namespace

namespace _20230310
{
    class Program //C# 프로그램을 구성하는 기본적인 단위, C#은 최소 하나 이상의 클래스로 구성
    {
        //프로그램 실행이 시작되는 곳, main: 명령규칙위반
        //진입점(entry point)에 적합한 정적 main 메소드 (static void Main), 반드시 하나만 존재 중복불가

     //한정자 반환형식 메서드 이름 (매개변수 parameter)
        static void Main(string[] args) 
        { //코드 블록, 영역
            Console.Write("줄바꿈 안됨 ");
            Console.WriteLine("줄바꿈 됨"); //System을 활성화시킴, System에 담긴거 써서, ; : 문장의 끝을 알림
            Console.WriteLine(1); //WriteLine: 출력 + 개행 담당, "" : 문자열 / '' : 단일 문자 /  1 : 숫자

        }
    }
}

/* 
// : 주석, 컴파일러가 인지X, 코멘트로 사용
오타, 괄호 실수 주의
코드를 작성하지 못하는 이유)
 1. 너무 겁 먹음, 머리로는 아는데 키보드를 못침 
=> (1) 정리 (한글로 풀어쓰기) (2) 코드로 옮기기


*/