using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Singleton
{
    class Singleton5
    {
        /*
        雙重檢查
        解決線程安全、又達到懶加載功能
        同時保證了效率

        推薦使用
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
            //一旦這個變數被修改，會同步到所有執行序
            //一個變數經volatile修飾後在所有執行緒中必須是同步的;任何執行緒中改變了它的值,所有其他執行緒立即獲取到了相同的值
            private static volatile Singleton Instance;

            private static readonly object lockObj = new object();
            //構造器private (防止外部new)
            private Singleton()
            {

            }

            //當使用到該方法時才去創建
            public static Singleton GetInstance()
            {
                if (Instance == null)
                {
                    //雙重檢查
                    lock (lockObj)
                    {
                        if(Instance == null)
                        {
                            Instance = new Singleton();
                        }
                        
                    }

                }
                return Instance;
            }
        }
    }
}
