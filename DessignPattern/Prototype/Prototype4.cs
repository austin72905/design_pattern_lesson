using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Prototype
{
    class Prototype4
    {
        /*
        深拷貝 

        實現:
        1. 重寫clone
        2. 對象序列化
         
        */

        public static void Run()
        {
            Sheep sheep = new Sheep("tom", 1, "白色");
            sheep.Frined = new Sheep("shelly", 2, "黑色");
            Sheep sheep1 = (Sheep)sheep.Clone();
            Console.WriteLine("sheep=" + sheep);
            Console.WriteLine("sheep1=" + sheep1);

        }

        //方法1
        public class Sheep : ICloneable
        {
            private string Name;
            private int Age;
            private string Color;
            public Sheep Frined;

            public Sheep(string name, int age, string color)
            {
                this.Name = name;
                this.Age = age;
                this.Color = color;
            }



            public string GetName()
            {
                return this.Name;
            }



            public int GetAge()
            {
                return this.Age;
            }



            public string GetColor()
            {
                return this.Color;
            }

            //使用默認的clone方法
            public object Clone()
            {
                //先對基本數據類型 淺複製
                Sheep sheep=(Sheep) this.MemberwiseClone();
                //在對引用數據類型淺複製
                sheep.Frined = (Sheep)sheep.Frined.MemberwiseClone();
                return sheep;
            }

            public override string ToString()
            {
                return $"sheep[name={this.Name},age={this.Age},color={this.Color},Frined={this.Frined.GetHashCode()}]";
            }
        }
    }
}
