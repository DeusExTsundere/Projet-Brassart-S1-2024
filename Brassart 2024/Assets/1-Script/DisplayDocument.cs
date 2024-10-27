using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DisplayDocument : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject displayPosition;
    [SerializeField] private GameObject uiDocument;
    private Vector3 initialPostion;
    private bool isConsulting = false;
    public bool IsConsulting 
    {  
        get { return isConsulting; } 
        set { isConsulting = value; }
    }
    private bool clickable = true;
    public bool Clickable
    {
        get { return clickable; }
    }

    void Start()
    {
        initialPostion = transform.position;
    }

    void Update()
    {
        if (isConsulting)
        {
            transform.position = displayPosition.transform.position;
            clickable = false;
            uiDocument.SetActive(true);
        }
        else if (isConsulting == false)
        {
            clickable = true;
            transform.position = initialPostion;
            uiDocument.SetActive(false);
        }
        
    }

    public void ExitDisplay(InputAction.CallbackContext context)
    {
        if (context.started && clickable!)
        {
            clickable = true;
            isConsulting = false;
        }
    }
}
