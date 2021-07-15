using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Singleton
{
    class Singleton2
    {
        /*
        餓漢式 (靜態代碼塊)

        跟靜態變量的優缺點是一樣的
        */

        class Singleton
        {
            
            //構造器private (防止外部new)
            private Singleton()
            {
                
            }

            //類內部創建對象
            private static Singleton Instance;

            //靜態代碼塊
            static Singleton(){
                Instance = new Singleton();
            }

            //暴露一個靜態的功用方法
            public static Singleton GetInstance()
            {
                return Instance;
            }
        }
    }
}
