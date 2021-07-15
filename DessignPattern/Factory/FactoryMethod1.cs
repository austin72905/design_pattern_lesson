using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Factory
{
    class FactoryMethod1
    {
        public static void Run()
        {
            //新開一間店
            new PizzaStore();
        }

        /*
        工廠方法模式
        pizza 可以點不同的地區ex: 北京的cheese pizza、倫敦的cheese pizza

        方案1
        可創建不同的簡單工廠，但是考慮到可維護姓跟可擴展性，不是特別好(工廠類會變很多)

        方案2
        工廠方法模式

        將時例化功能，抽象出來，在不同口味的子類中實現出來
         
        */
        public abstract class OrderPizza
        {
            //構造器
            public OrderPizza()
            {
                Pizza pizza=null;
                string orderType;
                while (true)
                {
                    orderType = GetPizzaType();
                    //創建pizza 由子類實現
                    pizza = CreatePizza(orderType);
                    //輸出製作過程
                    pizza.Prepare();
                    pizza.Bake();
                    pizza.Cut();
                    pizza.Box();
                }
                
            }
            //定義一個抽象方法，創建pizza 由子類實現
            public abstract Pizza CreatePizza(string orderType);

            //獲取用戶輸入的pizza種類
            private string GetPizzaType()
            {
                Console.WriteLine("input pizza type:");
                string input = Console.ReadLine();
                return input;

            }
        }
        

        public class BJOrderPizza: OrderPizza
        {
            public override Pizza CreatePizza(string orderType)
            {
                Pizza pizza = null;
                if (orderType.Equals("cheese"))
                {
                    pizza = new BJCheesePizza();
                }else if (orderType.Equals("pepper"))
                {
                    pizza = new BJPepperPizza();
                }
                else
                {
                    pizza = new BJCheesePizza();
                }

                return pizza;
            }
        }
        

        public abstract class Pizza
        {
            protected string name;

            //不同的pizza 預備的原料不同
            public abstract void Prepare();

            public void Bake()
            {
                Console.WriteLine(name + "...Bake");
            }

            public void Cut()
            {
                Console.WriteLine(name + "...Cut");
            }

            public void Box()
            {
                Console.WriteLine(name + "...Box");
            }

            public void setName(string name)
            {
                this.name = name;
            }

        }
        public class BJCheesePizza:Pizza
        {
            public override void Prepare()
            {
                setName("北京cheess");
                Console.WriteLine("北京cheess 準備原料");
            }
        }

        public class BJPepperPizza : Pizza
        {
            public override void Prepare()
            {
                setName("北經pepper");
                Console.WriteLine("北京pepper 準備原料");
            }
        }

        public class LDPepperPizza : Pizza
        {
            public override void Prepare()
            {
                setName("倫敦cheess");
                Console.WriteLine("倫敦cheess 準備原料");
            }
        }

        public class LDCheesePizza : Pizza
        {
            public override void Prepare()
            {
                setName("倫敦pepper");
                Console.WriteLine("倫敦pepper 準備原料");
            }
        }

        public class PizzaStore
        {
            public PizzaStore()
            {
                //新增一個服務線
                new BJOrderPizza();
            }
        }
    }
}
