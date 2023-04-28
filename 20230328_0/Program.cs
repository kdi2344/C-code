using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230328_0
{
    class test
    {
        public test()
        {
            Console.WriteLine("test");
        }
        public void Call()
        {
            Console.WriteLine("일반클래스");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            test testing = new test();
            testing.Call();
            //singleton singleton = new singleton(); 이미 해놔서 아래처럼 하면 됨
            singleton.Instance.singleton_call();

            Console.WriteLine(singleton.Instance.get_int());
            Console.WriteLine(singleton.Instance.a);

            Human person = new Human("이름");
            Console.WriteLine($"{person.name}");
            person.State_dictionary[state.Happy].Action();
            person.State_dictionary[state.Angry].Action();
            person.State_dictionary[state.Sad].Action();
        }
    }
}
