using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Bridge
{
    class Bridge1
    {
        //Client
        public static void Run()
        {
            //折疊式(樣式+品牌)
            Phone  phone1= new FoldedPhone(new XiaoMi());
            phone1.Open();

            Phone phone2 = new UpRightPhone(new XiaoMi());
            phone2.Open();
        }
        /*
        橋接模式

        1. 將實現與抽象放在兩個不同的類層次，使兩個層次互相獨立
        2. 基於類的最小設計原則，讓不同的類承擔不同的職責

        細節:
        1. 實現了抽象和實現的分離，有助系統分層設計，靈活性也好
        2. 只需要知道抽象部分和實現部分的街口就可以了，其他的部分由具體業務來完成
        3. 橋接模式替代多層繼承方案，可以減少子類個數，降低系統的管理和維護成本
        
        缺點:
        1. 橋接模式的引入增加了系統的理解和設計難度，由於聚合關連在抽象層，
            要求開發者針對抽象進行設計和編程
        2. 要求正確識別出系統中兩個獨立變化的維度，使用範圍有侷限性

        常見應用場景

        1. 對於不希望使用繼承或因為多層次繼承導致系統類個數急遽增加的系統
           (個人見解: 很明確看出有兩個不同維度的業務)

        2. 常見業務
           (1) 銀行轉帳
                轉帳分類: 網上轉帳、櫃台轉帳、atm轉帳
                用戶類型: 普通用戶、銀卡用戶、金卡用戶

           (2) 消息管理
                消息類型: 即時消息、延時消息
                消息分類: 手機短信、由建消息、qq消息

           (3) 第三方支付
                支付類型: 掃碼、h5、wap
                支付方式: 支付保、微信、網銀
        
        需求:
        手機有分 折疊式、直立式、旋轉式，又有一堆品牌(小米、vivo、華韋)
        請做一個分類

        傳統:
        以操作方式分 => 在對映有這個方式的品牌
        缺點:
        增加一種方式的話，下面要重新在找對映的品牌，改動量大
        */

        //橋接模式

        public interface Brand
        {
            public void Open();
            public void Close();
            public void Call();
        }

        public class XiaoMi: Brand
        {
            public void Open()
            {
                Console.WriteLine("小米手機開機了");
            }

            public void Close()
            {
                Console.WriteLine("小米手機關機了");
            }
            public void Call()
            {
                Console.WriteLine("小米手機打電話");
            }
        }

        public class Vivo : Brand
        {
            public void Open()
            {
                Console.WriteLine("Vivo手機開機了");
            }

            public void Close()
            {
                Console.WriteLine("Vivo手機關機了");
            }
            public void Call()
            {
                Console.WriteLine("Vivo手機打電話");
            }
        }

        public abstract class Phone
        {
            //聚合品牌
            private Brand _brand;

            public Phone(Brand brand)
            {
                _brand = brand;
            }

            public virtual void Open()
            {
                _brand.Open();
            }

            public virtual void Close()
            {
                _brand.Close();
            }

            public virtual void Call()
            {
                _brand.Call();
            }
        }

        //摺疊樣式的
        public class FoldedPhone: Phone
        {
            public FoldedPhone(Brand brand):base(brand)
            {

            }

            public override void Open()
            {
                base.Open();
                Console.WriteLine("現在是摺疊樣式的手機");
            }

            public override void Close()
            {
                base.Close();
                Console.WriteLine("現在是摺疊樣式的手機");
            }

            public override void Call()
            {
                base.Call();
                Console.WriteLine("現在是摺疊樣式的手機");
            }
        }

        //直立樣式的
        public class UpRightPhone : Phone
        {
            public UpRightPhone(Brand brand) : base(brand)
            {

            }

            public override void Open()
            {
                base.Open();
                Console.WriteLine("現在是直立樣式的手機");
            }

            public override void Close()
            {
                base.Close();
                Console.WriteLine("現在是直立樣式的手機");
            }

            public override void Call()
            {
                base.Call();
                Console.WriteLine("現在是直立樣式的手機");
            }
        }

        //旋轉樣式的
        public class SpanPhone : Phone
        {
            public SpanPhone(Brand brand) : base(brand)
            {

            }

            public override void Open()
            {
                base.Open();
                Console.WriteLine("現在是旋轉樣式的手機");
            }

            public override void Close()
            {
                base.Close();
                Console.WriteLine("現在是旋轉樣式的手機");
            }

            public override void Call()
            {
                base.Call();
                Console.WriteLine("現在是旋轉樣式的手機");
            }
        }
    }
}
