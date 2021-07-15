using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.InterfaceSegregation
{
    class InterfaceSegregation1
    {
        //接口隔離原則
        //客戶端不應該依賴他不需要的街口，即一個類對另一個類的依賴應該建立在最小的街口上

        //假設 A類 ==(依賴)==> I接口 ==(實作)==> B類  (A透過I來依賴B)
        //but A 只會用到接口中的某幾個方法，因為B 需要實作I，所以他也要去實作那些A用不到的方法

        //    C類 ==(依賴)==> I接口 ==(實作)==>D類  (C透過I來依賴D)
        //but C 也只會用到接口中的某幾個方法，因為D 需要實作I，所以他也要去實作那些C用不到的方法

        //==> 這時就需要接口隔離

        //將接口拆分成獨立的幾個接口，A類跟C類分別他們需要的街口建立依賴關係

        public interface I
        {
            void imple1();
            void imple2();
            void imple3();
            void imple4();
            void imple5();
        }

        public class A
        {
            public void depend(I i)
            { 
                i.imple1();
                i.imple3();
                i.imple5();
            }
        }

        //(A透過I來依賴B)就算A只需要用到1、3、5的方法，卻要B實做他不需要的方法，不合理
        public class B : I
        {
            public void imple1()
            {

            }
            public void imple2()
            {

            }
            public void imple3()
            {

            }
            public void imple4()
            {

            }
            public void imple5()
            {

            }
        }


        public class C
        {
            public void depend(I i)
            {
                i.imple2();
                i.imple4();
                i.imple5();
            }
        }


        //(C透過I來依賴D)就算C只需要用到2、4、5的方法，卻要D實做他不需要的方法，不合理
        public class D : I
        {
            public void imple1()
            {

            }
            public void imple2()
            {

            }
            public void imple3()
            {

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
