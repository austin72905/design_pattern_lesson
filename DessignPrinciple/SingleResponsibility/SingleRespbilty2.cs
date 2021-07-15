using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.SingleResponsibility
{
    public class SingleRespbilty2
    {
        public static void Run()
        {
            RoadVehicle roadvehicle = new RoadVehicle();
            roadvehicle.Run("機車");
            roadvehicle.Run("汽車");
            AirVehicle airvehicle = new AirVehicle();
            airvehicle.Run("飛機");
        }
        
    }

    //方案2 遵守單一職責原則
    // 但是改動很大，要將類分解同時要改動客戶端
    //改進: 直接改動Vehicle
    public class RoadVehicle
    {
        public void Run(string vehicle)
        {
            Console.WriteLine(vehicle + "在路上運行");
        }
    }

    public class AirVehicle
    {
        public void Run(string vehicle)
        {
            Console.WriteLine(vehicle + "在天上運行");
        }

    }

    public class WaterVehicle
    {
        public void Run(string vehicle)
        {
            Console.WriteLine(vehicle + "在海上運行");
        }

    }
}
