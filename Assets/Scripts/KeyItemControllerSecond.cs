using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemController2 : MonoBehaviour
{
    [SerializeField] private bool firstDoor = false;
    [SerializeField] private bool firstKey = false;
    [SerializeField] private bool secondDoor = false;
    [SerializeField] private bool secondKey = false;

    [SerializeField] private KeyInventory _keyInventory = null;

    private KeyDoorController doorObject;

    private void Start()
    {
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
        }

        if (secondDoor)
        {
            doorObject.PlayAnimation();
        }
        else if (secondKey)
        {
            _keyInventory.hasSecondKey = true;
            gameObject.SetActive(false);
        }
    }
}
