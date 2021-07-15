using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Builder
{
    class Builder2
    {
        //Client
        public static void Run()
        {
            //蓋普通房子
            CommonHouse commonHouse = new CommonHouse();

            //準備指揮者
            HouseDirector houseDirector = new HouseDirector(commonHouse);

            //完成蓋房子
            houseDirector.StartBuild();

            //蓋高樓
            HighBuilding highBuilding = new HighBuilding();

            //重建建造者
            houseDirector.SetHouseBuilder(highBuilding);

            houseDirector.StartBuild();

        }
        /*
        產品本身的屬性封裝在House裡面
        
        製造的過程放在HouseBuilder

        把產品跟製造過程分開
        */
        //Product
        //產品
        public class House
        {
            private string Basic;
            private string Walls;
            private string Roof;

            public string GetBasic()
            {
                return this.Basic;
            }
            public string GetWalls()
            {
                return this.Walls;
            }
            public string GetRoof()
            {
                return this.Roof;
            }

            public void SetBasic(string basic)
            {
                this.Basic = basic;
            }

            public void SetWalls(string walls)
            {
                this.Walls = walls;
            }
            public void SetRoof(string roof)
            {
                this.Roof = roof;
            }
        }

        //Builder
        //寫明建造的流程
        public abstract class HouseBuilder
        {
            //產品本身
            protected House house = new House();

            //打地基
            public abstract void BuildBasic();

            //建造牆
            public abstract void BuildWalls();

            //蓋屋頂
            public abstract void PutRoof();

            //建造主要方法(將產品返回)
            public House Build()
            {
                return house;

            }
        }

        public class CommonHouse : HouseBuilder
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

        public class HighBuilding : HouseBuilder
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

        public class HouseDirector
        {
            HouseBuilder _houseBuilder;

            //構造器傳入方法
            public HouseDirector(HouseBuilder houseBuilder)
            {
                _houseBuilder = houseBuilder;
            }

            //如果要換建造過程調用這個換就好
            //透過setter傳入
            public void SetHouseBuilder(HouseBuilder houseBuilder)
            {
                _houseBuilder = houseBuilder;
            }


            //怎麼建房流程，交給指揮者
            //不一定要先打地基，可以自己決定

            public House StartBuild()
            {
                _houseBuilder.BuildBasic();
                _houseBuilder.BuildWalls();
                _houseBuilder.PutRoof();

                return _houseBuilder.Build();
            }
            
        }
    }
}
