using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Chain_of_Responsibility
{
    class ChainOfResponsibility1
    {
        public static void Run()
        {
            //創建一個請求
            PurchaseRequest purchaseRequest = new PurchaseRequest(1, 31000, 1);

            //創建審批人
            DepartmentHandler departmentHandler = new DepartmentHandler("張主任");
            CollegeHandler collegeHandler = new CollegeHandler("李院長");
            VicePrincipalHandler vicePrincipalHandler = new VicePrincipalHandler("王副校長");
            PrincipalHandler principalHandler = new PrincipalHandler("林校長");

            //將責任鍊設置好(要構成環狀，除非你從第一個調)
            departmentHandler.SetHandler(collegeHandler);
            collegeHandler.SetHandler(vicePrincipalHandler);
            vicePrincipalHandler.SetHandler(principalHandler);


            //開始批准流程
            departmentHandler.ProcessRequest(purchaseRequest);




        }
        /*
            職責鍊模式(責任鍊模式)
            
            為請求創建一個接收者對像的鍊(接收者包含另一個接收者的引用)，如果不能處理，就傳給下一個(很像node 鏈結串列)


            細節和注意事項
            1. 將請求和處理分開
            2. 對像不需要知道鍊的結構
            
            缺點:
            1. 因為是鍊，如果鍊很長的話，會影響效能，需要控制最大節點量，一般通過Handler 設置一個最大節點數量
            2. debug不方便，採用了類似遞歸的方式，邏輯較複雜
            
            應用場景:
            有多個對象可以處理同一個請求時，比如多級請求、請假審批流程、tomcat對encoding 的處理、攔截器
        

            需求
            學校採購案
            1. 金額<5000，由教學主任批准
            2. 5000<金額<1000 由院長批准
            3. 10001<金額<30000 由副校長批准
            4. 30001<金額 由校長批准

            傳統方案
            用switch、if 判斷金額再決定要給哪個層級的主管批准    

            缺點
            1. 如果各級別的審批金額出現變化，客戶端必須變化
            2. 客戶端必須明確知道有多少個審批級別和訪問
            3. 對於採購請求進行處理跟Approver(審批人)存在強耦合
            => 職責鍊模式
        */

        public class PurchaseRequest
        {
            //請求類型
            public int Type { get; set; }
            public float Price { get; set; }
            public int Id  { get; set; }

            public PurchaseRequest(int type,float price,int id)
            {
                Type = type;
                Price = price;
                Id = id;
            }

        }

        public abstract class Handler
        {
            protected Handler _handler;
            protected string Name;

            public Handler(string name)
            {
                Name = name;
            }

            //下一個處理者
            public void SetHandler(Handler handler)
            {
                _handler = handler;
            }

            //處理審批請求的方法
            public abstract void ProcessRequest(PurchaseRequest purchaseRequest);

        }

        public class DepartmentHandler : Handler
        {
            public DepartmentHandler(string name) : base(name) { }
            
            public override void ProcessRequest(PurchaseRequest purchaseRequest)
            {
                if (purchaseRequest.Price <= 5000)
                {
                    Console.WriteLine($"請求ID: {purchaseRequest.Id} 採購，被 {Name} 處理了");
                }
                else
                {
                    //讓下一個層級的人審批
                    _handler.ProcessRequest(purchaseRequest);
                }
            }
        }

        public class CollegeHandler : Handler
        {
            public CollegeHandler(string name) : base(name) { }

            public override void ProcessRequest(PurchaseRequest purchaseRequest)
            {
                if (purchaseRequest.Price <= 10000)
                {
                    Console.WriteLine($"請求ID: {purchaseRequest.Id} 採購，被 {Name} 處理了");
                }
                else
                {
                    //讓下一個層級的人審批
                    _handler.ProcessRequest(purchaseRequest);
                }
            }
        }

        public class VicePrincipalHandler : Handler
        {
            public VicePrincipalHandler(string name) : base(name) { }

            public override void ProcessRequest(PurchaseRequest purchaseRequest)
            {
                if (purchaseRequest.Price <= 30000)
                {
                    Console.WriteLine($"請求ID: {purchaseRequest.Id} 採購，被 {Name} 處理了");
                }
                else
                {
                    //讓下一個層級的人審批
                    _handler.ProcessRequest(purchaseRequest);
                }
            }
        }

        public class PrincipalHandler : Handler
        {
            public PrincipalHandler(string name) : base(name) { }

            public override void ProcessRequest(PurchaseRequest purchaseRequest)
            {
                Console.WriteLine($"請求ID: {purchaseRequest.Id} 採購，被 {Name} 處理了");
                
            }
        }
    }
}
