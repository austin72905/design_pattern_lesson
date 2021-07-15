using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Facade
{
    class Facade1
    {
        public static void Run()
        {
            HomeTheaterFacade homeTheaterFacade=new HomeTheaterFacade();
            homeTheaterFacade.Ready();
            homeTheaterFacade.Play();
            homeTheaterFacade.Ready();
            homeTheaterFacade.End();
        }
        /*
            

            需求
            有一個家庭影院，裡面有DVD撥放器、自動螢幕、爆米花機、立體聲..
            開始看電影時要打開各個裝備，結束後要關掉

            傳統: 每個設備都是一個類，在客戶端調用每個類
            缺點: 
            1. 每個設備都有自己的遙控器(每個設備都有自己的操作)，操作很複雜
            2. 直接去調用每個對象，調用過程混亂，沒有清晰的流程

            => 定義一個高層接口，使客戶端只需跟這個街口調用，不用關心子系統的內部細節
            => 外觀摩式
            

            外觀模式(過程模式)
            1. 提供客戶端一個統一接口，使子系統(設備)更一調用
            2. 隱藏內部細節，內部自己互相調用不對外暴露
            3. 解決多個複雜接口帶來的使用困難，起到簡化客戶操作的作用
            
            細節
            1. 對外屏蔽了子系統的細節，因此降低客戶端對子系統使用的複雜性
            2. 客戶端跟子系統解偶，對子系統的模塊更易維護跟擴展
            3. 更好的劃分的訪問層次
            4. 當需要分層設計時，可以使用外觀模式
            5. 當維護一個遺留的大型系統，這個系統已經變得難以維護，可以通過建立一個Facade類，
                讓新系統與Facade 交互
            6. 不能過多或不合理的使用外觀模式，如果直接調用模塊好，就不要用外觀模式，
                以利於維護為目的 (子系統很少就直接調用就好了)
            
        */

        //Facade
        public class HomeTheaterFacade
        {
            //定義各個子系統對象
            private Popcorn popcorn;
            private Stereo stereo;
            private Screen screen;
            private DVDPlayer dVDPlayer;

            public HomeTheaterFacade()
            {
                this.popcorn = Popcorn.GetInstance();
                this.stereo = Stereo.GetInstance();
                this.screen = Screen.GetInstance();
                this.dVDPlayer = DVDPlayer.GetInstance();
            }

            public void Ready()
            {
                popcorn.On();
                popcorn.Pop();
                screen.On();
                screen.Down();
                stereo.On();
                dVDPlayer.On();
            }

            public void Play()
            {
                dVDPlayer.Play();
            }

            public void Pause()
            {
                dVDPlayer.Pause();
            }

            public void End()
            {
                popcorn.Off();
                screen.Up();
                stereo.Off();
                dVDPlayer.Off();
            }
        }

        public class DVDPlayer
        {
            //這邊使用餓漢式，也可不不要用，沒差
            private static DVDPlayer Instance = new DVDPlayer();

            //防止從外部被NEW
            private DVDPlayer()
            {

            }
            public static DVDPlayer GetInstance()
            {
                return Instance;
            }

            //功能
            public void On()
            {
                Console.WriteLine("dvd on");
            }
            public void Off()
            {
                Console.WriteLine("dvd off");
            }
            public void Play()
            {
                Console.WriteLine("dvd play");
            }
            public void Pause()
            {
                Console.WriteLine("dvd pause");
            }
        }

        public class Popcorn
        {
            //這邊使用餓漢式，也可不不要用，沒差
            private static Popcorn Instance = new Popcorn();

            //防止從外部被NEW
            private Popcorn()
            {

            }
            public static Popcorn GetInstance()
            {
                return Instance;
            }

            //功能
            public void On()
            {
                Console.WriteLine("popcorn on");
            }
            public void Off()
            {
                Console.WriteLine("popcorn off");
            }
            public void Pop()
            {
                Console.WriteLine("popcorn pop");
            }
            
        }

        public class Screen
        {
            //這邊使用餓漢式，也可不不要用，沒差
            private static Screen Instance = new Screen();

            //防止從外部被NEW
            private Screen()
            {

            }
            public static Screen GetInstance()
            {
                return Instance;
            }

            //功能
            public void On()
            {
                Console.WriteLine("Screen on");
            }
            public void Up()
            {
                Console.WriteLine("Screen up");
            }
            public void Down()
            {
                Console.WriteLine("Screen down");
            }
            
        }

        public class Stereo
        {
            //這邊使用餓漢式，也可不不要用，沒差
            private static Stereo Instance = new Stereo();

            //防止從外部被NEW
            private Stereo()
            {

            }
            public static Stereo GetInstance()
            {
                return Instance;
            }

            //功能
            public void On()
            {
                Console.WriteLine("Stereo on");
            }
            public void Off()
            {
                Console.WriteLine("Stereo off");
            }
            public void Up()
            {
                Console.WriteLine("Stereo up");
            }
            
        }


    }
}
