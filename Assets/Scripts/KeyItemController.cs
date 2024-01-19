using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Diagnostics;
using System.Threading;

    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool firstDoor = false;
        [SerializeField] private bool firstKey = false;
        [SerializeField] private bool secondDoor = false;
        [SerializeField] private bool secondKey = false;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;

        [SerializeField] private UnityEvent openEvent;
    public Stopwatch timer = new Stopwatch();
    public void Start()
        {
    timer.Start();
        if (firstDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }

        if (secondDoor)
        {
            doorObject = GetComponent<KeyDoorController>();
        }
            
        }

        public void ObjectInteraction()
        {
            if (firstDoor && !secondDoor && _keyInventory.hasFirstKey)
            {
                doorObject.PlayAnimation();
            openEvent.Invoke();
        }
            else if (firstKey && !secondKey)
            {
                _keyInventory.hasFirstKey = true;
                gameObject.SetActive(false);
            openEvent.Invoke();
            timer.Stop();
            TimeSpan ts = timer.Elapsed;
            _keyInventory.firstKeyTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            timer.Reset();
        }

        if (secondDoor && _keyInventory.hasSecondKey)
        {
            doorObject.PlayAnimation2();
            openEvent.Invoke();
        }
        else if (secondKey && !firstKey)
        {
            _keyInventory.hasSecondKey = true;
            gameObject.SetActive(false);
            openEvent.Invoke();
            timer.Stop();
            TimeSpan ts = timer.Elapsed;
            _keyInventory.secondKeyTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        }
    }

    }

