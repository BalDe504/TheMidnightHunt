using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool firstDoor = false;
        [SerializeField] private bool firstKey = false;
        [SerializeField] private bool secondDoor = false;
        [SerializeField] private bool secondKey = false;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;

        [SerializeField] private UnityEvent openEvent;

    private void Start()
        {
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
        }
    }

    }

