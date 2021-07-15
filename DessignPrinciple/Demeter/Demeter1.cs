using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.Demeter
{
    class Demeter1
    {
        public static void Run()
        {
            SchoolManager schoolManager = new SchoolManager();
            schoolManager.PrintAllEmployee(new CollegeManager());
        }

        /*
         
        迪米特法則
        1. 一個對象應該對其他對象保持最少的了解
        2. 類與類關係越密切，偶和度越大
        3. 又稱最少知道原則，對依賴的類不管多複雜都儘量將邏輯封裝在類的內部，對外提供public就好
        4. 還有個更簡單的定義: 只與直接的朋友通信
        5. 直接的朋友: 每個對象與其他對像有耦合關係，
            只要有耦合，就是朋友關係，耦合有 依賴、關聯、組合、聚合
            出現在成員變量、方法參數、方法返回值 的 類 為直接朋友
            出現在局部變量的類不是直接的朋友，陌生的類最好不要以局部變量的形式出現在類的內部
         

        細節:
        1. 降低耦合，不是完全避免
         */

        //需求: 有個學校，下屬有各個學院和總部，要求打印學校總部員工ID，和學院員工ID

        //方法1
        //總部員工ID
        class Employee
        {
            private string _Id;

            public Employee(string id)
            {
                _Id = id;
            }

            public string Id
            {
                get
                {
                    return _Id;
                }
            }
        }

        class CollegeEmployee
        {
            private string _Id;

            public CollegeEmployee(string id)
            {
                _Id = id;
            }

            public string Id
            {
                get
                {
                    return _Id;
                }
            }

        }


        //管理學院員工的類
        class CollegeManager
        {
            //返回學院所有員工
            public List<CollegeEmployee> GetAllEmployee()
            {
                List<CollegeEmployee> list = new List<CollegeEmployee>();
                for(var i=0;i<10; i++)
                {
                    CollegeEmployee collegeEmployee = new CollegeEmployee("學院員工ID="+i);
                    list.Add(collegeEmployee);
                }

                return list;
            }
        }

        //學校管理類
        /*
        分析學校管理類 的直接朋友類
        Employee (方法返回值)
        CollegeManager (方法參數)


        非直接朋友 (違反了 迪米特法則)
        CollegeEmployee (局部變量)
        Employee (局部變量)
         
         */
        class SchoolManager
        {
            //返回學校總部所有員工
            public List<Employee> GetAllEmployee()
            {
                List<Employee> list = new List<Employee>();
                for (var i = 0; i < 5; i++)
                {
                    Employee employee = new Employee("學校總部員工ID=" + i);
                    list.Add(employee);
                }

                return list;
            }

            //輸出學校總部和學院員工信息的方法
            public void PrintAllEmployee(CollegeManager collegeManager)
            {
                List<CollegeEmployee> list = collegeManager.GetAllEmployee();
                Console.WriteLine("-------學院員工--------");
                foreach(var i in list)
                {
                    Console.WriteLine(i.Id);
                }

                List<Employee> list2 = this.GetAllEmployee();
                Console.WriteLine("-------學校總部員工--------");
                foreach (var i in list2)
                {
                    Console.WriteLine(i.Id);
                }
            }
        }
    }
}
