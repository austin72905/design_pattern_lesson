using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Adapter
{
    class ObjectAdapter
    {
        //Client
        public static void Run()
        {
            Phone phone = new Phone();
            phone.Charging(new ElectricAdapter(new Electric220V()));
        }
        /*
        對象適配器
        
        1. 跟類適配器很像，只是將Adapter 對src 的繼承改成聚合or 組合

        2. 是最常用的適配器模式 (推薦使用)
         
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
        public class ElectricAdapter: IElectric5V
        {
            private Electric220V _electric220V;

            //透過構造器傳入
            public ElectricAdapter(Electric220V electric220V)
            {
                this._electric220V = electric220V;
            }

            //透過setter
            public void SetAdapter(Electric220V electric220V)
            {
                this._electric220V = electric220V;
            }

            public int Output5V()
            {
                int srcV = _electric220V.Output220V();
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
                }
                else if (electric5V.Output5V() > 5)
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
