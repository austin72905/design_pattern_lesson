using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Adapter
{
    class ClassAdapter
    {
        //Client
        public static void Run()
        {
            Phone phone = new Phone();
            phone.Charging(new ElectricAdapter());
        }
        /*
        類適配器
        
        通過繼承src類，實現dst類
        
        需求:
        手機充電 220V 的插座(src)，目的5V 電流(dst)，所以需要充電器(adapter) 

        細節:
        1. C# 是單繼承制，而適配器模式一定要繼承，而dst必須是接口，有一定侷限性
        2. src 的方法在Adapter 中會暴露出來，增加使用成本
        3. 因為繼承了src類，可以根據需求重寫src類的方法，靈活性強
        */

        //被適配類
        public class Electric220V
        {
            //輸出220V電壓
            public int Output220V()
            {
                int src = 220;
                Console.WriteLine("電壓=" + src + "伏特");
                return src;
            }
        }

        //適配接口
        public interface IElectric5V
        {
            public int Output5V();
        }

        //適配器類
        public class ElectricAdapter : Electric220V, IElectric5V
        {
            public int Output5V()
            {
                int srcV = Output220V();
                int dstV = srcV / 44;
                return dstV;
            }
        }

        public class Phone
        {
            public void Charging(IElectric5V electric5V)
            {
                if (electric5V.Output5V() == 5)
                {
                    Console.WriteLine("電壓為5，可以充電了");
                }else if(electric5V.Output5V() > 5)
                {
                    Console.WriteLine("電壓過高");
                }
                else
                {
                    Console.WriteLine("電壓不夠");
                }
            }
        }

    }
}
