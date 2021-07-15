using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Decorator
{
    class Decorator1
    {
        public static void Run()
        {
            new CoffeStore();
        }
        /*
        裝飾者模式
        
        1. 動態將新功能副加到對像上，擴展功能方面彼既成更有彈性

        原理: 就像是把包一個快遞

        1. 有個主體的外型(Component): 要打包的衣服、物品
        2. 包裝(Decorator): 泡棉、紙板
        3. 具體的主體(ConcreteComponent): 一本讀懂人類圖(具體的書)
        

        用配料包住單品咖啡
        之後新增了總類，只要繼承Coffee，就可以加配料了


        需求:
        星巴克咖啡
        種類: Espresso、ShortBlack、LongBlack(美式)、Decaf(無咖啡因)
        配料: Milk、Soy、Chocolate

        要計算不同種類的咖啡費用(用戶 可能沒加調料，可能加很多份)
         
        */

        public abstract class Drink
        {
            public string Description;
            private decimal Price = 0.0M;

            //計算費用的方法，會被子類來實現
            public abstract decimal Cost();

            //取屬性的方法
            public virtual string GetDescription()
            {
                return Description;
            }

            public void SetDescription(string des)
            {
                this.Description = des;
            }

            public decimal GetPrice()
            {
                return Price;
            }

            public void SetPrice(decimal price)
            {
                this.Price = price;
            }

            
        }

        public class Coffee : Drink
        {
            public override decimal Cost()
            {
                //獲取單品咖啡價格
                return base.GetPrice();
            }
        }

        //單品咖啡
        public class Espresso: Coffee
        {
            public Espresso()
            {
                base.SetDescription("義大利咖啡");
                base.SetPrice(35M);
            }
        }

        public class Decaf : Coffee
        {
            public Decaf()
            {
                base.SetDescription("無咖啡因咖啡");
                base.SetPrice(25M);
            }
        }

        public class LongBlack : Coffee
        {
            public LongBlack()
            {
                base.SetDescription("美式咖啡");
                base.SetPrice(30M);
            }
        }

        //這個最重要 (聚合+繼承)Drink
        //聚合: 可以把單品咖啡丟進來，就可以獲取當下自己配料的價格 跟 單品咖啡的價格
        //        例於統計
        public class Decorator : Drink
        {
            private Drink _coffee;

            public Decorator(Drink coffee)
            {
                this._coffee = coffee;
            }
            public override decimal Cost()
            {
                //拿到自己配料的價格
                //加上單品咖啡的價格
                //Console.WriteLine("Decorator 拿的價格"+ base.GetPrice());
                return base.GetPrice()+ _coffee.Cost();
            }

            public override string GetDescription()
            {
                //_coffee.GetDescription 輸出被裝飾者的訊息
                return $"{base.Description} {base.GetPrice()}元  &&  {_coffee.GetDescription()}"; 
            }
            
        }

        //具體調味品
        public class Chocolate : Decorator
        {
            //繼承的父類建構子c# 是寫在外面
            public Chocolate(Drink coffee) : base(coffee)
            {
                base.SetDescription("巧克力");
                base.SetPrice(15M);
            }
        }

        public class Milk : Decorator
        {
            //繼承的父類建構子c# 是寫在外面
            public Milk(Drink coffee) : base(coffee)
            {
                base.SetDescription("牛奶");
                base.SetPrice(10M);
            }
        }

        public class Soy : Decorator
        {
            //繼承的父類建構子c# 是寫在外面
            public Soy(Drink coffee) : base(coffee)
            {
                base.SetDescription("豆漿");
                base.SetPrice(10M);
            }
        }


        //Client
        public class CoffeStore
        {
            public CoffeStore()
            {
                //點了一杯美式咖啡
                Drink order = new LongBlack();
                Console.WriteLine($"訂單內容: {order.GetDescription()}");
                Console.WriteLine($"此時統計的是單品的價格: {order.Cost()}");

                // 加入一杯牛奶
                order = new Milk(order);
                Console.WriteLine($"訂單內容: {order.GetDescription()}");
                Console.WriteLine($"此時統計的價格: {order.Cost()}");

                // 又加入一杯牛奶
                order = new Chocolate(order);
                Console.WriteLine($"訂單內容: {order.GetDescription()}");
                Console.WriteLine($"此時統計的價格: {order.Cost()}");

                // 又加入一杯巧克力
                order = new Chocolate(order);
                Console.WriteLine($"訂單內容: {order.GetDescription()}");
                Console.WriteLine($"此時統計的價格: {order.Cost()}");
            }
        }


    }
}
