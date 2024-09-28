using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private Vector3 moveMouse;
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        moveMouse.x += Input.GetAxis("Mouse X") ;
        moveMouse.y += Input.GetAxis("Mouse Y") ;
        moveMouse.z = 0;
        Debug.Log(moveMouse);
        transform.position = moveMouse;
    }
}
