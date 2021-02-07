using Packages.Rider.Editor.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Events : MonoBehaviour
    {
        public event EventHandler<OnSpacePressedEventArgs> OnSpacePressed;
        public class OnSpacePressedEventArgs : EventArgs
        {
            public int spaceCount;
        }
        public delegate void Test<T1, T2>(T1 t1);
        public delegate void TestEventDelegate(float f);
        public event TestEventDelegate OnFloatEvent;
        public event Action<bool, int> OnActionEvent;
        public UnityEvent OnUnityEvent;
        private int spaceCount;
        private void Start()
        {
            OnSpacePressed += Testing_OnSpacePressed;
        }
        private void Testing_OnSpacePressed(object sender, EventArgs e)
        {
            //  Debug.Log("Space!");
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //space pressed!
                spaceCount++;
                OnSpacePressed?.Invoke(this, new OnSpacePressedEventArgs {spaceCount = spaceCount });
                OnFloatEvent?.Invoke(4f);
                OnActionEvent?.Invoke(true, 56);
                OnUnityEvent?.Invoke();

            }

        }
    }
}
