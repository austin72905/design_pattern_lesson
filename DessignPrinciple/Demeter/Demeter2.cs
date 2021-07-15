using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.Demeter
{
    class Demeter2
    {
        public static void Run()
        {
            SchoolManager schoolManager = new SchoolManager();
            schoolManager.PrintAllEmployee(new CollegeManager());
        }

        

        //方法2
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
                for (var i = 0; i < 10; i++)
                {
                    CollegeEmployee collegeEmployee = new CollegeEmployee("學院員工ID=" + i);
                    list.Add(collegeEmployee);
                }

                return list;
            }

            //輸出員工的訊息
            public void PrintAllEmployee()
            {
                List<CollegeEmployee> list = GetAllEmployee();
                Console.WriteLine("-------學院員工--------");
                foreach (var i in list)
                {
                    Console.WriteLine(i.Id);
                }


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

        解決: CollegeEmployee封裝到CollegeManager
         
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
                collegeManager.PrintAllEmployee();


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
