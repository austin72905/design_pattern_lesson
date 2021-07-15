using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Prototype
{
    class Prototype2
    {
        public static void Run()
        {
            Sheep sheep = new Sheep("tom", 1, "白色");
            Sheep sheep1 = (Sheep)sheep.Clone();
            Console.WriteLine("sheep=" + sheep);
            Console.WriteLine("sheep1=" + sheep1);

        }

        public class Sheep:ICloneable
        {
            private string Name;
            private int Age;
            private string Color;

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
                return $"sheep[name={this.Name},age={this.Age},color={this.Color}]";
            }
        }
    }
}
