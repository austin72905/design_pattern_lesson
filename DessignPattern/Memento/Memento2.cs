using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Memento
{
    class Memento2
    {
        public static void Run()
        {
            GameRole gameRole = new GameRole(1100,100);

            Caretaker caretaker = new Caretaker();
            caretaker.Add(gameRole.CreateMemento());

            Console.WriteLine("大戰前狀態");
            gameRole.Display();

            Console.WriteLine("大戰後狀態");
            gameRole.Attack = 80;
            gameRole.Defense = 80;
            gameRole.Display();

            Console.WriteLine("大戰後狀態回復");

            gameRole.RecoverState(caretaker.Get(0));
            gameRole.Display();

        } 
        /*
            遊戲角色 
        */

        public class GameRole
        {
            public int Attack { get; set; }
            public int Defense { get; set; }

            public GameRole(int attack, int defense)
            {
                Attack = attack;
                Defense = defense;
            }

            public Memento CreateMemento()
            {
                return new Memento(Attack, Defense);
            }

            //從備忘錄對像回復原本狀態
            public void RecoverState(Memento memento)
            {
                Attack = memento.Attack;
                Defense = memento.Defense;
            }

            public void Display()
            {
                Console.WriteLine($"角色當前攻擊力  {Attack}、 防禦力  {Defense}");
            }
        }

        public class Memento
        {
            public int Attack { get; }
            public int Defense { get; }

            public Memento(int attack,int defense)
            {
                Attack=attack;
                Defense = defense;
            }
        }

        public class Caretaker
        {
            //如果只是前一個狀態也可以不用集合
            private List<Memento> mementos = new List<Memento>();

            public void Add(Memento memento)
            {
                mementos.Add(memento);
            }

            public Memento Get(int index)
            {
                return mementos[index];
            }
        }
    }
}
