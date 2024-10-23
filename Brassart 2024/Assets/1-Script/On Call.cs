using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnCall : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject positionRead;
    [SerializeField] private GameObject uiCall;

    private Vector3 initialPosition;
    [SerializeField] private bool reading = false;
    public bool Reading 
    { 
        get { return reading; } 
        set { reading = value; }
    }
    private bool clickable = true;
    public bool Clickable 
    { 
        get { return clickable; }
    }

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (reading)
        {
            transform.position = positionRead.transform.position;
            clickable = false;
            uiCall.SetActive(true);
        }
        else
        {
            transform.position = initialPosition;
            clickable = true;
            uiCall.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger");
    }

    public void resetClickable(InputAction.CallbackContext context)
    {
        if (!clickable && context.started)
        {
            clickable = true;
            reading = false;
        }
    }
}
