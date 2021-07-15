using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.OpenClosed
{
    class OpenClosed1
    {
        /*
         開閉原則(核心)
        1. 對擴展開放(對提供方)，對修改關閉(對使用方)，用抽象構建框架，用實現擴展細節
        2. 儘量通過擴展來發生變化，而不是修改已有的代碼
         */

        //需求: 畫圖型的功能

        //方式1
        //缺點:  
        //1. 違反OCP原則
        //2. 對使用方修改不是是關閉的
        //3. 要擴展時修改的很多ex: 要畫三角形

        //解決: 將Shape 類做成抽象類，並提供一個draw 抽象方法，讓子類去實現即可
        //     使用方的代碼不用修改

        public static void Run()
        {
            GraphEdtr graphEdtr = new GraphEdtr();
            graphEdtr.drawShape(new Rectan());
            graphEdtr.drawShape(new Circle());
        }

        //使用方
        class GraphEdtr
        {
            public void drawShape(Shape s)
            {
                //根據type 畫不同的圖形
                if(s.m_type == 1)
                {
                    drawRec(s);
                }else if (s.m_type == 2)
                {
                    drawCircle(s);
                }
            }

            public void drawRec(Shape s)
            {
                Console.WriteLine("draw Rec");
            }

            public void drawCircle(Shape s)
            {
                Console.WriteLine("draw Circle");
            }
        }

        class Shape
        {
            public int m_type;
        }

        class Rectan : Shape
        {
            public Rectan()
            {
                base.m_type = 1;
            }
        }

        class Circle : Shape
        {
            public Circle()
            {
                base.m_type = 2;
            }
        }
    }
}
