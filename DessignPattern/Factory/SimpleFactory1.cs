using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Factory
{
    class SimpleFactory1
    {
        public static void Run()
        {
            //新開一間店
            new PizzaStore();
        }

        /*
        簡單工廠模式
        
        需求:
        有一個pizza項目
        1. pizza 總類很多(cheese、greek)
        2. 製作過程很多(prepare、bake、cut、box)
        3. 完成pizza店訂購功能
         
        */


        //方式1
        //傳統寫法
        //建一個abstact class Pizza => 有 (prepare、bake、cut、box)
        //讓各自種類cheese、greek pizza 去實作
        //有個OrderPizza 完成訂購pizza 功能
        //有個PizzaStore 讓客戶點Pizza

        /*
        傳統寫法
        優點: 好理解
        缺點 違反OCP原則 (對外擴展、對修改關閉)，當給類新增功能，使用方(OrderPizza)儘量不用修改代碼
        ex : 新增一個種類pizza， while 迴圈要改很多、
        ex : 如果想增加使用方 (OrderPizza)數量 OrderPizza2、OrderPizza3...，每個有用到pizaa 總類的地方都要改(while 迴圈)
         
        改進方法:
        分析: 傳統寫法只要創建pizza 的代碼都要修改，這個代碼往往有很多地方
        思路: 把創建pizza 封裝到一個類中，之後只要修改這個類就好 => 簡單工廠模式
        */
        public abstract class Pizza
        {
            protected string name;

            //不同的pizza 預備的原料不同
            public abstract void Prepare();

            public void Bake()
            {
                Console.WriteLine(name+ "...Bake");
            }

            public void Cut()
            {
                Console.WriteLine(name+ "...Cut");
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

        public class OrderPizza
        {
            public OrderPizza()
            {
                Pizza pizza = null;
                string orderType;
                while (true)
                {
                    orderType = GetPizzaType();
                    if (orderType.Equals("greek"))
                    {
                        pizza = new GreekPizza();
                        pizza.setName(orderType);
                    }else if (orderType.Equals("cheese"))
                    {
                        pizza = new CheesePizza();
                        pizza.setName(orderType);
                    }
                    else
                    {
                        break;
                    }

                    //輸出製作過程
                    pizza.Prepare();
                    pizza.Bake();
                    pizza.Cut();
                    pizza.Box();
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

        public class PizzaStore
        {
            public PizzaStore()
            {
                //新增一個服務線
                new OrderPizza();
            }
        }

    }
}
