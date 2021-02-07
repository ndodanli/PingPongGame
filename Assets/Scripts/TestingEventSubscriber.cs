using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class TestingEventSubscriber : MonoBehaviour
    {
        public event EventHandler OnSpacePressed;
        private void Start()
        {
            Events evt = GetComponent<Events>();
            evt.OnSpacePressed += Evt_OnSpacePressed;
            evt.OnFloatEvent += Evt_OnFloatEvent;
            evt.OnActionEvent += Evt_OnActionEvent;
        }

        private void Evt_OnActionEvent(bool arg1, int arg2)
        {
            Debug.Log(arg1 + " " + arg2);
        }

        private void Evt_OnFloatEvent(float f)
        {
            Debug.Log("Float: " + f);
        }

        private void Evt_OnSpacePressed(object sender, Events.OnSpacePressedEventArgs e)
        {
            Debug.Log("Space count: " + e.spaceCount);
            Events evt = GetComponent<Events>();
            evt.OnSpacePressed -= Evt_OnSpacePressed;   //unsubscribe
        }
        public void TestingUnityEvent()
        {
            Debug.Log("TestingUnityEvent");
        }

    }
}
