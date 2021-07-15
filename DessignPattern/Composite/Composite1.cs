using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Composite
{
    class Composite1
    {

        public static void Run()
        {
            //從大到小，創建對象
            OrganizationComponent university = new University("台灣大學", "台灣第一的大學");

            OrganizationComponent college = new College("計算機學院", "計算機學院");
            OrganizationComponent college2= new College("信息工程學院", "信息工程學院");

            college.Add(new Department("JAVA", "JAVA好"));
            college.Add(new Department("C#", " C#好"));
            college.Add(new Department("go", " go好"));

            college2.Add(new Department("通信工程", "通信工程好難"));
            college2.Add(new Department("信息工程", "信息工程好難"));

            university.Add(college);
            university.Add(college2);

            //看要打印大學or 學院
            university.Print();
        }

        //組合模式

        //需求
        /*
          
            看一個學校校系展示
            ----清華大學----
            ----計算機學院----
            java
            C#
            go
            ----訊息工程學院----
            通信工程
            信息工程

            傳統: 用繼承的
            缺點: 
            1. 學校=>學院=>系，這樣實際是以大小區分，這樣區分會變成用子類去管理父類，怪異
            2. 難以管理，如對院、系的增刪、遍歷
            3. 因為系有很多個，應該是樹狀結構

            解決方法:
            1. 將 學校、學院、系 => 組織結構   用樹狀管理

            => 組合模式
            

            組合模式
        
            1. 又稱部分整體模式，將對象組合以樹狀結構表示 "整體-部分" 的層次
            2. 讓客戶端以一致至方式處理對象、組合對象

            3. 原理類圖
               (1) component: 組中對象的聲明接口，用於管理component 子組件， 可以抽象類 或街口
               (2) leaf : 最末節點，無子節點 (ex: 系)
               (3) composite : 非葉子節點，用來存子組件，在component中實現子組件相關操作

            使用細節
            1. 簡化客戶端操作，只需要面對一致的對象，不用考慮整體部份或結點葉子的問題
            2. 具有較強擴展性
            3. 方便建構複雜的樹狀結構，管理方便
            4. 需要便利組織機構，或是處理的對象具有樹狀結構，非常適合組合模式
            5. 如果節點後葉子有很多差異性，比如方法跟屬性都不一樣，不是和使用組合模式
         
         
        */

        public abstract class OrganizationComponent
        {
            private string Name;
            private string Des;

            public OrganizationComponent(string name, string des)
            {
                this.Name = name;
                this.Des = des;
            }

            public string GetName()
            {
                return Name;
            }

            public string GetDes()
            {
                return Des;
            }

            //問什麼不寫成abstract抽象? 因為leaf 也會繼承這個類，他本身不用實現這個方法
            public virtual void Add(OrganizationComponent organizationComponent)
            {

            }

            public virtual void Remove(OrganizationComponent organizationComponent)
            {

            }

            //
            public abstract void Print();


        }

        //composite
        public class University : OrganizationComponent
        {
            //存放的是college
            List<OrganizationComponent> organizationComponents = new List<OrganizationComponent>();

            public University(string name, string des) : base(name, des)
            {

            }

            public override void Add(OrganizationComponent organizationComponent)
            {
                //加到集合內
                organizationComponents.Add(organizationComponent);
            }

            public override void Remove(OrganizationComponent organizationComponent)
            {
                //從集合內刪除
                organizationComponents.Remove(organizationComponent);
            }

            //輸出包含的系
            public override void Print()
            {
                Console.WriteLine($"---------{base.GetName()}--------");

                foreach (var item in organizationComponents)
                {
                    item.Print();
                }
            }
        }

        //composite
        public class College : OrganizationComponent
        {
            //存放的是department
            List<OrganizationComponent> organizationComponents = new List<OrganizationComponent>();

            public College(string name, string des) : base(name, des)
            {

            }

            public override void Add(OrganizationComponent organizationComponent)
            {
                //加到集合內
                //將來college 跟 university 業務邏輯不同，這邊也可以自己重寫
                organizationComponents.Add(organizationComponent);
            }

            public override void Remove(OrganizationComponent organizationComponent)
            {
                //從集合內刪除
                organizationComponents.Remove(organizationComponent);
            }

            //輸出包含的系
            public override void Print()
            {
                Console.WriteLine($"---------{base.GetName()}--------");

                foreach (var item in organizationComponents)
                {
                    item.Print();
                }
            }
        }
        
        //leaf
        public class Department : OrganizationComponent
        {
            public Department(string name, string des) : base(name, des)
            {

            }

            //輸出包含的學院
            public override void Print()
            {
                Console.WriteLine($"---------{base.GetName()}--------");
            }
        }

    }
}
