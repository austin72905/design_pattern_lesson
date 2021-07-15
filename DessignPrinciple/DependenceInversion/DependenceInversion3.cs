using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DependenceInversion
{
    class DependenceInversion3
    {
        public static void Run()
        {
            OpenAndClose openAndClose = new OpenAndClose();
            openAndClose.Open(new TV());
        }

        //依賴反轉3種傳遞方式
        //1. 接口傳遞
        //2. 構造方法傳遞
        //3. 透過setter



        //1. 接口傳遞

        interface IOpenAndClose
        {
            public void Open(ITV tv);
        }

        interface ITV
        {
            public void Play();
        }

        class OpenAndClose : IOpenAndClose
        {
            public void Open(ITV tv)
            {
                tv.Play();
            }
        }

        class TV:ITV
        {
            public void Play()
            {
                Console.WriteLine("tv is playing");
            }
        }
    }
}
