using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceActivate : MonoBehaviour
{
    [SerializeField] private KeyInventory _keyInventory = null;

    // Update is called once per frame
    void Update()
    {
        if (_keyInventory.hasLighter == true)
            this.gameObject.SetActive(true);
    }
}
