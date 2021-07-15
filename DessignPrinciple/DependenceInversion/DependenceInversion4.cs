using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DependenceInversion
{
    class DependenceInversion4
    {

        public static void Run()
        {
            OpenAndClose openAndClose = new OpenAndClose(new TV());
            openAndClose.Open();
        }


        //2. 構造方法傳遞
        interface IOpenAndClose
        {
            public void Open();
        }

        interface ITV
        {
            public void Play();
        }

        //透過構造方法
        class OpenAndClose : IOpenAndClose
        {
            private ITV _tv;
            public OpenAndClose(ITV tv)
            {
                _tv = tv;
            }

            public void Open()
            {
                _tv.Play();
            }
        }

        class TV : ITV
        {
            public void Play()
            {
                Console.WriteLine("tv is playing");
            }
        }
    }
}
