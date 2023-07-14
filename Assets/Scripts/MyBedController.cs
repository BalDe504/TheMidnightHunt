using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyBedController : MonoBehaviour
{

    public void SwitchScenes()
    {
        SceneManager.LoadScene("Hospital");
    }
}
