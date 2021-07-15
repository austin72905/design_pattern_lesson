using DesignPatternLesson.Demeter;
using DesignPatternLesson.DependenceInversion;
using DesignPatternLesson.DessignPattern.Adapter;
using DesignPatternLesson.DessignPattern.Bridge;
using DesignPatternLesson.DessignPattern.Builder;
using DesignPatternLesson.DessignPattern.Chain_of_Responsibility;
using DesignPatternLesson.DessignPattern.Command;
using DesignPatternLesson.DessignPattern.Composite;
using DesignPatternLesson.DessignPattern.Decorator;
using DesignPatternLesson.DessignPattern.Facade;
using DesignPatternLesson.DessignPattern.Factory;
using DesignPatternLesson.DessignPattern.Flyweight;
using DesignPatternLesson.DessignPattern.Interpreter;
using DesignPatternLesson.DessignPattern.Iterator;
using DesignPatternLesson.DessignPattern.Mediator;
using DesignPatternLesson.DessignPattern.Memento;
using DesignPatternLesson.DessignPattern.Observer;
using DesignPatternLesson.DessignPattern.Prototype;
using DesignPatternLesson.DessignPattern.Proxy;
using DesignPatternLesson.DessignPattern.Singleton;
using DesignPatternLesson.DessignPattern.State;
using DesignPatternLesson.DessignPattern.Strategy;
using DesignPatternLesson.DessignPattern.Template;
using DesignPatternLesson.DessignPattern.Visitor;
using DesignPatternLesson.InterfaceSegregation;
using DesignPatternLesson.LisKov;
using DesignPatternLesson.OpenClosed;
using DesignPatternLesson.SingleResponsibility;
using System;

namespace DesignPatternLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            //單一職責原則
            //方案1
            //SingleRespbilty1.Run();
            //方案2
            //SingleRespbilty2.Run();

            //接口隔離原則
            //InterfaceSegregation2.Run();

            //依賴反轉原則
            //方案1
            //DependenceInversion1.Run();
            //方案2
            //DependenceInversion2.Run();

            //以接口傳遞
            //DependenceInversion3.Run();

            //以構造方法傳遞
            //DependenceInversion4.Run();
            //透過setter
            //DependenceInversion5.Run();

            //里式替換原則
            //LisKov1.Run();

            //LisKov2.Run();

            //開閉原則
            //方案1
            //OpenClosed1.Run();
            //方案2
            //OpenClosed2.Run();

            //迪米特法則
            //Demeter1.Run();

            //設計模式
            //單例 餓漢式
            //Singleton1.Run();
            //懶漢式 (線程不安全)
            //Singleton3.Run();
            //懶漢式 (線程安全，同步方法)
            //Singleton4.Run();


            // 工廠模式
            //簡單工廠模式
            //傳統寫法
            //SimpleFactory1.Run();
            //方法1
            //SimpleFactory2.Run();

            //工廠方法模式
            //FactoryMethod1.Run();

            //抽象工廠模式
            //AbsFactory1.Run();


            //原型模式
            //Prototype2.Run();
            //淺拷貝
            //Prototype3.Run();
            //深拷貝1
            //Prototype4.Run();
            //深拷貝2 (推薦)
            //Prototype5.Run();

            //建造者模式
            //Builder2.Run();

            //適配器模式
            //類適配器
            //ClassAdapter.Run();
            //對像適配器
            //ObjectAdapter.Run();
            //接口適配器
            //InterfaceAdapter.Run();

            //橋接模式
            //Bridge1.Run();

            //裝飾者模式
            //Decorator1.Run();

            //組合模式
            //Composite1.Run();
            //外觀模式
            //Facade1.Run();
            //享元模式
            //Flyweight1.Run();

            //代理模式
            //靜態代理模式
            //StaticProxy.Run();
            //動態代理模式
            //DynamicProxy.Run();

            //模板模式
            //Template1.Run();

            //命令模式
            //Command1.Run();

            //訪問者模式
            //Visitor1.Run();

            //迭代器模式
            //Iterator1.Run();
            // 可用foreach 模式 (推薦)
            //Iterator2.Run();

            //觀察者模式
            //Observer1.Run();

            //中介者模式
            //Mediator1.Run();

            //備忘錄模式
            //Memento1.Run();
            //Memento2.Run();

            //解釋器模式
            //Interpreter1.Run();

            //狀態模式
            //State1.Run();
            //策略模式
            //Strategy2.Run();

            //職責鍊模式
            ChainOfResponsibility1.Run();

            Console.ReadKey();
        }
    }
}
