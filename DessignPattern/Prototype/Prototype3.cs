using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Prototype
{
    class Prototype3
    {
        /*
        淺拷貝
        
        1.當class 裡面有"引用數據類型"的的屬性時，clone只會複製他的指針地址(複製出來的對象"引用數據類型"的屬性會指向同個地址)
        (list、object、dictionary...)

        深拷貝

        連引用數據類型的屬性，也會複製一份
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
                //object 物件的 淺複製方法
                return this.MemberwiseClone();
            }

            public override string ToString()
            {
                return $"sheep[name={this.Name},age={this.Age},color={this.Color},Frined={this.Frined.GetHashCode()}]";
            }
        }
    }
}
