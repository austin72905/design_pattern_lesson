using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.InterfaceSegregation
{
    public class InterfaceSegregation2
    {

        public static void Run()
        {
            A a = new A();
            a.depend1(new B());
            C c = new C();
            c.depend1(new D());
        }

        //將原有的I街口拆成3個
        public interface I1
        {
            void imple1();   
            void imple3();           
        }

        public interface I2
        {
            void imple2();
            void imple4();
        }

        public interface I3
        {
            void imple5();
        }

        public class A
        {
            public void depend1(I1 i)
            {
                i.imple1();
                i.imple3();
                
            }
            public void depend3(I3 i)
            {
                
                i.imple5();
            }

            
        }

        //(A透過I來依賴B)只要實作A需要的方法
        public class B : I1,I3
        {
            public void imple1()
            {
                Console.WriteLine("我是B，我實作了");
            }
            
            public void imple3()
            {

            }
            
            public void imple5()
            {

            }
        }


        public class C
        {
            public void depend1(I2 i)
            {
                i.imple2();
                i.imple4();
                
            }

            public void depend2(I3 i)
            {
                i.imple5();
            }

            
        }


        //(C透過I來依賴D)只要實作C需要的方法
        public class D : I2,I3
        {
            
            public void imple2()
            {
                Console.WriteLine("我是D，我實作了");
            }
            
            public void imple4()
            {

            }
            public void imple5()
            {

            }
        }
    }
    
}
