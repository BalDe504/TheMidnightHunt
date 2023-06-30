using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController2 : MonoBehaviour
{
    private Animator doorAnim;

    private bool doorOpen = false;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            doorAnim.Play("DoorOpen2", 0, 0.0f);
            doorOpen = true;
        }
        else
        {
            doorAnim.Play("DoorClose2", 0, 0.0f);
            doorOpen = false;
        }
    }
}
