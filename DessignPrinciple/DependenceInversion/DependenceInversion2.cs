using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DependenceInversion
{
    class DependenceInversion2
    {
        //方案2
        public static void Run()
        {
            Person person = new Person();
            person.Receive(new Email());
            person.Receive(new WeiXin());
        }

        public interface IReciever
        {
            public string getInfo();
        }

        public class Person
        {
            //如果這邊使用方案1的寫法
            //在新增微信方法時，這邊要多寫個重載，很麻煩
            public void Receive(IReciever reciever)
            {
                Console.WriteLine(reciever.getInfo());
            }
        }

        public class Email:IReciever
        {
            public string getInfo()
            {
                return "email msg send";
            }
        }

        public class WeiXin : IReciever
        {
            public string getInfo()
            {
                return "WeiXin msg send";
            }
        }

    }
}
