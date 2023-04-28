using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230328_0
{
    class singleton
    {
        //싱글톤의 기본 형태
        private static singleton _instance = null;
        public static singleton Instance //본인 자체를 객체화 
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new singleton();
                }
                return _instance;
            }
        }
        public int a = 5;
        //private int b = 6;
         //다른 클래스에서 접근 불가
        public singleton()
        {
            Console.WriteLine("지금 생성");
        }
        public void singleton_call()
        {
            Console.WriteLine("singleton_call()");
        }
        public int get_int()
        {
            return a;
        }
    }
}
