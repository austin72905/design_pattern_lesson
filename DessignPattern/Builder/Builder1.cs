using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Builder
{
    class Builder1
    {
        public static void Run()
        {
            CommonHouse common = new CommonHouse();
            common.Build();

        }

        /*
        建造者模式
        
        1. 將複雜過程抽象出來，使抽象過程的不同實現方法可以構建出不同表現的對象
        
        2. 一步步創建一個複雜的對象，他允許用戶只通過指定複雜對象的類型和內容就可以構建他們，
           用戶不需要知道內部的具體構建細節

        3. 四個核心角色
            (1) Product(產品): 一個具體的產品
            
            (2) Builder(抽象構建者): 創建一個Product對象的各個部件指定的接口/抽象類 (建造的各個方法)

            (3) ConcreteBuilder (具體構建者): 實現接口，構建和裝配各個部件
        
            (4) Director(指揮者): 構建一個使用Builder接口的對象，主要用於創建一個
                複雜的對象，有兩個作用
                    1. 隔離客戶與對像的生產過程
                    2. 負責控制產品對像的生產過程

        細節:
        1. 把產品跟製造過程分開

        2. 產品間的差異性很大，則不適合建造者模式

        3. 抽像工廠vs建造者模式

           (1)抽像工廠: 實現一個產品家族，產品家族是一系列商品:具有不同分類為度的產品組合
                       ，不關心建造過程，只關心產品由什麼工廠生產即可
           (2)建造者模式: 要求依造指定藍圖建造產品，透過組裝零件產生一個新產品
        */

        //需求
        //需要蓋房子，要打地基、砌牆、蓋屋頂，不管是一般平房、別墅都要經過這個過程

        //傳統寫法
        /*
        優點: 好理解
        缺點: 過於簡單，沒有設計緩存層成序的擴展漢維護不好，把產品跟創建產品的過程
        封裝再一起，耦合性太強
        
        將產品與產品建造過程解偶=>建造者模式
        */
        public abstract class  AbstractHouse
        {

            //打地基
            public abstract void  BuildBasic();

            //建造牆
            public abstract void BuildWalls();

            //蓋屋頂
            public abstract void PutRoof();

            //建造主要方法
            public void Build()
            {
                BuildBasic();
                BuildWalls();
                PutRoof();

            }

        }

        public class CommonHouse : AbstractHouse
        {
            public override void BuildBasic()
            {
                Console.WriteLine("給普通房子打地基");
            }

            public override void BuildWalls()
            {
                Console.WriteLine("給普通房子蓋牆");
            }

            public override void PutRoof()
            {
                Console.WriteLine("給普通房子蓋屋頂");
            }
        }


        public class HighBuilding : AbstractHouse
        {
            public override void BuildBasic()
            {
                Console.WriteLine("給高樓打地基");
            }

            public override void BuildWalls()
            {
                Console.WriteLine("給高樓蓋牆");
            }

            public override void PutRoof()
            {
                Console.WriteLine("給高樓蓋屋頂");
            }
        }
    }
}
