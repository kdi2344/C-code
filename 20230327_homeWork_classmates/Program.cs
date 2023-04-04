using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230327_homeWork_classmates
{
    class Program
    {
        static void show_seat()
        {
            Console.WriteLine("\n다음은 프로그래밍 40기의 자리배치이다.");
            Console.WriteLine("┌─────────┐┌─────────┐┌─────────┐┌─────────┐               ┌─────────┐┌─────────┐┌─────────┐┌─────────┐");
            Console.WriteLine("│  박주혜 ││  성민경 ││  박상연 ││  제현준 │               │   허진  ││  주성현 ││  정수민 ││  이성준 │");
            Console.WriteLine("└─────────┘└─────────┘└─────────┘└─────────┘               └─────────┘└─────────┘└─────────┘└─────────┘");
            Console.WriteLine("┌─────────┐┌─────────┐┌─────────┐┌─────────┐               ┌─────────┐┌─────────┐┌─────────┐┌─────────┐");
            Console.WriteLine("│  양경훈 ││  김현희 ││  최영일 ││  강윤석 │               │  목지아 ││  경민아 ││  고석환 ││  김윤혜 │");
            Console.WriteLine("└─────────┘└─────────┘└─────────┘└─────────┘               └─────────┘└─────────┘└─────────┘└─────────┘");
            Console.WriteLine("┌─────────┐┌─────────┐┌─────────┐┌─────────┐               ┌─────────┐┌─────────┐┌─────────┐┌─────────┐");
            Console.WriteLine("│  김대현 ││  이도엽 ││  노소영 ││  국동근 │               │  강단이 ││  이유리 ││  박라현 ││  구윤성 │");
            Console.WriteLine("└─────────┘└─────────┘└─────────┘└─────────┘               └─────────┘└─────────┘└─────────┘└─────────┘");
            Console.WriteLine("┌─────────┐┌─────────┐                                     ┌─────────┐┌─────────┐┌─────────┐");
            Console.WriteLine("│  이수민 ││  이상훈 │                                     │  임종서 ││  김민수 ││  공병현 │");
            Console.WriteLine("└─────────┘└─────────┘                                     └─────────┘└─────────┘└─────────┘\n");
            Console.Write("정보가 궁금한 사람의 이름을 입력하시오: ");
        }
        static void Main(string[] args)
        {
            while (true)
            {
                show_seat();
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                #region
                dictionary.Add("박주혜", "라현님이랑 같은 동네 산다");
                dictionary.Add("성민경", "앞자리라 얼굴이 안보인다");
                dictionary.Add("박상연", "회식때 내 이름 모르셨다");
                dictionary.Add("제현준", "mbti I, new질문에 대답은 거의 이분이 다 하신다");
                dictionary.Add("양경훈", "정말 초면이다 안녕하세요");
                dictionary.Add("김현희", "옆자리분이랑 친하시다, 전공자언니");
                dictionary.Add("최영일", "교수님한테 맞는거 좋아한다고 찍혔다");
                dictionary.Add("강윤석", "코딩테스트는 요즘 안하시고 쉬는시간에 모바일게임 하신다 우마무스메?");
                dictionary.Add("김대현", "손가락 다치셨다");
                dictionary.Add("이도엽", "교수님 질문에 대답을 막힘없이 다하신다, 앨빈과 슈퍼밴드 재질");
                dictionary.Add("노소영", "필기 중독 언니, 스물네살!");
                dictionary.Add("국동근", "안녕하세요");
                dictionary.Add("이수민", "전공자 유배지");
                dictionary.Add("이상훈", "발표하신분 게임 만들어보셨다는 근데 기둥때문에 맞는지 안보여서 확인불가");
                dictionary.Add("허진", "민초파 반장동생님");
                dictionary.Add("주성현", "술을 맛없어하신다");
                dictionary.Add("정수민", "귀걸이? 피어싱?하신거 밖에 아는게");
                dictionary.Add("이성준", "스무살분 술 드시면 얼굴이 빨개지신다");
                dictionary.Add("목지아", "부반장님 머리스타일이 귀엽다");
                dictionary.Add("경민아", "주말에 드라이브 가고 싶어하신다");
                dictionary.Add("고석환", "책");
                dictionary.Add("김윤혜", "외로워보이지만 외롭지않다");
                dictionary.Add("강단이", "나다");
                dictionary.Add("이유리", "안구건조증이지만 울지않는다");
                dictionary.Add("박라현", "허리가 안좋다,,,나랑 동문");
                dictionary.Add("구윤성", "노트북으로 수업들으신다");
                dictionary.Add("임종서", "자차소유");
                dictionary.Add("김민수", "회식때 뭔가 강렬한 인상");
                dictionary.Add("공병현", "학사 총무님");
                dictionary.Add("고동원", "교수님 안녕하세요");


                #endregion
                string input = Console.ReadLine();
                bool exist = dictionary.ContainsKey(input);
                if (exist)
                {
                    Console.Write("{0}: ", input);
                    Console.WriteLine(dictionary[input]);
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("해당 이름은 존재하지 않습니다.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }
        }
    }
}
