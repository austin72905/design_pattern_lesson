using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DependenceInversion
{
    class DependenceInversion5
    {
        public static void Run()
        {
            OpenAndClose openAndClose = new OpenAndClose();
            openAndClose.SetTv(new TV());
            openAndClose.Open();
        }


        //3. 透過setter
        interface IOpenAndClose
        {
            public void Open();

            public void SetTv(ITV tv);
        }

        interface ITV
        {
            public void Play();
        }

        //透過構造方法
        class OpenAndClose : IOpenAndClose
        {
            private ITV _tv;
            //跟構造器差不多的感覺
            public void SetTv(ITV tv)
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
