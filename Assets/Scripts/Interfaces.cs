using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Scripts
{
    public class Interfaces : MonoBehaviour
    {
        private void Start()
        {
            MyClass myClass = new MyClass();
            TestInterface(myClass);
            MySecondClass mySecondClass = new MySecondClass();
            TestInterface(mySecondClass);
        }
        private void TestInterface(IMyInterface myInterface)
        {
            myInterface.TestFunction();
        }
    }

    public interface IMyInterface : IMySecondInterface
    {
        //not defining accessors, all public*
        event EventHandler OnMyEvent;
        int myInt { get; set; }
        //float myFloat   //can't contain fields
        void TestFunction();
    }
    public interface IMySecondInterface
    {
        void SecondInterfaceFunction(int i);
    }

    public class MyClass : IMyInterface, IMySecondInterface
    {
        public int myInt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler OnMyEvent;

        public void SecondInterfaceFunction(int i)
        {
            throw new NotImplementedException();
        }

        public void TestFunction()
        {
            Debug.Log("MyClass.TestFunction()");
        }
    }
    public class MySecondClass : IMyInterface
    {
        public int myInt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler OnMyEvent;

        public void SecondInterfaceFunction(int i)
        {
            throw new NotImplementedException();
        }

        public void TestFunction()
        {
            Debug.Log("MySecondClass.TestFunction()");
        }
    }

    public abstract class Item : ScriptableObject
    {

    }
}
