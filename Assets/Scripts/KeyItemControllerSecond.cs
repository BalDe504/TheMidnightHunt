using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyItemController2 : MonoBehaviour
{
    [SerializeField] private bool firstDoor = false;
    [SerializeField] private bool firstKey = false;
    [SerializeField] private bool secondDoor = false;
    [SerializeField] private bool secondKey = false;

    [SerializeField] private KeyInventory _keyInventory = null;

    private KeyDoorController doorObject;

    public Stopwatch timer1;
    public Stopwatch timer2;

    private void Start()
    {
        timer1.Begin();
        if (secondDoor)
        {
            doorObject = GetComponent<KeyDoorController>();
        }
    }

    public void ObjectInteraction()
    {
        if (firstDoor)
        {
            doorObject.PlayAnimation();
        }
        else if (firstKey)
        {
            _keyInventory.hasFirstKey = true;
            gameObject.SetActive(false);
            timer1.Pause();
            _keyInventory.firstKeyTime = timer1.GetRawElapsedTime().ToString();
            timer2.Begin();
            Debug.Log(_keyInventory.firstKeyTime);
        }

        if (secondDoor)
        {
            doorObject.PlayAnimation();
        }
        else if (secondKey)
        {
            _keyInventory.hasSecondKey = true;
            gameObject.SetActive(false);
            timer2.Pause();
            _keyInventory.secondKeyTime = String.Format("{0:00}:{1:00}.{2:00}", timer2.GetMinutes(), timer2.GetSeconds(), timer2.GetMilliseconds());
        }
    }

    public class Stopwatch : MonoBehaviour
    {
        private float elapsedRunningTime = 0f;
        private float runningStartTime = 0f;
        private float pauseStartTime = 0f;
        private float elapsedPausedTime = 0f;
        private float totalElapsedPausedTime = 0f;
        private bool running = false;
        private bool paused = false;

        void Update()
        {
            if (running)
            {
                elapsedRunningTime = Time.time - runningStartTime - totalElapsedPausedTime;
            }
            else if (paused)
            {
                elapsedPausedTime = Time.time - pauseStartTime;
            }
        }

        public void Begin()
        {
            if (!running && !paused)
            {
                runningStartTime = Time.time;
                running = true;
            }
        }

        public void Pause()
        {
            if (running && !paused)
            {
                running = false;
                pauseStartTime = Time.time;
                paused = true;
            }
        }

        public void Unpause()
        {
            if (!running && paused)
            {
                totalElapsedPausedTime += elapsedPausedTime;
                running = true;
                paused = false;
            }
        }

        public void Reset()
        {
            elapsedRunningTime = 0f;
            runningStartTime = 0f;
            pauseStartTime = 0f;
            elapsedPausedTime = 0f;
            totalElapsedPausedTime = 0f;
            running = false;
            paused = false;
        }

        public int GetMinutes()
        {
            return (int)(elapsedRunningTime / 60f);
        }

        public int GetSeconds()
        {
            return (int)(elapsedRunningTime);
        }

        public float GetMilliseconds()
        {
            return (float)(elapsedRunningTime - System.Math.Truncate(elapsedRunningTime));
        }

        public float GetRawElapsedTime()
        {
            return elapsedRunningTime;
        }
    }
}
