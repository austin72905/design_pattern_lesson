using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Proxy
{
    //調用的類一定要是public
    public class DynamicProxy
    {
        public static void Run()
        {
            ProxyGenerator generator=new ProxyGenerator();

            Teacher teacher = generator.CreateClassProxy<Teacher>(new ProxyTeacher());
            teacher.Teach();
            teacher.Say("肏你媽",msg2:"吃我屌");
        }

        
        public static Teacher CreateProxy()
        {
            ProxyGenerator generator = new ProxyGenerator();

            Teacher teacher = generator.CreateClassProxy<Teacher>(new ProxyTeacher());
            return teacher;
        }
        /*
        代理模式
        
        C# 要去nuget下載 Castle.Core

        1. 要被代理對象的方法一定要是virtual

        2. 調用的類一定要是public
        */


        //被代理對象
        public class Teacher
        {
            //要被代理對象的方法一定要是virtual
            public virtual void Teach()
            {
                Console.WriteLine("老師授課中");
            }

            public virtual string Say(string msg,string msg2="")
            {
                Console.WriteLine($"老師說: {msg} {msg2}");
                return msg;
            }
        }

        //代理對象
        public class ProxyTeacher : IInterceptor//攔截器
        {
            //實現IInterceptor 裡 Intercept 方法
            public void Intercept(IInvocation teacher)
            {
                Console.WriteLine("代理對象開始代理");
                teacher.Proceed();
                Console.WriteLine("代理結束");
                if (teacher.Arguments.Length > 0)
                {
                    foreach(var i in teacher.Arguments)
                    {
                        Console.WriteLine($"傳入的參數有這些: {i}");
                    }

                    Console.WriteLine($"傳入的返回值有{teacher.ReturnValue}");
                }
                
            }
            
        }
    }
}
