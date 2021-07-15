using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.CompositeReuse
{
    class CompositeReuse1
    {

        /*
        合成復用原則

        1. 儘量使用合成/聚合的方式，而不是使用繼承

        2. 如果只是想讓B類使用A類方法
            用繼承會讓耦合性很強

        3. 解決方法:
            (1) B新增一個方法(參數傳A) =>依賴 (合成)
            (2) B新增個屬性 A ，使用setter方法傳遞=> 聚合
            (3)B新增個屬性 A =new A() =>組合 (耦合會比聚合強一點)

     
         */
    }
}
