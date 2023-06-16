using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public KeyCode leftLook = KeyCode.Q;
    public KeyCode rightLook = KeyCode.E;

    public Transform orientation;

    float xRotation;
    float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        StateHandler();
        

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);


    }

    public void StateHandler()
    {
        if (Input.GetKeyDown(leftLook))
        {
                yRotation -= 170f;
        }
        else if (Input.GetKeyUp(leftLook))
        {
            yRotation += 170f;
        }
        else if (Input.GetKeyDown(rightLook))
        {
            yRotation += 170f;
        }
        else if (Input.GetKeyUp(rightLook))
        {
            yRotation -= 170f;
        }
    }
}
