using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyDoorController : MonoBehaviour
{
    private Animator doorAnim;

    public bool doorOpen = false;

    [SerializeField] private UnityEvent openEvent;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            doorAnim.Play("DoorOpen", 0, 0.0f);
            doorOpen = true;
            openEvent.Invoke();
        }
        else
        {
            doorAnim.Play("DoorClose", 0, 0.0f);
            doorOpen = false;
            openEvent.Invoke();
        }
    }
}
