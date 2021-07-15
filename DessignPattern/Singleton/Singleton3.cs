using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Singleton
{
    class Singleton3
    {
        /*
        懶漢式 (線程不安全) 
        當使用到該方法時才去創建

        優點: 達到懶加載(用到才去創建)
        缺點: 在多線程下可能會變成多個實例

        最好不要用
        */
        public static void Run()
        {
            //兩個獲得的是相同實例
            Singleton s = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();
            Console.WriteLine(s == s2);
        }

        class Singleton
        {
            //類內部創建對象
            private static Singleton Instance;

            //構造器private (防止外部new)
            private Singleton()
            {

            }

            //當使用到該方法時才去創建
            public static Singleton GetInstance()
            {
                if (Instance == null)
                {
                    Instance = new Singleton();
                }
                return Instance;
            }
        }
    }
}
