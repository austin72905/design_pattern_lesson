using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Factory
{
    class AbsFactory1
    {

        public static void Run()
        {
            //新開一間店
            new PizzaStore();
        }

        /*
        抽象工廠模式
        
        1.定義一個interface 抽象工廠，讓子類工廠去實作
        2. 可視為簡單工廠跟工廠方法的整合
        3. 類於代碼維護與擴展
        */

        public interface IPizzaFactory
        {
            public Pizza CreatPizza(string orderType);
        }

        public class BJFactory : IPizzaFactory 
        {
            public Pizza CreatPizza(string orderType)
            {
                Pizza pizza = null;
                if (orderType.Equals("cheese"))
                {
                    pizza = new BJCheesePizza();
                }
                else if (orderType.Equals("pepper"))
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

        public class LDFactory : IPizzaFactory
        {
            public Pizza CreatPizza(string orderType)
            {
                Pizza pizza = null;
                if (orderType.Equals("cheese"))
                {
                    pizza = new LDCheesePizza();
                }
                else if (orderType.Equals("pepper"))
                {
                    pizza = new LDPepperPizza();
                }
                else
                {
                    pizza = new BJCheesePizza();
                }

                return pizza;
            }
        }

        public class BJCheesePizza : Pizza
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

        


        public class OrderPizza
        {
            public IPizzaFactory _pizzaFactory;

            public OrderPizza(IPizzaFactory pizzaFactory)
            {
                setFactory(pizzaFactory);
            }
            private void setFactory(IPizzaFactory pizzaFactory)
            {
                Pizza pizza = null;
                string orderType;
                _pizzaFactory = pizzaFactory;
                while (true)
                {
                    orderType = GetPizzaType();
                    //可能是北京，也可能是工廠
                    pizza = _pizzaFactory.CreatPizza(orderType);
                    if (pizza != null)
                    {
                        //輸出製作過程
                        pizza.Prepare();
                        pizza.Bake();
                        pizza.Cut();
                        pizza.Box();
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

        public class PizzaStore
        {
            public PizzaStore()
            {
                //新增一個服務線
                new OrderPizza(new BJFactory());
            }
        }
    }
}
