using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.UMLRational
{
    class Association1
    {
        /*
        關聯關係
        
        導航姓:具有雙向或單項關係
        */

        //單向
        public class Person
        {
            IDCard card;
        }
        public class IDCard
        {

        }

        //雙向
        public class Sex
        {
            Age age;
        }

        public class Age
        {
            Sex sex;
        }
    }
}
