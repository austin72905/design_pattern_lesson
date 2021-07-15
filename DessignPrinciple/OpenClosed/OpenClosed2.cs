using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.OpenClosed
{
    class OpenClosed2
    {
        public static void Run()
        {
            GraphEdtr graphEdtr = new GraphEdtr();
            graphEdtr.drawShape(new Rectan());
            graphEdtr.drawShape(new Circle());
        }

        //方法2
        //解決: 將Shape 類做成抽象類，並提供一個draw 抽象方法，讓子類去實現即可
        //     使用方的代碼不用修改

        //跟 DependenceInversion2 方法參數接口有點像

        //使用方
        class GraphEdtr
        {
            public void drawShape(Shape s)
            {
                s.draw();
            }

        }

        abstract class Shape
        {
            public abstract void draw();
        }

        class Rectan : Shape
        {           

            public override void draw()
            {
                Console.WriteLine("draw Rec");
            }
        }

        class Circle : Shape
        {           

            public override void draw()
            {
                Console.WriteLine("draw Circle");
            }
        }
    }
}
