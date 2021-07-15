using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.UMLRational.Dependence
{
    public class Dependence1
    {
        /*
        依賴 (其他實現、泛化都是依賴關係的特例)

        類中用到對方
        類的成員屬性
        方法的返回類型
        在方法中使用到 
         */

        public class PersonService
        {

            private PersonDao PersonDao;
            public void Save(Person p) { }

            public IDCard GetIDCard(int id) { return new IDCard(); }

            public void Modify()
            {
                Department department = new Department();
            }

        }

        public class PersonDao { }

        public class IDCard { }

        public class Person { }

        public class Department { }
    }

    

    
}
