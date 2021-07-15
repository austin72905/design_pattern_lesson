using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Proxy
{
    class StaticProxy
    {
        //Client
        public static void Run()
        {
            
            ProxyTeacher proxyTeacher = new ProxyTeacher(new Teacher());
            //通過代理對象在去調用被代理對象的方法
            proxyTeacher.Teach();
        }
        /*
        靜態代理
        
        1. 替身跟被代理對象都實現同個接口(或繼承同個父類)，替身聚合接口傳入代理對象，
            就可以在替身理調用被代理對象的方法

        優點: 可以對被代理對象進行功能擴充
        缺點: 
        1. 因為代理對象跟被代理對象要實現同個接口，會有很多代理類
        2. 一旦接口增加方法，代理類跟被代理類都要維護

        需求:
        teacher 生病，要代理teacher幫他上課
        */

        
        public interface ITeacher
        {
            public void Teach();
        }

        //被代理對象
        public class Teacher: ITeacher
        {
            public void Teach()
            {
                Console.WriteLine("老師授課中");
            }
        }

        //代理對象
        public class ProxyTeacher : ITeacher
        {
            private ITeacher _teacher;

            public ProxyTeacher(ITeacher teacher)
            {
                this._teacher = teacher;
            }
            public void Teach()
            {
                Console.WriteLine("代理對象開始代理");
                _teacher.Teach();
                Console.WriteLine("代理結束");
            }
        }
    }
}
