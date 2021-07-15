using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.LisKov
{
    class LisKov1
    {
        /*
        里式替換原則
        OOP 中繼承性的思考
        1. 繼承: 父類中凡是實現好的方法，其實也是種定義規範，雖然不強制要求子類遵循，
            但如果子類對實現的方法任意修改，就會對整個繼承體系造成破壞
  
        2. 繼承的弊端: 會對程序造成侵入性，可移植性下降，增加對象的耦合姓，
            如果修改一個類，被需考慮他他所有的子類，所有涉及的子類都可能故障
   
        3. 繼承時要儘量遵守里式替換原則

        里式替換原則
        1. 所有引用父類的地方都能夠透明的使用其子類 引用A類 跟引用B類(A的子類) 程序的行為不會發生變化
        2. 子類儘量不要重寫父類方法  (如果一個子類全部重寫了父類，那幹嘛要繼承?)
        3. 適當的情況下，可以通過聚合、組合、依賴來解決問題


        解決方法:
        創建一個更基礎的類，將原有繼承關係去掉
        */

        public static void Run()
        {
            A a=new A();
            Console.WriteLine("5+3 ="+ a.Plus(5, 3));
            AChild aChild = new AChild();
            Console.WriteLine("5+3 =" + aChild.Plus(5, 3));
            Console.WriteLine("5+3+1 =" + aChild.Plus1(5, 3));
        }


        class A
        {
            public int Plus(int a,int b)
            {
                return a + b;
            }
        }
            
        //繼承了A
        class AChild:A
        {
            //無意間不小心改成了-
            //本意是求a + b
            //但其實C# 會提醒你
            public int Plus(int a, int b)
            {
                return a - b;
            }

            public int Plus1(int a, int b)
            {
                return Plus(a,b)+1;
            }
        }

    }
}
