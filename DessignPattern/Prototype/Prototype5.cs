using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Prototype
{
    class Prototype5
    {
        /*
        深拷貝
        方法2

        序列化 (推薦)

        
        
         */

        public static void Run()
        {
            Sheep sheep = new Sheep("tom", 1, "白色");
            sheep.Frined = new Sheep("shelly", 2, "黑色");
            Sheep sheep1 = (Sheep)sheep.Clone();
            Sheep sheep2 = (Sheep)sheep.Clone();
            Sheep sheep3 = (Sheep)sheep.Clone();
            Sheep sheep4 = (Sheep)sheep.Clone();
            Console.WriteLine("sheep=" + sheep);
            Console.WriteLine("sheep1=" + sheep1);
            Console.WriteLine("sheep2=" + sheep2);
            Console.WriteLine("sheep3=" + sheep3);
            Console.WriteLine("sheep4=" + sheep4);
            

        }

        //方法2
        [Serializable]
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

            //序列化的方法
            public object Clone()
            {
                Sheep sheep;
                //先把物件序列化成 二進制數據流 (會幫你把引用數據類型的屬性也複製)
                //再把他反序列化成物件
                using (MemoryStream mstream = new MemoryStream())
                {
                    BinaryFormatter bfs = new BinaryFormatter();
                    bfs.Serialize(mstream, this);
                    mstream.Seek(0, SeekOrigin.Begin);
                    sheep = (Sheep)bfs.Deserialize(mstream);
                }
                    
                
                
                return sheep;
            }

            public override string ToString()
            {
                return $"sheep[name={this.Name},age={this.Age},color={this.Color},Frined={this.Frined.GetHashCode()}]";
            }
        }
        
    }
}
