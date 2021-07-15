using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.LisKov
{
    class LisKov2
    {
        public static void Run()
        {
            A a = new A();
            Console.WriteLine("5+3 =" + a.Plus(5, 3));
            AChild aChild = new AChild();
            Console.WriteLine("5+3 =" + aChild.Plus(5, 3));
            Console.WriteLine("5+3+1 =" + aChild.Plus1(5, 3));
        }
        /*
            解決方法:
            創建一個更基礎的類 ，將原有繼承關係去掉
        */
        class Base
        {

        }

        class A: Base
        {
            public int Plus(int a, int b)
            {
                return a + b;
            }
        }

        
        class AChild : Base
        {   
            //如果還是想用A的方法，可以用組合的方式
            private A ai = new A();
            public int Miner(int a, int b)
            {
                return a - b;
            }

            public int Plus1(int a, int b)
            {
                return Plus(a, b) + 1;
            }

            public int Plus(int a, int b)
            {
                return ai.Plus(a, b);
            }
        }
    }
}
