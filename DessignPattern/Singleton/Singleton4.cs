using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Singleton
{
    class Singleton4
    {
        /*
        懶漢式 (線程安全，同步方法) C# 無法
        懶漢式 (線程安全，同步代碼塊) 開發時絕對不要用
        優點: 線程安全
        缺點: 效率太低

        不推薦

        下面提供錯誤寫法
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

            private static readonly object lockObj = new object();

            //構造器private (防止外部new)
            private Singleton()
            {

            }

            //當使用到該方法時才去創建
            public static  Singleton GetInstance()
            {
                if (Instance == null)
                {
                    //不能這樣寫，因為只要進到Instance == null 之後所完下一個還是會新增一個實例
                    lock (lockObj)
                    {
                        Instance = new Singleton();
                    }
                    
                }
                return Instance;
            }
        }
    }
}
