using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Iterator
{
    class Iterator1
    {

        public static void Run()
        {
            
            Iterator iterator;
            College college = new ComputerCollege();
            iterator = (Iterator)college.GetEnumerator();

            

            Console.WriteLine($"======{college.GetName()}======");
            //輸出學院的系
            while (iterator.MoveNext())
            {
                Department item = (Department)iterator.Current();
                Console.WriteLine(item.Name);
            }


            College sociatyCollege = new SociatyCollege();
            iterator = (Iterator)sociatyCollege.GetEnumerator();

            Console.WriteLine($"======{sociatyCollege.GetName()}======");
            //輸出學院的系
            while (iterator.MoveNext())
            {
                Department item = (Department)iterator.Current();
                Console.WriteLine(item.Name);
            }

        }

        /*
            迭代器模式 (基本上用不到，因為LIST 那些都有實作了，當作觀念看就好)
            參考資料: https://refactoringguru.cn/design-patterns/iterator/csharp/example
                     https://www.cnblogs.com/zhili/p/IteratorPattern.html

            定義
            如果集合的元素是用不同的方式實現
            ex: 數組、List，當客戶端要遍歷這些元素時
            就要使多種遍歷方式，還會暴露元素的內部結構，此時可以考慮迭代器模式
            
            => 提供這些集合元素一個統一街口，用一致的方法遍歷集合元素，即: 不暴露內部結構
            
            數據跟遍歷方式分開

            優點:
            1. 提供一個統一的方法遍歷，客戶端不用考慮聚合的類型，用一種方法就可以遍歷對象了
            2. 隱藏聚合內部的結構，只要能夠取到迭代器，不會知道聚合的具體組成(是list 還是array)
            3. 提供一種設計思想，一個類應該只有一個引起變化的原因(單一職責模式)，
                 分成 具體集合類、迭代器類 => 將
                (1)管理對象集合
                (2)遍歷對象集合
                職責分開 => 之後集合改變，只會影響到聚合對象; 遍歷方式改變，只會影響到迭代器
            4. 如果要展示一組相似對象，或是遍歷一組相同對象時使用，適合使用迭代器模式

            缺點:
            每個聚合對象都要一個迭代器，不好管理

            需求:
            要在一個頁面展示出學校的院系組成、一個學校有多個學院、一個學院有多個系

            傳統: 繼承寫法  學校:學院: 系   (以組織大小區分)
            缺點: 不好遍歷

            

            
         
        
        */

        //迭代器
        public abstract class Iterator: IEnumerator
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
        public class ComputerCollege: College
        {
            Department[] _departments;
            //保存數組對象個數
            int departmentsCount = 0;

            public ComputerCollege()
            {
                _departments=new Department[5];
                AddDepartment("JAVA專業", "JAVA專業");
                AddDepartment("C#專業", "C#專業");
                AddDepartment("PHP專業", "PHP專業");
                AddDepartment("GOLANG專業", "GOLANG專業");
            }

            //實現IEnumerable 裡的方法，返回一個迭代器
            public override IEnumerator GetEnumerator()
            {
                return new ComputerCollegeIterator(_departments);
            }

            //自己新增的方法
            public override string GetName()
            {
                //返回名字
                return "計算機學院";
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
            

            public SociatyCollege()
            {
                _departments =new List<Department>();
                AddDepartment("經濟學系", "經濟學系");
                AddDepartment("心理學系", "心理學系");
                AddDepartment("經濟學系", "經濟學系");
                AddDepartment("政治學系", "政治學系");
            }

            //實現IEnumerable 裡的方法，返回一個迭代器
            public override IEnumerator GetEnumerator()
            {
                return new SociatyCollegeIterator(_departments);
            }

            //自己新增的方法
            public override string GetName()
            {
                //返回名字
                return "社會學院";
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
            //這裡需要知道系Department 是以何種方式存放
            Department[] _departments;
            //遍歷的位置
            private int _position = 0;

            public ComputerCollegeIterator(Department[] departments)
            {
                _departments = departments;
            }

            public override bool MoveNext()
            {
                //判斷是否有下一個
                if(_position>=_departments.Length|| _departments[_position] == null)
                {
                    return false;
                }

                return true;
            }

            public override object Current()
            {
                Department department = _departments[_position];
                _position += 1;
                return department;
            }

            public override void Reset()
            {
                _position = 0;
            }

        }

        //具體迭代器
        public class SociatyCollegeIterator: Iterator
        {
            //這裡需要知道系Department 是以何種方式存放
            List<Department> _departments;
            //索引
            private int index = -1;

            public SociatyCollegeIterator(List<Department> departments)
            {
                _departments = departments;
            }

            public override bool MoveNext()
            {
                //判斷是否有下一個
                if (index >= _departments.Count-1 )
                {
                    return false;
                }
                //移動到下一個
                index += 1;
                return true;
            }

            public override object Current()
            {               
                return _departments[index];
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
            public Department(string name,string desc)
            {
                Name = name;
                Desc = desc;
            }

        }
    }
}
