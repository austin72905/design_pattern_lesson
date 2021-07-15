using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Proxy
{
    class Proxy1
    {
        /*
        代理模式
        
        1. 給對象創一個替身，可以對原本對象進行個功能的擴充

        2. 通過替身，訪問被代理對象

        3. 對象可以是遠程對象、創建開銷大的對象、需要安全控制的對象

        4. 可分為
           (1) 靜態代理

           (2) 動態代理(JDK代理、接口代理)C# 要去nuget下載 Castle.Core

           (3) Cglib代理(可以在內存中動態創建，而不需要實現接口)=> 是動態代理的範疇

        常用場景:
        1. 防火牆代裡 : 內網通過代裡穿透防火牆，實現對公網的訪問
        2. 緩存代裡 : ex 取資源時先到緩存取代裡，取不到資源再到數據庫取
        3. 遠程代裡 : 可以把遠程對像當成本地對像來調用，偷過網路和真正的遠程對像溝通訊息
        4. 同步代裡 : 用在多線程中，完成多線成同步工作
            
         
        */
    }
}
