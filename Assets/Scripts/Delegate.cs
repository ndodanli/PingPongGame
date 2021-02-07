using System;
using UnityEngine;

namespace Assets.Scripts
{
    class Delegate : MonoBehaviour
    {
        public delegate void TestDelegate();
        public delegate bool TestBoolDelegate(int i);
        private TestDelegate testDelegateFunction;
        private delegate Result Test<T1,  Result>(T1 t);
        private Test<int, string> test;
        private TestBoolDelegate testBoolDelegateFunction;
        public Action testAction;   //same as TestDelegate, takes no parameters, returns void
        public Action<int, float> testIntFloatAction;
        public Func<bool> testFunc;
        private Func<int, bool> testIntBoolFunc;
        private void Start()
        {
            testDelegateFunction += () => { Debug.Log("Lambda expression"); };  //We cant revome it
            testDelegateFunction += () => { Debug.Log("SecondLambda expression"); };
            testDelegateFunction();
            testIntFloatAction = (int i, float f) => { Debug.Log("Test int float action"); };
            testFunc = () => { return false; };
            testIntBoolFunc = (int i) => { return false; };
            testAction = () => {  };
            test = (int i) => { return "dsad"; };
            //testDelegateFunction = MyTestDelegateFunction;
            //testDelegateFunction += MySecondTestDelegateFunction;
            //testDelegateFunction();
            //testBoolDelegateFunction = MyTestBoolDelegateFunction;
            //Debug.Log(testBoolDelegateFunction(1));
            //testDelegateFunction = delegate () { Debug.Log("Anonymous method"); };
            //testDelegateFunction();
            //testDelegateFunction = () => { Debug.Log("Lambda expression"); };
            //testDelegateFunction();
            //testBoolDelegateFunction = (int i) => { return i < 5; };
            //testDelegateFunction();
            MyClass<EnemyMinion> myClass1 = new MyClass<EnemyMinion>(new EnemyMinion());
            MyClass<EnemyTower> myClass2 = new MyClass<EnemyTower>(new EnemyTower());
        }
        private void MyTestDelegateFunction()
        {
            Debug.Log("MyTestDelegateFunction");
        }
        private void MySecondTestDelegateFunction()
        {
            Debug.Log("MySecondTestDelegateFunction");
        }
        private bool MyTestBoolDelegateFunction(int i)
        {
            return i < 5;
        }
    }

    public class MyClass<T> where T : IEnemy<int>
    {
        public T value;
        public MyClass(T value)
        {
            value.Damage(5);
        }
    }
    public interface IEnemy<T>
    {
        void Damage(T t);
    }

    public class EnemyMinion : IEnemy<int>
    {
        public void Damage(int i)
        {
            Debug.Log("EnemyMinion");
        }
    }
    public class EnemyTower : IEnemy<int>
    {
        public void Damage(int i)
        {
            Debug.Log("EnemyTower");
        }
    }

}
