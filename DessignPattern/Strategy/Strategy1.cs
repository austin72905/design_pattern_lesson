using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Strategy
{
    class Strategy1
    {

        /*
        策略模式

        1. 將變化的代碼從不變的代碼中分離出來
        2. 針對接口編程而不是具體類(定義策略接口)
        3. 多用組合/聚合，少用繼承
        4. 可以把使用者跟提供者解耦


        細節:
        1. 多用組合/聚合，少用繼承; 用行為類組合，而不是繼承
        2. 體現對修改關閉，對擴展開放原則，只要增加一種策略即可
            避免使用if..else
        3. 提供更換繼承關係的方法(setter)，策略模式將方法封裝再獨立的strategy，可以獨立於
            context 改變他，易於切換

        缺點: 每增加一個策略，就要增加一個類，策略過多會導致類數目龐大
        
        需求:
        有各類鴨子(野鴨、北京鴨、水鴨)，而鴨子有各種行為(叫、飛行、游泳)，打印鴨子的訊息


        */

        //傳統
        //建一個抽象父類Duck，各類鴨子再繼承此父類
        /*
        缺點:
        1. 都繼承了Duck 類，所以Fly讓所有子類都會飛了這是不正確的
        2. (1)的問題就是繼承帶來的問題，對類的局部變動，尤其是對父類的局部改動，會影響其他部分
        3. 可以透過override來改寫
        4. ToyDuck 會需要複寫所有父類的方法

        => 使用策略模式解決
        */
        public abstract class Duck
        {
            public Duck()
            {

            }
            //顯示鴨子的訊息
            public abstract void DisPlay();

            public virtual void Bark()
            {
                Console.WriteLine("鴨子叫");
            }

            public virtual void Fly()
            {
                Console.WriteLine("鴨子飛");
            }

            public virtual void Swim()
            {
                Console.WriteLine("鴨子游泳");
            }
        }

        public class WildDuck : Duck
        {
            public override void DisPlay()
            {
                Console.WriteLine("這是野鴨");
            }
        }

        public class BJDuck : Duck
        {
            public override void DisPlay()
            {
                Console.WriteLine("這是北京鴨");
            }

            //因為北京鴨不會飛要重寫Fly
            public override void Fly()
            {
                Console.WriteLine("北京鴨不會飛");
            }
        }

        public class ToyDuck : Duck
        {
            public override void DisPlay()
            {
                Console.WriteLine("這是玩具鴨");
            }

            //玩具鴨不會飛、不會游泳、不會叫
            //需要重寫父類所有的方法(很麻煩)
            public override void Bark()
            {
                Console.WriteLine("玩具鴨不會叫");
            }

            public override void Fly()
            {
                Console.WriteLine("玩具鴨不會飛");
            }

            public override void Swim()
            {
                Console.WriteLine("玩具鴨不會游泳");
            }
        }
    }
}
