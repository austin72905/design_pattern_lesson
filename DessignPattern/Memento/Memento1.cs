using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Memento
{
    class Memento1
    {
        public static void Run()
        {
            Originator originator = new Originator();
            Caretaker caretaker = new Caretaker();
            originator.State = "狀態1 攻擊力100";
            //保存當前狀態
            caretaker.Add(originator.SaveStateMemento());

            originator.State = "狀態2 攻擊力80";

            //保存當前狀態
            caretaker.Add(originator.SaveStateMemento());

            originator.State = "狀態3 攻擊力50";

            //保存當前狀態
            caretaker.Add(originator.SaveStateMemento());

            //希望恢復到狀態1
            Console.WriteLine($"當前 {originator.State}");
            originator.GetStateFromMemento(caretaker.Get(0));
            Console.WriteLine($"當前 {originator.State}");
        }
        /*
            備忘錄模式
            1. 在不破壞封裝性的前提下，捕獲一個對象的內部狀態，
                並在外部保存這個狀態，這樣之後就可以將對像回復到原本保存的狀態
            
            
            角色與職責
            1. Originator : 原始對象
            2. Memento : 保存原始狀態的對象
            3. Caretaker  :  守護者對像，管理 Memento，會以集合管理Memento
            4. 如果希望保存多個對象的狀態，可以用diction    
            


            細節:
            1. 信息的封裝，用戶不勇關心狀態的保存系節
            2. 如果類的成員便量過多，會占用較大的資源，且每一次保存都會消耗一定的內存
            3. 應用 ctrl+z 、 打遊戲存檔
            4. 可以跟原型模式配合，節省內存

            需求:
            遊戲玩家 在打 boss 前 保存自身狀態(攻擊力、防禦力)
            打完boss 後，攻擊力和防禦力下降
            回復到大戰前的狀態

            傳統: 用一個對象保存狀態，缺點是如果有很多玩家角色，要創建很多類，開銷大

            
         
        */

        public class Originator
        {
            //看需要備忘的狀態有哪些
            public string State { get; set; }

            // 返回一個Memento
            public Memento SaveStateMemento()
            {
                return new Memento(State);
            }

            //通過備忘錄對像，還原程原本的狀態
            public void GetStateFromMemento(Memento memento)
            {
                State = memento.State;
            }

        }

        public class Memento
        {
            public string State { get;  }
            public Memento(string state)
            {
                State = state;
            }
        }


        public class Caretaker
        {
            //管理備忘錄對像
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
