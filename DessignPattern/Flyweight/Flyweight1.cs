using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Flyweight
{
    class Flyweight1
    {
        public static void Run()
        {
            //創建一個工廠類
            WebSiteFactory webSiteFactory = new WebSiteFactory();

            //客戶A要以新聞型式的網站
            WebSite webSite1 = webSiteFactory.GetWebStieCatagory("新聞");
            webSite1.Use(new User("A"));

            //客戶B要以blog型式的網站
            WebSite webSite2 = webSiteFactory.GetWebStieCatagory("blog");
            webSite2.Use(new User("B"));

            //客戶C要以blog型式的網站
            WebSite webSite3 = webSiteFactory.GetWebStieCatagory("blog");
            webSite3.Use(new User("C"));

            //如果客戶有使用之前存在過的模式，就會從池中拿中拿，不會新增一個種類
            //打印網站的種類數
            Console.WriteLine($"網站的種類數 {webSiteFactory.GetWebSiteCount()}");
        }
        /*
            享元模式(flyweight 蠅量模式)
            1. 常用於系統底層開發EX:　資料庫連接池、java string池
            2. 解決重複對象的內存浪費問題

            原理圖的角色和職責
            1. FlyWeight : 抽象的享元角色，是一個抽象類，可以定義對象的外部狀態和內部狀態 的接口或實現
                (1) 內部狀態 : 相對穩定，不隨環境變化，種類也較少 (能共享的)
                (2) 外部狀態 : 有變化(不能共享的)
                    ex: 以五子棋為例，棋的顏色是固定的(黑、白)(內部狀態)，旗下的位置會變化(外部狀態)
            2. ConcreteFlyWeight : 具體的享元角色，實現抽象角色定義的業務
            3. UnSharedConcreteFlyWeight 不可共享的角色，一般不會出現在工廠
            4. FlyWeightFactory 享元工廠類，用於構建一個池容器，提供從池中獲取對像方法

            細節與注意事項
            1. 系統有大量對象，這些對象消耗大量內存，且對象的狀態部份可以外部化時，可以考慮使用享元模式
            2. 用為一標示碼判斷，如果內存中有，則返回為一標示碼所標示的對象，用dict 存
            3. 大大減少對象的創建，降低了程序內存的佔用
            4. 需要區分內部狀態跟外部狀態，且需要有個工廠類加以控制
            5. 最常應用場景是 string pool  資料庫連線池
            缺點:
            1. 提高系統的複雜度，需要分離出內部狀態和外部狀態，外部狀態具有固化特性，不應該隨著內部狀態的改變而改變
                
            

            需求:
            現在我們是個外包公司，有多個客戶需要 產品展示網站
            但每個客戶要求不同
            1. A客戶希望以新聞型式
            2. B客戶希望以blog 方式
            3. C客戶希望以FB型式

            傳統:
            複製黏貼，每個客戶用不同的虛擬機，然後根據客戶不同，在個別訂製需求
            
            缺點:
            1. 需要的網站結構相似度很高，這個很浪費空間
            2. 解決思路: 整合到一個網站中，共享其相關的代碼和數據，內存、CPU、數據庫這些可以共享
            3. 共用一份實例，維護跟擴展都更加容易
            4. 可以使用享元模式


            
        */

        public abstract class WebSite
        {
            public abstract void Use(User user);
        }

        public class ConcreteWebSite: WebSite
        {
            //共享的部份，屬於內部狀態
            private string type = ""; //網站發布的型式
            public ConcreteWebSite(string type)
            {
                this.type = type;
            }
            public override void Use(User user)
            {
                Console.WriteLine($"網站的發布型式為 {type} ， 用戶 {user.Name}在使用中");
            }
        }

        public class WebSiteFactory
        {
            //池
            private Dictionary<string, ConcreteWebSite> pool = new Dictionary<string, ConcreteWebSite>();

            //根據類型返回網站，沒有建創建一個放入池中

            public WebSite GetWebStieCatagory(string type)
            {
                if (!pool.ContainsKey(type))
                {
                    //創建並放入池
                    pool.Add(type, new ConcreteWebSite(type));
                }

                return pool[type];
            }

            //獲取網站分類種數
            public int GetWebSiteCount()
            {
                return pool.Count;
            }
        }

        //外部狀態
        public class User
        {
            public string Name { get; set; }

            public User(string name)
            {
                Name = name;
            }
        }
    }
}
