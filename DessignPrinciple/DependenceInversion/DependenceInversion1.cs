using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DependenceInversion
{
    public class DependenceInversion1
    {
        
        /*
        依賴反轉
         
        1.高層模塊 不應該依賴低能模塊，兩者都應該依賴抽象
        2.抽象不要依賴細節，細節應該依賴抽象
        3. 面向接口編程
        4. JAVA中，抽象指的是抽象類，細節是實現類
        5. 使用抽象類目的是制定好規範，不涉及具體的操作

        細節
        1. 低層模塊儘量都有抽象，程序穩定性更好
        2. 變量的聲明類型儘量是抽象，這樣變量引用和實際對象間，
           就存在一個緩衝層，利於程序擴展和優化
        3. 繼承時遵循里式替換原則
        
        */

        public static void Run()
        {
            Person person = new Person();
            person.Receive(new Email());
        }


        //需求: Person 接收消息

        public class Person
        {
            //方式1
            //class過度依賴
            //如果獲取的對象是微信，要新增類or 重載
            //解決: 引入抽象街口 IReciever
            //email、微信 屬於接收的範圍，各自實現IReciever就行
            public void Receive(Email email)
            {
                Console.WriteLine(email.getInfo());
            }
        }

        public class Email
        {
            public string getInfo()
            {
                return "email msg send";
            }
        }
        

    }
}
