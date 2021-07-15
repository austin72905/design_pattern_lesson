using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Iterator
{
    class Iterator2
    {
        public static void Run()
        {
            SociatyCollege sociatyCollege = new SociatyCollege();
            

            sociatyCollege.AddDepartment("經濟學系", "經濟學系");
            sociatyCollege.AddDepartment("心理學系", "心理學系");
            sociatyCollege.AddDepartment("經濟學系", "經濟學系");
            sociatyCollege.AddDepartment("政治學系", "政治學系");

            Console.WriteLine($"======{sociatyCollege.GetName()}======");
            foreach(Department item in sociatyCollege)
            {
                Console.WriteLine(item.Name);
            }


            ComputerCollege computerCollege = new ComputerCollege();
            Console.WriteLine($"======{computerCollege.GetName()}======");
            computerCollege.AddDepartment("JAVA專業", "JAVA專業");
            computerCollege.AddDepartment("C#專業", "C#專業");
            computerCollege.AddDepartment("PHP專業", "PHP專業");
            computerCollege.AddDepartment("GOLANG專業", "GOLANG專業");

            foreach (Department item in computerCollege)
            {
                Console.WriteLine(item.Name);
            }

            //第二種寫法還是能夠用iterator 遍歷
            Iterator iterator;
            iterator = (Iterator)computerCollege.GetEnumerator();
            Console.WriteLine($"======{computerCollege.GetName()}======");
            //輸出學院的系
            while (iterator.MoveNext())
            {
                Department item = (Department)iterator.Current();
                Console.WriteLine(item.Name);
            }
        }
        /*
            把iterator 封裝到更裡面、可使用foreach 的寫法 
            實際操作的元素 Department 只存在 具體集合類，耦合性更低了
            
        */

        
        //迭代器
        public abstract class Iterator : IEnumerator
        {
            object IEnumerator.Current => Current();

            public abstract object Current();
            public abstract bool MoveNext();

            public abstract void Reset();

        }

        //抽象聚合類
        public abstract class College : IEnumerable
        {
            //實現IEnumerable 裡的方法，返回一個迭代器
            public abstract IEnumerator GetEnumerator();

            //自己新增的方法
            public abstract string GetName();

            //增加系的方法
            public abstract void AddDepartment(string name, string desc);

        }

        //具體聚合類
        public class ComputerCollege : College
        {
            Department[] _departments;
            //保存數組對象個數
            int departmentsCount = 0;

            public ComputerCollege()
            {
                _departments = new Department[5];
                //AddDepartment("JAVA專業", "JAVA專業");
                //AddDepartment("C#專業", "C#專業");
                //AddDepartment("PHP專業", "PHP專業");
                //AddDepartment("GOLANG專業", "GOLANG專業");
            }

            //實現IEnumerable 裡的方法，返回一個迭代器
            public override IEnumerator GetEnumerator()
            {
                return new ComputerCollegeIterator(this);
            }

            //自己新增的方法
            public override string GetName()
            {
                //返回名字
                return "計算機學院";
            }


            public Department[] GetDepartments()
            {
                return _departments;
            }

            //增加系的方法
            public override void AddDepartment(string name, string desc)
            {
                Department department = new Department(name, desc);
                _departments[departmentsCount] = department;
                departmentsCount += 1;
            }
        }

        //具體聚合類
        public class SociatyCollege : College
        {
            List<Department> _departments;
            //但跟但這直接訪問List<Department> 有什麼差異?

            public SociatyCollege()
            {
                _departments = new List<Department>();               
            }

            //實現IEnumerable 裡的方法，返回一個迭代器
            public override IEnumerator GetEnumerator()
            {
                return new SociatyCollegeIterator(this);
            }

            //自己新增的方法
            public override string GetName()
            {
                //返回名字
                return "社會學院";
            }

            public List<Department> GetDepartments()
            {
                return _departments;
            }

            //增加系的方法
            public override void AddDepartment(string name, string desc)
            {
                Department department = new Department(name, desc);
                _departments.Add(department);

            }
        }


        
        //具體迭代器
        public class ComputerCollegeIterator : Iterator
        {
            
            private ComputerCollege _computerCollege;
            //遍歷的位置
            private int _position = 0;

            public ComputerCollegeIterator(ComputerCollege computerCollege)
            {
                _computerCollege = computerCollege;
            }

            public override bool MoveNext()
            {
                //判斷是否有下一個
                if (_position >= _computerCollege.GetDepartments().Length || _computerCollege.GetDepartments()[_position] == null)
                {
                    return false;
                }

                return true;
            }

            public override object Current()
            {
                Department department = _computerCollege.GetDepartments()[_position];
                _position += 1;
                return department;
            }

            public override void Reset()
            {
                _position = 0;
            }

        }

        //具體迭代器
        public class SociatyCollegeIterator : Iterator
        {
            
            //把具體集合類放進來
            private SociatyCollege _sociatyCollege;

            //索引
            private int index = -1;

            public SociatyCollegeIterator(SociatyCollege sociatyCollege)
            {
                _sociatyCollege = sociatyCollege;
            }

            public override bool MoveNext()
            {
                //判斷是否有下一個
                if (index >= _sociatyCollege.GetDepartments().Count - 1)
                {
                    return false;
                }
                //移動到下一個
                index += 1;
                return true;
            }

            public override object Current()
            {
                return _sociatyCollege.GetDepartments()[index];
            }

            public override void Reset()
            {
                index = -1;
            }
        }       

        //系
        public class Department
        {
            public string Name { get; set; }
            public string Desc { get; set; }
            public Department(string name, string desc)
            {
                Name = name;
                Desc = desc;
            }

        }
    }
}
