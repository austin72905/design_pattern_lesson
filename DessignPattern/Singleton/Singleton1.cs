using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Singleton
{
    class Singleton1
    {
        /*
        單例模式
        整個系統中，某個類只能存在一個對象實例，
        並且該類只提供一個取得該項實例的方法(靜態方法)

        寫法:
        1. 餓漢式 (靜態常數)
        2. 餓漢式 (靜態代碼塊)
        ----------------------------------------------------懶漢都不推使用
        3. 懶漢式 (線程不安全)
        4. 懶漢式 (線程安全，同步方法) C# 沒有synchonized
        5. 懶漢式 (線程安全，同步代碼塊) 不能這樣用
        ----------------------------------------------------
        6. 雙重檢查
        7. 靜態內部類
        8. 枚舉

        

        餓漢式:(靜態常數)
        1. 構造器private (防止new)
        2. 暴露一個靜態的功用方法
        3. 類的內部創建對象

        優點: 在類裝載的時候就完成實例化，避免線程同步問題
        缺點: 可能都沒有用到過這個實例，會造成內存浪費

        可用，一般來說很少會沒用到該實例

        */
        public static void Run()
        {
            //兩個獲得的是相同實例
            Singleton s =Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();
            Console.WriteLine(s == s2);
        }

        class Singleton
        {
            //構造器private (防止外部new)
            private Singleton()
            {

            }
            //類內部創建對象
            private static Singleton Instance = new Singleton();
            //暴露一個靜態的功用方法
            public static Singleton GetInstance()
            {
                return Instance;
            }
        }
    }
}
