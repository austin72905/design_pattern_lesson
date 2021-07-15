using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Visitor
{
    class Visitor1
    {
        public static void Run()
        {
            //109 4:40看下
            //110 3:46複習
            //創建數據結構
            ObjectStructure objectStructure = new ObjectStructure();
            objectStructure.Attach(new Man());
            objectStructure.Attach(new Woman());
            objectStructure.Attach(new Man());

            //成功
            Success success = new Success();
            objectStructure.Display(success);

            //wait 的評分 (只需要新增完wait類，其他代碼完全不用改掉)
            Wait wait = new Wait();
            objectStructure.Display(wait);
        }
        /*
        訪問者模式

        需求
        觀眾對歌手評分
        觀眾類型 Man、Woman
        評分標準 Success 、 Fail
        (優點:新增評分類型時，較靈活)

        傳統寫法
        Man、Woman : Person
        用 if else 判斷， 如果覺得成功給予成功評價; 反之給失敗
        缺點:
        如果要新增一個評價wait， Man、Woman 裡都要做修改
        如果要在新增一個觀眾類型 Child， 代碼又要複製一份
        => 擴展性不佳，不利維護


        定義
        1. 訪問者模式: 封裝了作用於某種數據結構的各元素操作，可以在不改變數據結構的前提下，
                      定義作用於這些元素的新操作

        2. 將數據結構與數據操作分離，解決 "數據結構"、"操作"耦合性的問題

        3. 在被訪問的類加一個對外接待訪問者的接口Accept

        4. 主要應用場景: 一個對象結構有很多不同的操作，需要避免這些操作，汙染這些對象的類，
                        可以使用訪問者模式


        雙分派

        不管類怎麼變化，都能找到期望的方式運行，意味著得到執行的操作
        取決於"請求的種類"和兩個"接收者的類型"
        //1. (第一次分派)Action 傳給了man
        //2. (第二次分派) 調用做為參數的"具體方法"GetManResult，同時將自己(this)作為參數傳入

        //=> 可以達到解耦
        ex 
        評分標準 新增個wait


        細節
        優點
        1. 適合數據結構相對穩定的系統 (可做報表、UI、攔截器與過濾器)
        2. 符合單一職責原則，有優秀的擴展性，靈活度高

        缺點
        1. 是迪米特法則不建議的，因為關注了其他類的內部細節，造成具體元素變更比較困難
        2. 違反了依賴倒轉原則，依賴的是具體元素，而不是抽象元素
        3. 如果系統有較穩定的數據結構，又有經常變化的功能需求，訪問者模式就是比較合適的
         
        */

        public abstract class Action
        {
            //得到男性觀眾的評價
            public abstract void GetManResult(Man man);
            //得到女性觀眾的評價
            public abstract void GetWomanResult(Woman woman);
        }
        //評分標準 Success
        public class Success : Action
        {
            public override void GetManResult(Man man)
            {
                Console.WriteLine("man give success evaluate to singer");
            }

            public override void GetWomanResult(Woman woman)
            {
                Console.WriteLine("woman give success evaluate to singer");
            }
        }
        //評分標準 fail
        public class Fail : Action
        {
            public override void GetManResult(Man man)
            {
                Console.WriteLine("man give fail evaluate to singer");
            }

            public override void GetWomanResult(Woman woman)
            {
                Console.WriteLine("woman give fail evaluate to singer");
            }
        }

        //新增wait 評分標準時
        public class Wait: Action
        {
            public override void GetManResult(Man man)
            {
                Console.WriteLine("man give stay evaluate to singer");
            }

            public override void GetWomanResult(Woman woman)
            {
                Console.WriteLine("woman give stay evaluate to singer");
            }
        }

        public abstract class Person
        {
            //提供個方法讓訪問者可以訪問
            public abstract void Accept(Action action);
        }

        //這兩使用了雙分派，客戶端將具體狀態作為參數傳遞
        //1. (第一次分派)Action 傳給了man
        //2. (第二次分派) 調用做為參數的"具體方法"GetManResult，同時將自己(this)作為參數傳入

        //=> 可以達到解耦
        public class Man : Person
        {
            public override void Accept(Action action)
            {
                action.GetManResult(this);
            }
        }

        public class Woman : Person
        {
            public override void Accept(Action action)
            {
                action.GetWomanResult(this);
            }
        }

        //數據結構，管理評分情況
        public class ObjectStructure
        {
            //維護了一個集合
            private List<Person> people = new List<Person>();

            //增加到List
            public void Attach(Person p)
            {
                people.Add(p);
            }

            //移除
            public void Detach(Person p)
            {
                people.Remove(p);
            }

            //顯示評分情況
            public void Display(Action action)
            {
                foreach(var p in people)
                {
                    p.Accept(action);
                }
            }

        }
    }
}
