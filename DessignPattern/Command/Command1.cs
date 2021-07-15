using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Command
{
    class Command1
    {
        public static void Run()
        {
            //創建電燈(接收者)對象
            LightReciver lightReciver = new LightReciver();

            //開關命令
            LightOnCommand lightOnCommand = new LightOnCommand(lightReciver);
            LightOffCommand lightOffCommand = new LightOffCommand(lightReciver);

            //遙控器
            RemoteController remoteController = new RemoteController();

            //給遙控器設置相關命令
            //EX: no=0 是電燈的操作
            remoteController.SetCommand(0, lightOnCommand, lightOffCommand);

            Console.WriteLine("------按下開燈按鈕-------");
            remoteController.OnButtonWasPushed(0);
            Console.WriteLine("------按下關燈按鈕-------");
            remoteController.OffButtonWasPushed(0);
            Console.WriteLine("------按下撤銷按鈕-------");
            remoteController.UndoButtonWasPush();

            TVReciver tVReciver = new TVReciver();
            TVOnCommand tVOnCommand=new TVOnCommand(tVReciver);
            TVOffCommand tVOffCommand = new TVOffCommand(tVReciver);
            remoteController.SetCommand(1, tVOnCommand, tVOffCommand);

            Console.WriteLine("------按下開啟電視按鈕-------");
            remoteController.OnButtonWasPushed(1);
            Console.WriteLine("------按下關閉電視按鈕-------");
            remoteController.OffButtonWasPushed(1);
            Console.WriteLine("------按下撤銷按鈕-------");
            remoteController.UndoButtonWasPush();
        }
        /*
            命令模式
            1. 在軟體中，常常需要對某些對象發起請求，但不知道請求的接收者是誰，也不知道被請求的操作是哪個
            2. 將 請求發送者者 從 請求接收者  解偶出來
            3. 將請求封裝程一個對象，可以用不同參數表示不同請求，也支持可撤銷命令的操作
            4. ex : 將軍發布命令，士兵去執行 (但將軍不會直接指派某某個士兵去幹嘛，而是直接下進攻命令)
                      其中會有幾個角色、 將軍、士兵、命令(連接將軍跟士兵)
            5. 角色
                Invoker : 調用者
                Receiver : 接收者，執行操作的人
                Command : 接口or 抽象類，需要執行的命令都在這裡
                ConcreteCommand  : 命令，實現了Command 街口，持有接收對象，
                                    將接收者對像與一個動作綁定，調用接收者相應的操作，實現excute

            注意事項與細節
            1. 非常容易設計命令Queue，只要把命令對像放到隊列，就可以多線程的執行命令
            2. 容易實現隊請求的撤銷

            缺點:
            1. 會產生過多的命令類 (以家電為例，一個家電就要 onCommamd、offCommand(命令更多就會更多)、在一個Receiver)
            2. NoCommand 也是一個設置模式，省去判斷空命令的操作

            應用場景: 模擬cmd、訂單的撤銷與恢復 

            需求
            有一套智能家電，可以用app 控制，但是家電都來自不同廠商，要下載很多APP
            希望可以只用一個APP控制所有家電
            => 命令模式
            將 動作請求者(APP) 從 動作執行者(家電)  解偶出來
        
        */


        //命令接口
        public interface ICommand
        {
            public void Excute();
            public void Undo();
        }

        //-------電燈----------
        public class LightOnCommand : ICommand
        {
            LightReciver _light;

            public LightOnCommand(LightReciver light)
            {
                _light = light;
            }

            //到底調用recevier 的哪個操作，由業務邏輯決定
            public void Excute()
            {
                _light.On();
            }

            public void Undo()
            {
                _light.Off();
            }
        }

        public class LightOffCommand : ICommand
        {
            LightReciver _light;

            public LightOffCommand(LightReciver light)
            {
                _light = light;
            }

            //到底調用recevier 的哪個操作，由業務邏輯決定
            public void Excute()
            {
                _light.Off();
            }

            public void Undo()
            {
                _light.On();
            }
        }

        //省去空命令的判斷，調用空命令時，對像什麼都不做
        public class NoCommand : ICommand
        {
            //空執行，用於初始化
            public void Excute()
            {               
            }

            public void Undo()
            {                
            }
        }

        public class LightReciver
        {
            public void On()
            {
                Console.WriteLine("電燈打開了");
            }

            public void Off()
            {
                Console.WriteLine("電燈關閉了");
            }
        }

        //-------電燈----------


        //-------電視----------
        public class TVOnCommand : ICommand
        {
            TVReciver _TV;

            public TVOnCommand(TVReciver TV)
            {
                _TV = TV;
            }

            //到底調用recevier 的哪個操作，由業務邏輯決定
            public void Excute()
            {
                _TV.On();
            }

            public void Undo()
            {
                _TV.Off();
            }
        }

        public class TVOffCommand : ICommand
        {
            TVReciver _TV;

            public TVOffCommand(TVReciver TV)
            {
                _TV = TV;
            }

            //到底調用recevier 的哪個操作，由業務邏輯決定
            public void Excute()
            {
                _TV.Off();
            }

            public void Undo()
            {
                _TV.On();
            }
        }
       
        public class TVReciver
        {
            public void On()
            {
                Console.WriteLine("電視打開了");
            }

            public void Off()
            {
                Console.WriteLine("電視關閉了");
            }
        }

        //-------電視----------

        public class RemoteController
        {
            List<ICommand> onCommands;
            List<ICommand> offCommands;

            //執行撤銷的命令
            ICommand undoCommand;

            public RemoteController()
            {
                onCommands = new List<ICommand>();
                offCommands = new List<ICommand>();
            }

            //方便設置命令
            public void SetCommand(int no,ICommand onCommand, ICommand offCommand)
            {
                onCommands.Insert(no, onCommand);
                offCommands.Insert(no, offCommand);

            }

            //按下開按鈕
            public void OnButtonWasPushed(int no)
            {
                //找到你按下的開按鈕，並調用對應的方法
                onCommands[no].Excute();
                //紀錄這次的操作，用於撤銷
                undoCommand = onCommands[no];

            }

            //按下關按鈕
            public void OffButtonWasPushed(int no)
            {
                //找到你按下的開按鈕，並調用對應的方法
                offCommands[no].Excute();
                //紀錄這次的操作，用於撤銷
                undoCommand = offCommands[no];

            }

            //撤銷按鈕
            public void UndoButtonWasPush()
            {
                undoCommand.Undo();
            }
        }
    }
}
