using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.SingleResponsibility
{
    public class SingleRespbilty3
    {
        public static void Run()
        {
            Vehicle2 vehicle = new Vehicle2();
            vehicle.Run("機車");
            vehicle.Run("汽車");
            vehicle.Fly("飛機");
        }
    }

    //方式3
    //雖然沒有用類分開，只是增加方法
    //雖然沒在類上遵守，但在方法上仍遵守單一職責原則
    public class Vehicle2
    {
        
        public void Run(string vehicle)
        {
            Console.WriteLine(vehicle + "在公路上運行");
        }

        public void Fly(string vehicle)
        {
            Console.WriteLine(vehicle + "在天上運行");
        }


    }
}
