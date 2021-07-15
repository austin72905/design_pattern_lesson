using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Factory
{
    class SimpleFactory2
    {
        public static void Run()
        {
            //新開一間店
            new PizzaStore();
        }

        /*
        簡單工廠模式 (靜態工廠模式)
        
        1. 創建型模式，由一個工廠對象絕對創建出哪種產品類的時例
        2. 定義一個創建對象的類，由這個類來封裝實體畫對象的行為
        3. 會用到大量創建某類、對象，就會使用到工廠模式
         
        */

        public class OrderPizza
        {
            Pizza pizza;
            //CreatPizza 寫成靜態的畫這也可以省略，直接調用即可 SimpleFactory.CreatPizza
            //看需求如果創建pizza的方式只有一種可以用靜態的
            SimpleFactory _simpleFactory;

            //構造器
            public OrderPizza(SimpleFactory simpleFactory)
            {
                setFactory(simpleFactory);
            }
            public void setFactory(SimpleFactory simpleFactory)
            {
                string orderType;
                this._simpleFactory = simpleFactory;

                while (true)
                {
                    orderType = GetPizzaType();
                    pizza = _simpleFactory.CreatPizza(orderType);

                    if (pizza != null)
                    {
                        //輸出製作過程
                        pizza.Prepare();
                        pizza.Bake();
                        pizza.Cut();
                        pizza.Box();
                    }
                    else
                    {
                        Console.WriteLine("訂購失敗");
                        break;
                    }
                }
            }

            //獲取用戶輸入的pizza種類
            private string GetPizzaType()
            {
                Console.WriteLine("input pizza type:");
                string input = Console.ReadLine();
                return input;

            }
        }

        //創建一個專門建立pizza的工廠
        public class SimpleFactory
        {
            //也可以寫成靜態的
            public Pizza CreatPizza(string orderType)
            {
                Pizza pizza;

                if (orderType.Equals("greek"))
                {
                    pizza = new GreekPizza();
                    pizza.setName(orderType);
                }
                else if (orderType.Equals("cheese"))
                {
                    pizza = new CheesePizza();
                    pizza.setName(orderType);
                }
                else if(orderType.Equals("pepper"))
                {
                    pizza = new PepperPizza();
                    pizza.setName(orderType);
                }
                else
                {
                    //亂點就送你cheesePizza
                    pizza = new CheesePizza();
                    pizza.setName(orderType);
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

        public class CheesePizza : Pizza
        {
            public override void Prepare()
            {
                Console.WriteLine("給CheesePizza準備材料...");
            }
        }

        public class GreekPizza : Pizza
        {
            public override void Prepare()
            {
                Console.WriteLine("給GreekPizza準備材料...");
            }
        }

        public class PepperPizza : Pizza
        {
            public override void Prepare()
            {
                Console.WriteLine("給PepperPizza準備材料...");
            }
        }

        public class PizzaStore
        {
            public PizzaStore()
            {
                //新增一個服務線
                new OrderPizza(new SimpleFactory());
            }
        }
    }
}
