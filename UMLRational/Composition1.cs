using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.UMLRational
{
    class Composition1
    {
        /*
        組合關係
        整體與部分不可分開
        new 就分不開了
        ex: 人的頭

        如果刪除一個類，另一個類連同被刪除(級聯刪除)，也可視為組合關係
        */
        public class Person
        {
            Head mouse =new Head();
            Hands keyBoard =new Hands();
        }

        public class Head
        {

        }

        public class Hands
        {

        }
    }
}
