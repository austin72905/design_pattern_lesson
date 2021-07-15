using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Adapter
{
    class InterfaceAdapter
    {
        public static void Run()
        {
            Target target = new Target();
            target.Method1();
        }
        /*
        抽象接口適配器
        
        目的:
        當一個類不需要實現全部接口時，可以用個abstract 類 作為Adapter 實現所有接口(用空方法)
        類在去繼承abstract 類

        C# 沒有這個，因為C# 的 abstract 類不能new 一個出來復寫
        */

        public interface ISrc
        {
            public void Method1();
            public void Method2();
            public void Method3();
            public void Method4();
        }

        //適配器，對街口進行默認實現
        public abstract class AbsAdapter : ISrc
        {
            public virtual void Method1()
            {

            }
            public virtual void Method2()
            {

            }
            public virtual void Method3()
            {

            }
            public virtual void Method4()
            {

            }
        }

        public class Target :AbsAdapter
        {
            public override void Method1()
            {
                Console.WriteLine("我複寫了方法");
            }
        }

    }
}
