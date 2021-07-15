using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.SingleResponsibility
{
    //單一職責原則
    //細節
    //1. 降低類的複雜度，一個類只負責一個職責(通常都需要遵守)
    //2. 降低變更代碼風險
    //3. 類夠簡單，才可以只在方法上遵守(方法3)
    public class SingleRespbilty1
    {
        public static void Run()
        {
            Vehicle vehicle = new Vehicle();
            vehicle.Run("機車");
            vehicle.Run("汽車");
            vehicle.Run("飛機");
        }
    }

    //交通工具類
    public class Vehicle
    {
        //在Run方法中，違反單一職責原則(飛機在公路上運行 不合理)
        public void Run(string vehicle)
        {
            Console.WriteLine(vehicle + "在公路上運行");
        }

        //依據交通功率運行的不同，分成不同類即可
    }
}
