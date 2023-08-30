using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceDeactivate : MonoBehaviour
{
    [SerializeField] private KeyInventory _keyInventory = null;

    // Update is called once per frame
    void Update()
    {
        if (_keyInventory.hasFirstKey == true)
            this.gameObject.SetActive(false);
    }
}
