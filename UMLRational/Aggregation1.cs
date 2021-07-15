using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.UMLRational
{
    class Aggregation1
    {
        /*
        聚合

        表示整體跟部分的關係 整體與部分是可以分去開的，聚合是關聯關係的特例，具有導航姓、多重姓
        ex: 電腦由 顯示器、滑鼠、鍵盤組合而成，組成的配建是可以重電腦分里出來的

        不能分開就是組合
         */

        public class Computer
        {
            Mouse mouse;
            KeyBoard keyBoard;
        }

        public class Mouse
        {

        }

        public class KeyBoard
        {

        }
    }
}
