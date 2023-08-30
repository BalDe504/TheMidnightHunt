using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterController : MonoBehaviour
{
    [SerializeField] private KeyInventory _keyInventory = null;
    public GameObject hand;
    
    public GameObject Light;
    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;
    public GameObject Light4;
    public GameObject Light5;
    public GameObject Light6;
    public GameObject Light7;
    public GameObject Voice7;

    public Light lightActive;
    public Light lightActive1;
    public Light lightActive2;
    public Light lightActive3;
    public Light lightActive4;
    public Light lightActive5;
    public Light lightActive6;
    public Light lightActive7;

    public void ObjectInteraction()
    {
        

        _keyInventory.hasLighter = true;
        gameObject.SetActive(false);
        

        if(_keyInventory.hasLighter = true)
        {
            hand = GameObject.Find("/CameraHolder/PlayerCam/Lighter_Prefab");
            hand.SetActive(true);
            
            Light = GameObject.FindGameObjectWithTag("Lamp");
            Light1 = GameObject.FindGameObjectWithTag("Lamp1");
            Light2 = GameObject.FindGameObjectWithTag("Lamp2");
            Light3 = GameObject.FindGameObjectWithTag("Lamp3");
            Light4 = GameObject.FindGameObjectWithTag("Lamp4");
            Light5 = GameObject.FindGameObjectWithTag("Lamp5");
            Light6 = GameObject.FindGameObjectWithTag("Lamp6");
            Light7 = GameObject.FindGameObjectWithTag("Lamp7");
            Voice7 = GameObject.FindGameObjectWithTag("Voice7");

            lightActive = Light.GetComponent<Light>();
            lightActive1 = Light1.GetComponent<Light>();
            lightActive2 = Light2.GetComponent<Light>();
            lightActive3 = Light3.GetComponent<Light>();
            lightActive4 = Light4.GetComponent<Light>();
            lightActive5 = Light5.GetComponent<Light>();
            lightActive6 = Light6.GetComponent<Light>();
            lightActive7 = Light7.GetComponent<Light>();
            
            lightActive.enabled = false;
            lightActive1.enabled = false;
            lightActive2.enabled = false;
            lightActive3.enabled = false;
            lightActive4.enabled = false;
            lightActive5.enabled = false;
            lightActive6.enabled = false;
            lightActive7.enabled = false;

            Voice7.GetComponent<Collider>().enabled = true;

        }
    }
}
