using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool firstDoor = false;
        [SerializeField] private bool firstKey = false;
        [SerializeField] private bool secondDoor = false;
        [SerializeField] private bool secondKey = false;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;

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
            if (firstDoor && !secondDoor)
            {
                doorObject.PlayAnimation();
            }
            else if (firstKey && !secondKey)
            {
                _keyInventory.hasFirstKey = true;
                gameObject.SetActive(false);
            }

        if (secondDoor && _keyInventory.hasSecondKey)
        {
            doorObject.PlayAnimation2();
        }
        else if (secondKey && !firstKey)
        {
            _keyInventory.hasSecondKey = true;
            gameObject.SetActive(false);
        }
    }

    }

