using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnCall : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject positionCalling;
    [SerializeField] private GameObject uiCall;
    [SerializeField] private GameObject remainTime;
    private Vector3 initialPosition;
    private bool actuallyOnCall = false;
    public bool ActuallyOnCall 
    { 
        get { return actuallyOnCall; } 
        set { actuallyOnCall = value; }
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
        if (actuallyOnCall)
        {
            transform.position = positionCalling.transform.position;
            clickable = false;
            uiCall.SetActive(true);
            remainTime.gameObject.GetComponent<RemainingTime>().IsActive = true;
        }
        else
        {
            transform.position = initialPosition;
            clickable = true;
            uiCall.SetActive(false);
            remainTime.gameObject.GetComponent<RemainingTime>().IsActive = false;

        }
    }

    public void resetClickable(InputAction.CallbackContext context)
    {
        if (!clickable && context.started)
        {
            clickable = true;
            actuallyOnCall = false;
        }
    }
}
