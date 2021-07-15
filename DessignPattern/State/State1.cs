using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.State
{
    class State1
    {
        public static void Run()
        {
            //創建活動對象，有5個獎品
            RaffleActivity activity = new RaffleActivity(5);

            for (var i = 0;i<150; i++)
            {
                Console.WriteLine($"---------第{i+1}次抽獎-----------------");
                //扣積分
                activity.DeductMoney();
                //抽獎
                activity.Raffle();
            }
        }
        /*
            狀態模式
            解決多種狀態轉換需要對外輸出不同行為 
            通常會有3個角色職責
            1. Context : 上下文，負責維護 State，定義當前狀態
            2. State : 抽象類(or 接口) ，定義狀態的相關行為  
            3. ConcreteState : 具體狀態角色

            應用場景:
               當一個事件有很多狀態，狀態之間會互相轉換，對不同狀態要求有不同的行為時
               可以考慮使用狀態模式

            需求:
            抽獎
            1. 每次抽獎扣50積分，中獎機率10%
            2. 獎品數量有限，抽完就不能抽獎
            3. 有4個狀態
                可以抽獎、不能抽獎、發放獎品、獎品領完
            4. 初始狀態也是不能抽獎，扣除50積分後變成可以抽獎
                (雖然這個業務邏輯有點怪怪的，但主要是能順利切換狀態)
                不能抽獎 =(扣50積分)=> 可以抽獎 =(90%不中)=> 不能抽獎
                                              =(10%中獎)=> 發放獎品 =(獎品數>0)=> 不能抽獎
                                                                   =(獎品數<0)=> 獎品領完
        
         
            細節
            1. 有很強的可讀性，將狀態的行為封裝到一個類中 (取代if else)
            2. 符合開閉原則，容易增刪狀態
            
            缺點
            1. 容易產生很多類，每個狀態要對應一個類，加大維護難度
            
            
        

        */

        //Context
        //Activity
        public class RaffleActivity
        {
            //當前狀態
            State state;
            //僅品數量
            int count = 0;

            //會切換的狀態
            State noRaffleState;
            State canRaffleState;
            State dispenseState;
            State dispenseOutState;

            public RaffleActivity(int count)
            {
                this.count = count;
                noRaffleState = new NoRaffleState(this);
                canRaffleState = new CanRaffleState(this);
                dispenseState = new DispenseState(this);
                dispenseOutState = new DispenseOutState(this);
                
                this.state = GetNoRaffleState();
            }
            

            //調用當前狀態的扣積分
            public void DeductMoney()
            {
                state.DeductMoney();
            }

            //調用當前狀態的抽獎
            public void Raffle()
            {
                if (state.Raffle())
                {
                    state.DispensePrize();
                }
            }


            //每領一次獎品，count 要--
            public int GetCount()
            {
                int currentCount = count;
                count--;
                return currentCount;
            }


            //以下基本上都是get、set 方法，要改成C#　get;set; 也行
            //切換狀態的方法
            public void SetState(State state)
            {
                this.state = state;
            }

            public State GetNoRaffleState()
            {
                return noRaffleState;
            }

            public State GetCanRaffleState()
            {
                
                return canRaffleState;
            }

            public State GetDispenseState()
            {
                return dispenseState;
            }

            public State GetDispenseOutState()
            {
                return dispenseOutState;
            }

            



        }

        //State
        public abstract class State
        {
            //扣積分
            public abstract void DeductMoney();
            //抽獎
            public abstract bool Raffle();
            //發獎品
            public abstract void DispensePrize();
        }

        //不能抽獎
        public class NoRaffleState : State
        {
            RaffleActivity _activity;

            public NoRaffleState(RaffleActivity activity)
            {
                _activity = activity;
            }

            //當前狀態可以扣積分，扣除後將狀態變為可以抽獎的狀態
            public override void DeductMoney()
            {
                Console.WriteLine("扣除50積分，您可以抽獎了");
                _activity.SetState(_activity.GetCanRaffleState());
            }

            //抽獎
            public override bool Raffle()
            {
                Console.WriteLine("扣了積分才能抽獎喔");
                return false;
            }

            public override void DispensePrize()
            {
                Console.WriteLine("當前狀態不能發放獎品");
            }
        }

        //可以抽獎的狀態
        public class CanRaffleState: State
        {
            RaffleActivity _activity;

            public CanRaffleState(RaffleActivity activity)
            {
                _activity = activity;
            }

            //當前狀態可以扣積分，扣除後將狀態變為可以抽獎的狀態
            public override void DeductMoney()
            {
                Console.WriteLine("你已經扣除50積分了");
            }

            //抽獎
            public override bool Raffle()
            {
                Console.WriteLine("正在抽獎!稍等");
                Random r = new Random();
                int num = r.Next(10);

                //10% 中獎機會
                if (num == 0)
                {
                    //改變活動狀態為發放獎品
                    _activity.SetState(_activity.GetDispenseState());
                    return true;
                }

                Console.WriteLine("很遺憾沒有抽中");
                //改變狀態為不能抽獎
                _activity.SetState(_activity.GetNoRaffleState());
                return false;
            }

            public override void DispensePrize()
            {
                Console.WriteLine("沒中獎前不能發放獎品");
            }
        }

        //發放獎品
        public class DispenseState : State
        {
            RaffleActivity _activity;

            public DispenseState(RaffleActivity activity)
            {
                _activity = activity;
            }

            //當前狀態可以扣積分，扣除後將狀態變為可以抽獎的狀態
            public override void DeductMoney()
            {
                Console.WriteLine("不能扣除50積分");
                
            }

            //抽獎
            public override bool Raffle()
            {
                Console.WriteLine("不能抽獎");
                return false;
            }

            //發獎品
            public override void DispensePrize()
            {
                if (_activity.GetCount() > 0)
                {
                    Console.WriteLine("恭喜中獎");
                    //修改為不能抽獎
                    _activity.SetState(_activity.GetNoRaffleState());
                }
                else
                {
                    Console.WriteLine("很遺憾獎品發完了");
                    //改變狀態為獎品發送完畢
                    _activity.SetState(_activity.GetDispenseOutState());
                    Console.WriteLine("抽獎結束");
                    //程序退出
                    System.Environment.Exit(0);
                }

                
            }
        }

        //獎品發放完畢
        public class DispenseOutState : State
        {
            RaffleActivity _activity;

            public DispenseOutState(RaffleActivity activity)
            {
                _activity = activity;
            }

            public override void DeductMoney()
            {
                Console.WriteLine("獎品發完了，請下次再參加");         
            }

            //抽獎
            public override bool Raffle()
            {
                Console.WriteLine("獎品發完了，請下次再參加");
                return false;
            }

            public override void DispensePrize()
            {
                Console.WriteLine("獎品發完了，請下次再參加");
            }
        }
    }
}
