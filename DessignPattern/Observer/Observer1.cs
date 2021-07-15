using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Observer
{
    class Observer1
    {
        public static void Run()
        {
            //創建一個weatherData
            WeatherData weatherData = new WeatherData();


            //創建觀察者
            CurrentConditions currentConditions = new CurrentConditions();
            KimoSite kimoSite = new KimoSite();
            //註冊
            weatherData.RegisterObserver(currentConditions);
            weatherData.RegisterObserver(kimoSite);
            //更新數據
            Console.WriteLine("通知註冊的觀察者看訊息");
            //他會自己去通知所有已註冊的用戶
            weatherData.SetData(10f, 50f, 30.5f);

            //不想註冊也可以移除
            weatherData.RemoveObserver(kimoSite);


        } 
        /*
            觀察者模式


            角色和職責
            1. Subject (氣象局):接口，會有個具體的subject 實作他，並管理Observer
                (1)registerObserver() : 註冊
                (2)removeObserver() : 移除
                (3)notifyObservers()    : 通知有註冊的用戶，更新數據或其他業務
            2. Observer (三方網站) : 接口

            
            
            
            需求:
            天氣預報 
            氣象站將每天測量到的溫度、濕度、氣壓.. 已公告形式發布 (ex: 第三方網站)
            1. 需要提供溫度、濕度、氣壓數據的接口
            2. 數據更新時，要能實時通知第三方

            普通方案
            1. 提供getxxx 接口，讓三方接入，得到相關信息
            2. 數據有更新時，氣象站可以調用datachange()方法更新數據，氣象站主動發送通知三方


            缺點:
            1. 如果有新的三方也來接入氣象站的數據，無法動態加入新的第三方
        */

        public interface ISubject
        {
            public void RegisterObserver(IObserver observer);
            public void RemoveObserver(IObserver observer);
            public void NotifyObservers();
        }

        public interface IObserver
        {
            public void Update(float temperature,float pressure,float humidity);
        }

        //要新增三方，只要新增個類 實作 IObserver就行 了
        public class CurrentConditions: IObserver
        {
            private float _temperature;
            private float _pressure;
            private float _humidity;

            public void Update(float temperature, float pressure, float humidity)
            {
                _temperature = temperature;
                _pressure = pressure;
                _humidity = humidity;
                Display();
            }

            public void Display()
            {
                Console.WriteLine($"***tody temperature: {_temperature}***");
                Console.WriteLine($"***tody pressure: {_pressure}***");
                Console.WriteLine($"***tody humidity: {_humidity}***");
            }
        }

        public class KimoSite : IObserver
        {
            private float _temperature;
            private float _pressure;
            private float _humidity;

            public void Update(float temperature, float pressure, float humidity)
            {
                _temperature = temperature;
                _pressure = pressure;
                _humidity = humidity;
                Display();
            }

            public void Display()
            {
                Console.WriteLine("奇摩網站");
                Console.WriteLine($"***tody kimo temperature: {_temperature}***");
                Console.WriteLine($"***tody kimo pressure: {_pressure}***");
                Console.WriteLine($"***tody kimo humidity: {_humidity}***");
            }
        }

        //就算新增網站這個核心類都不用改動
        public class WeatherData: ISubject
        {
            public float Temperature { get; set; }
            public float Pressure { get; set; }
            public float Humidity { get; set; }
           
            //含有IObserver 集合
            //當有數據更新，通知所有接入方
            private List<IObserver> observers;

            public WeatherData()
            {
                observers = new List<IObserver>();
            }

            //更新數據
            public void SetData(float temperature, float pressure, float humidity)
            {
                Temperature = temperature;
                Pressure = pressure;
                Humidity = humidity;
                NotifyObservers();
            }
           

            public void NotifyObservers()
            {
                foreach (var o in observers)
                {
                    o.Update(Temperature, Pressure, Humidity);
                }
            }

            public void RegisterObserver(IObserver observer)
            {
                observers.Add(observer);
            }

            public void RemoveObserver(IObserver observer)
            {
                observers.Remove(observer);
            }
        } 

    }
}
