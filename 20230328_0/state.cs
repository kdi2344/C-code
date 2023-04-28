using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230328_0
{
    public enum state
    {
        Happy, 
        Angry,
        Sad
    }
    public interface Istate
    {
        void Action();
    }

    public class Happy : Istate
    {
        //상태에 클래스를 만들어 상태를 객체화시킴
        //상태 패턴은 상태를 객체화함으로 상태가 행동을 할 수 있도록 위임하는 패턴
        string name;
        public Happy(string name)
        {
            this.name = name;
        }

        public void Action()
        {
            Console.WriteLine($"{name}은 행복");
        }
    }
    public class Angry : Istate
    {
        string name;
        public Angry(string name)
        {
            this.name = name;
        }

        public void Action()
        {
            Console.WriteLine($"{name}은 분노");
        }
    }
    public class Sad : Istate
    {
        string name;
        public Sad(string name)
        {
            this.name = name;
        }

        public void Action()
        {
            Console.WriteLine($"{name}은 슬픔");
        }
    }

    public class Human
    {
        public string name;
        public Dictionary<state, Istate> State_dictionary;
        public Human(string name)
        {
            this.name = name;
            State_dictionary = new Dictionary<state, Istate>();
            State_dictionary.Add(state.Happy, new Happy(name));
            State_dictionary.Add(state.Angry, new Angry(name));
            State_dictionary.Add(state.Sad, new Sad(name));

        }
    }
}
