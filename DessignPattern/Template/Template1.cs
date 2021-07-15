using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Template
{
    class Template1
    {
        public static void Run()
        {
            //製作紅豆豆漿
            SoyMilk soyMilk=  new ReadBeanSoyMilk();
            soyMilk.Make();

            //製作花生豆將
            SoyMilk soyMilk2 = new ReadBeanSoyMilk();
            soyMilk2.Make();

            //製作純豆將
            SoyMilk soyMilk3 = new PureSoyMilk();
            soyMilk3.Make();
        }
        /*
        模板模式
        使用場景: 當要執行一系列的步驟基本相同，但個別步驟在實現時可能不同，可以考慮模板方法
        1. 將共同要做的是抽取出來再父類
        2. 各自的差異再子類複寫

        鉤子方法
        1. 再模板模式的父類中，可以訂一個不做事的方法，讓子類是情況要不要覆蓋他
        
        細節:
        1. 算法只存在於一個地方，也就是父類，容易修改，提供很大靈活性
        2. 實現最大代碼附用
        3. 一般模板方法都會加上 final 關鍵字 (不給複寫)

        缺點:
        1. 每個不同的實現都要一個子類實現，類數量會龐大


        需求:
        製作豆漿
        1. 製作豆漿的流程 選材=> 添加配料 => 浸泡 => 放到豆漿機打碎
        2. 通過不同的配料，製作部頭口味的豆漿
        3. 除了配料其他方法對所有口味的豆漿都是一樣的
        4. 用鉤子方法創純豆漿
         
        */

        //為了加 sealed 我才加這個類.. 因為C# 沒有final，
        //又 sealed 要跟 override 綁一起
        public abstract class SoyMilkMake
        {
            public abstract void Make();
        }

        //把共用方法提到上一層寫
        public abstract class SoyMilk: SoyMilkMake
        {
            //模板方法，(通常)可加sealed 不讓子類複寫
            public sealed override void Make()
            {
                Select();
                if (AddOK())
                {
                    AddDecoate();
                }
                
                Soak();
                Beat();
            }

            public void Select()
            {
                Console.WriteLine("第一步，選擇好的新鮮黃豆");
            }

            //讓子類複寫
            public abstract void AddDecoate();

            public void Soak()
            {
                Console.WriteLine("第三步，黃豆跟配料開始浸泡");
            }

            public void Beat()
            {
                Console.WriteLine("第四步，黃豆跟配料放到豆漿機去打碎");
            }

            //鉤子方法，默認情況要加配料
            public virtual bool AddOK()
            {
                return true;
            }
        }

        public class ReadBeanSoyMilk : SoyMilk
        {
            public override void AddDecoate()
            {
                Console.WriteLine("加入上好的紅豆");
            }
        }

        public class PeanutSoyMilk : SoyMilk
        {
            public override void AddDecoate()
            {
                Console.WriteLine("加入上好的花生");
            }
        }

        public class PureSoyMilk : SoyMilk
        {
            //空實現
            public override void AddDecoate()
            {
            }

            //複寫鉤子方法
            public override bool AddOK()
            {
                return false;
            }
        }

    }
}
