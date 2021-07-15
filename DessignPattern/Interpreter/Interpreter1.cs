using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Interpreter
{
    class Interpreter1
    {
        public static void Run()
        {
            Console.WriteLine("請輸入表達式");
            string expStr = Console.ReadLine();
            Dictionary<string, int> var = GetValue(expStr);
            Calculator calculator = new Calculator(expStr);
            Console.WriteLine($"運算結果 {expStr} = {calculator.Run(var)}");
        }

        public static Dictionary<string, int> GetValue(string expStr)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();

            foreach (var ch in expStr.ToCharArray())
            {
                if (ch != '+' && ch != '-')
                {
                    if (!map.ContainsKey(ch.ToString()))
                    {
                        Console.WriteLine($"請輸入{ch}的值: ");
                        string inputVal=Console.ReadLine();
                        map.Add(ch.ToString(), int.Parse(inputVal));
                    }
                }
            }

            return map;
        }
        /*
            解釋器模式

            給一個表達式(語言)，定義他的文法的一種表示，會定義一個解釋器，用來解釋表達式(語言)的意思

            應用: 編譯器、正則表達式、機器人

            注意事項和細節
            本身解決比較麻煩的問題，類很多，會導致類膨脹，且是採用遞歸調用，debug 比較複雜
            
            需求:
            實現四則運算， 如 a+b+c-d+e，要求表達式字母不能重複
            分別輸出 a~e 輸入的值
            最後求出結果
            
            角色和職責
            1. Context : 全局訊息(解釋器以外)，含input、output
            2. AbstractExpression : 抽像表達式，為抽象與法數中所有節點所共享
            3. TerminalExpression : 終結符表達式，為文法中的終結符解釋操作
            4. NonTerminalExpression : 非終結表達式，為文法中的非終結符解釋操作
            5. 說明:  輸入 Context 跟 TerminalExpression 通過Client 輸入即可
        */

        public class Calculator
        {
            private Expression expression;

            public Calculator(string expStr)
            {
                Stack<Expression> stack = new Stack<Expression>();
                //ex:  a+b
                //['a','+','b']
                char[] charArr = expStr.ToCharArray();

                Expression left;
                Expression right;
                //把 運算符 、 變數也拆成小的 表達式
                //變數 =>VarExpression
                //運算符 =>  AddExpresson 或是 SubExpresson


                for (int i = 0; i < charArr.Length; i++)
                {
                    switch (charArr[i])
                    {
                        case '+':
                            left = stack.Pop(); 
                            right = new VarExpression(charArr[++i].ToString());
                            stack.Push(new AddExpresson(left,right)); 
                            break;
                        case '-':
                            left = stack.Pop();
                            right = new VarExpression(charArr[++i].ToString());
                            stack.Push(new SubExpresson(left, right));
                            break;
                        default:
                            stack.Push(new VarExpression(charArr[i].ToString()));
                            break;
                    }

                }
                //最終得到表達式
                //取到的是前面放入的 AddExpresson 或是 SubExpresson
                //left 、 right 都傳入了 VarExpression ， 他就自己去前面輸入的字典取值了
                expression = stack.Pop();
            }

            //運算結果
            public int Run(Dictionary<string,int> var)
            {
                return expression.Inerpreter(var);
            }
        }

        //抽象類表達式，通過dcit，獲取到變量的值
        public abstract class Expression
        {
            //解釋攻式跟數值的關係 key 就是表達式式  參數 [a,b,c] , value 就是具體值
            //dict 拿到的是 {a:10,b:15,c:3}   (變量具體的值)
            public abstract int Inerpreter(Dictionary<string, int> var);
            
        }

        //變量的解析器
        public class VarExpression : Expression
        {
            private string _key;
            public VarExpression(string key)
            {
                _key = key;
            }

            public override int Inerpreter(Dictionary<string, int> var)
            {
                return var[_key];
            }
        }

        //符號表達式 +-*/
        //每個運算符號，都只會和自己左右兩個數字有關系
        //左右兩個式字可能也是一個解析的結果，無論何種類型，都是Expression 的實現類
        public class SymbolExpression: Expression
        {
            protected Expression _left;
            protected Expression _right;
            public SymbolExpression(Expression left, Expression right)
            {
                _left = left;
                _right = right;
            }

            // 都是讓其子類來實現，這邊只是默認實現
            public override int Inerpreter(Dictionary<string, int> var)
            {
                return 0;
            }
        }
        public class AddExpresson: SymbolExpression
        {
            public AddExpresson(Expression left, Expression reght):base(left, reght) { }
            
            //處理相加
            public override int Inerpreter(Dictionary<string,int> var)
            {
                //_left.Inerpreter(var) 返回的是左表達式對應的值
                //_right.Inerpreter(var)) 返回的是右表達式對應的值
                return _left.Inerpreter(var)+_right.Inerpreter(var);
            }
        }

        public class SubExpresson : SymbolExpression
        {
            public SubExpresson(Expression left, Expression reght) : base(left, reght) { }
            //處理相減
            public override int Inerpreter(Dictionary<string, int> var)
            {
                return _left.Inerpreter(var) -_right.Inerpreter(var);
            }
        }

    }
}
