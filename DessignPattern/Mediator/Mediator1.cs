using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Mediator
{
    class Mediator1
    {
        public static void Run()
        {
            //創建一個中介者對像
            Mediator mediator = new ConcreteMediator();

            //創建各個子系統，創建時會順便註冊
            //創建Alarm 並加入到 ConcreteMediator
            Alarm alarm = new Alarm(mediator, "Alarm");
            CoffeeMachine coffeeMachine = new CoffeeMachine(mediator, "CoffeeMachine");
            Curtains curtains = new Curtains(mediator, "Curtains");
            TV tV = new TV(mediator, "TV");

            //讓鬧鐘發出消息
            alarm.SendAlarm(0);
            coffeeMachine.FinishCoffee();
            alarm.SendAlarm(1);
        }
        /*
            中介者模式
            1. 使用一個中介對像，由中介對向來跟子系統間交流(MVC)


            原理類圖跟角色職責
            1. Mediator : 抽象中介者，定義同事對像到中介者對像的接口
            2. Colleague : 抽象同事類
            3. ConcreteMediator : 具體的中介者對像，管理所有同事類，以集合管理
                                    接受某個同事對像消息，完成對應任務
            4. ConcreteColleague : 具體同事類，每個同事只知道自己的行為，不知道其他同事類的行為
                                    都依賴於中介者對像

            可以想像成原本是子系統直接互相溝通，
            現在改成 子系統將消息傳給 中介者，再由中介者通知各子系統該如何做動作(snedmessage)


            注意事項
            1. 可以將多個類互相解偶，將原本的網狀結構，轉為星型結構
            2. 減少類間的依賴，降低耦合，符合迪米特原則
            
            缺點:
            1. 中介者承擔較多責任，一旦中介者出現問題，整個系統將會受到影響
            2. 如果設計不當，中介者對像本身會變得過於複雜
        

            需求:
            智能家庭管理
            ex: 鬧鐘響起=> 咖啡機開始做咖啡 => 窗簾自動落下 => 電視機開始撥放
            ex: 租房直接找房東，房東說要問他妻子，妻子說要問他哥哥... => 對於租客(客戶端)很麻煩
                如果跟仲介租(中介者)，讓仲介去協調，會快很多

            傳統
            鬧鐘發出個信號給咖啡機 =>  咖啡機在發出信號給窗簾 => 咖啡機在發出系號給電視機
            子系統實作時關係複雜
            
            缺點:

            1. 當電器有多種狀態時，相互之間的調用會比較複雜
            2. 電器對象彼此聯繫，你中有我，我中有你，不利解偶
            3. 電氣間傳遞的消息(參數)，容易混亂
            => 考慮中介者模式
        */

        public abstract class Mediator
        {
            //將中介者對像，加入到集合中
            public abstract void Register(string colleagueName,Colleague colleague);
            //接收消息，具體的同事對像發出(核心方法，由他通知 各子系統如何動作)
            public abstract void GetMessage(int stateChange, string colleagueName);

        }

        public class ConcreteMediator : Mediator
        {
            private Dictionary<string, Colleague> colleagueMap;
            //這個不一定要
            private Dictionary<string, string> interMap;

            public ConcreteMediator()
            {
                colleagueMap = new Dictionary<string, Colleague>();
                interMap = new Dictionary<string, string>();
            }

            public override void Register(string colleagueName, Colleague colleague)
            {
                colleagueMap.Add(colleagueName, colleague);

                if(colleague is Alarm)
                {
                    interMap.Add("Alarm", colleagueName);
                }else if(colleague is CoffeeMachine)
                {
                    interMap.Add("CoffeeMachine", colleagueName);
                }
                else if (colleague is TV)
                {
                    interMap.Add("TV", colleagueName);
                }
                else if (colleague is Curtains)
                {
                    interMap.Add("Curtains", colleagueName);
                }

            }


            //具體中介者的核心方法 
            //跟據得到的消息，完成對應的任務
            // 協調具體的同事類完成任務
            public override void GetMessage(int stateChange, string colleagueName)
            {
                //這邊都是業務邏輯
                if (colleagueMap[colleagueName] is Alarm)
                {
                    if (stateChange == 0)
                    {   
                        //收到alarm 的訊息，且為0時
                        //啟動咖啡機
                        ((CoffeeMachine)colleagueMap[interMap["CoffeeMachine"]]).StartCoffee();
                        //打開電視
                        ((TV)colleagueMap[interMap["TV"]]).StartTv();
                    }else if(stateChange == 1)
                    {
                        ((TV)colleagueMap[interMap["TV"]]).StopTv();
                    }
                }else if(colleagueMap[colleagueName] is CoffeeMachine)
                {
                    ((Curtains)colleagueMap[interMap["Curtains"]]).UpCurtains();
                }
                
            }

            
        }

        public abstract class Colleague
        {
            private Mediator _mediator;
            public string Name { get; set; }

            public Colleague(Mediator mediator,string name)
            {
                _mediator = mediator;
                Name = name;
            }

            public Mediator GetMediator()
            {
                return _mediator;
            }

            public abstract void SendMessege(int stateChange);
        }

        //具體同事類
        public class Alarm : Colleague
        {
            public Alarm(Mediator mediator,string name):base(mediator,name)
            {
                //創建Alarm 對象時，將自己放入ConcreteMediator
                mediator.Register(name, this);
            }

            public void SendAlarm(int stateChange)
            {
                SendMessege(stateChange);
            }

            public override void SendMessege(int stateChange)
            {
                GetMediator().GetMessage(stateChange, this.Name);
            }
        }

        //具體同事類
        public class CoffeeMachine : Colleague
        {
            public CoffeeMachine(Mediator mediator, string name) : base(mediator, name)
            {
                //創建Alarm 對象時，將自己放入ConcreteMediator
                mediator.Register(name, this);
            }

            public void StartCoffee()
            {
                Console.WriteLine("coffe machine is starting");
            }

            public void FinishCoffee()
            {
                Console.WriteLine("after 5 mins");
                Console.WriteLine("coffee is ok");
                SendMessege(0);
            }
            //通知中介者
            public override void SendMessege(int stateChange)
            {
                GetMediator().GetMessage(stateChange, this.Name);
            }
        }

        //具體同事類
        public class TV : Colleague
        {
            public TV(Mediator mediator, string name) : base(mediator, name)
            {
                //創建Alarm 對象時，將自己放入ConcreteMediator
                mediator.Register(name, this);
            }

            public void StartTv()
            {
                Console.WriteLine("TV is start");
            }

            public void StopTv()
            {
                Console.WriteLine("TV is stop");
            }
            //通知中介者
            public override void SendMessege(int stateChange)
            {
                GetMediator().GetMessage(stateChange, this.Name);
            }
        }

        //具體同事類
        public class Curtains : Colleague
        {
            public Curtains(Mediator mediator, string name) : base(mediator, name)
            {
                //創建Alarm 對象時，將自己放入ConcreteMediator
                mediator.Register(name, this);
            }

            public void UpCurtains()
            {
                Console.WriteLine("curtains is up");
            }

            //通知中介者
            public override void SendMessege(int stateChange)
            {
                GetMediator().GetMessage(stateChange, this.Name);
            }
        }



    }
}
