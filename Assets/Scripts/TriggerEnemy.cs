using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{
    [SerializeField] private KeyInventory _keyInventory = null;
    private MyDoorController doorClose;
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            _keyInventory.enemyTriggered = true;
            _keyInventory.hasSecondKey = false;
            GameObject.FindGameObjectWithTag("EnemyDoors").GetComponent<Animator>().Play("DoorClose", 0, 0.0f);
            doorClose.doorOpen = false;
        }
            

    }
}
