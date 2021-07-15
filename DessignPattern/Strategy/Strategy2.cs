using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Strategy
{
    class Strategy2
    {
        public static void Run()
        {
            WildDuck wildDuck = new WildDuck();
            //繼承可以調用到父類的方法
            wildDuck.Fly();

            ToyDuck toyDuck = new ToyDuck();
            toyDuck.Fly();

            toyDuck.SetFlyBehavior(new GoodToFly());
            toyDuck.Fly();
        }

        //策略接口
        public interface IFlyBehavior
        {
            public void Fly();
        }

        public interface IBarkBehavior
        {
            public void Bark();
        }

        public interface ISwimBehavior
        {
            public void Swim();
        }


        //實現的策略
        public class GoodToFly:IFlyBehavior
        {
            public void Fly()
            {
                Console.WriteLine("很會飛");
            }
        }

        //實現的策略
        public class BadToFly : IFlyBehavior
        {
            public void Fly()
            {
                Console.WriteLine("不太會飛");
            }
        }

        //實現的策略
        public class CanBark : IBarkBehavior
        {
            public void Bark()
            {
                Console.WriteLine("會叫");
            }
        }

        //實現的策略
        public class NoBark : IBarkBehavior
        {
            public void Bark()
            {
                Console.WriteLine("不會叫");
            }
        }

        //實現的策略
        public class CanSwim : ISwimBehavior
        {
            public void Swim()
            {
                Console.WriteLine("會游泳");
            }
        }

        //實現的策略
        public class NoSwim : ISwimBehavior
        {
            public void Swim()
            {
                Console.WriteLine("不太會游泳");
            }
        }


        //Context 使用者
        public abstract class Duck
        {
            //策略接口
            protected IFlyBehavior _flyBehavior;

            protected IBarkBehavior _barkBehavior;

            protected ISwimBehavior _swimBehavior;

            //之後想加其他的策略可以加

            
            //顯示鴨子的訊息
            public abstract void DisPlay();

            public virtual void Bark()
            {
                if (_barkBehavior != null)
                {
                    _barkBehavior.Bark();
                }
            }

            public virtual void Fly()
            {
                if (_flyBehavior != null)
                {
                    _flyBehavior.Fly();
                }
            }

            public virtual void Swim()
            {
                if (_swimBehavior != null)
                {
                    _swimBehavior.Swim();
                }
            }

            //setter
            //重制飛行的行為
            public void SetFlyBehavior(IFlyBehavior flyBehavior)
            {
                this._flyBehavior = flyBehavior;
            }

            public void SetBarkBehavior(IBarkBehavior barkBehavior)
            {
                this._barkBehavior = barkBehavior;
            }

            public void SetSwimBehavior(ISwimBehavior swimBehavior)
            {
                this._swimBehavior = swimBehavior;
            }
        }

        public class WildDuck : Duck
        {
            public WildDuck()
            {
                _flyBehavior = new GoodToFly();
            }
            public override void DisPlay()
            {
                Console.WriteLine("這是野鴨");
            }
        }

        public class BJDuck : Duck
        {
            public BJDuck()
            {
                _flyBehavior = new BadToFly();
            }
            public override void DisPlay()
            {
                Console.WriteLine("這是北京鴨");
            }
        }

        public class ToyDuck : Duck
        {
            //因為繼承，可以調用到父類的屬性
            public ToyDuck()
            {
                _flyBehavior = new BadToFly();
                _barkBehavior = new NoBark();
                _swimBehavior = new NoSwim();

            }
            public override void DisPlay()
            {
                Console.WriteLine("這是玩具鴨");
            }
        }
    }
}
