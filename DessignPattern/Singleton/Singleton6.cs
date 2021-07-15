using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Singleton
{
    class Singleton6
    {
        /*
        靜態內部類
        外部的類被加載時，靜態內部類不會被加載
        達到懶加載的效果，同時加載的過程是線程安全
        推薦
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
     
            //構造器private (防止外部new)
            private Singleton()
            {

            }

            //靜態內部類
            private static class SingletonInstance
            {
                public static readonly Singleton Instance = new Singleton();
            }

            //當使用到該方法時才去創建
            public static Singleton GetInstance()
            {
                return SingletonInstance.Instance;
            }
        }
    }
}
