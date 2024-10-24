using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject positionReading;
    [SerializeField] private GameObject telephone;
    [SerializeField] private GameObject document;
    private RaycastHit hit;
    private bool reading = false;
    private bool isReadable = false;
    private bool phone = false;
    private bool isCalling = false;
    private Vector2 mouseMove;
    private Vector3 playerRotation;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 30f))
        {
            if (hit.collider.gameObject.GetComponent<DisplayDocument>())
            {
                isReadable = true;
                hit.collider.gameObject.GetComponent<DisplayDocument>().IsConsulting = reading;
            }
            else if (hit.collider.gameObject.GetComponent<OnCall>())
            {
                phone = true;
                if (isCalling)
                {
                    hit.collider.gameObject.GetComponent<OnCall>().ActuallyOnCall = true;
                }
            }
        }
        else
        {
            isReadable = false;
        }
        playerRotation.y += mouseMove.x;
        playerRotation.x -= mouseMove.y;
        Debug.DrawRay(transform.position, transform.forward * 30, Color.red); // Laser pour connaitre la direction de l'objet
    }

    private void LateUpdate()
    {
        if (reading)
        {
            transform.LookAt(positionReading.transform.position);
        }
        else
        {
            transform.rotation = Quaternion.Euler(playerRotation);
        }
    }

    public void DeltaMouse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            mouseMove = context.ReadValue<Vector2>();
        }
        else
        {
            mouseMove = Vector2.zero;
        }
    }

    public void objectAction(InputAction.CallbackContext context)
    {
        if (isReadable && context.started)
        {
            reading = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (phone &&  context.started)
        {
            isCalling = true;
        }

    }

    public void StopCall(InputAction.CallbackContext context)
    {
        if (context.started) 
        { 
            isCalling = false;
            telephone.GetComponent<OnCall>().ActuallyOnCall=false;
        }
    }

    public void undoObjectAction(InputAction.CallbackContext context)
    {
        reading = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        document.GetComponent<DisplayDocument>().IsConsulting = false;
    }

}
