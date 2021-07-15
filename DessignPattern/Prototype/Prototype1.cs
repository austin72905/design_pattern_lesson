using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Prototype
{
    class Prototype1
    {
        /*
        原型模式(要注意淺拷貝、深拷貝，默認是淺拷貝)

        1. 用原型實例指定創建對象的種類，且通過考被這些原型創建新的對象
        2. 工作原理: 通過將一個原型對象傳給要準備創建的對象，
           這個要創建的對象向原型對向拷貝他們自己來創建

        缺點:
        每個類都配一個克隆方法，對已有的類進行改造時，要修改其源代碼，違背OCP原則，要注意下
        
        需求:
        克隆羊
        現在有隻羊tom，姓名為tom、年齡為1、顏色為白色，請用程序創建一隻與他屬性完全相同的羊
         
        */

        //傳統寫法
        //class new 一個實體，取得每個屬性的值，要幾次有幾次 easy
        /*
        優點:好理解
        缺點：每次創建新對象都要重新獲取他的屬性，如果創建對象複雜，效率會很低
        總是需要重新初始化對象，而不是動態獲取對象運行時的狀態，不夠靈活

        思路：
        使用object 類 裡 clone 方法，可以將對象復置一份，但是該類需要實現一個ICloneable接口=>原型模式
        */
        public class Sheep
        {
            private string Name;
            private int Age;
            private string Color;

            public Sheep(string name,int age,string color)
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
        }
    }
}
