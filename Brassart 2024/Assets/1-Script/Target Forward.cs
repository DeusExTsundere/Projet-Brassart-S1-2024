using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TargetForward : MonoBehaviour
{

    [SerializeField] private Vector3 positionReading;
    private bool reading = false;
    private bool isReadable = false;
    private Vector3 mouseMove = new (0,0,0);
    private bool visibilty_cursor = false;
    private void Start()
    {
        Cursor.visible = false;
        positionReading = transform.position;
    }
    void Update()
    {
        if (reading)
        {
            transform.position = positionReading;
        }
        else
        {
            mouseMove.y += Input.GetAxis("Mouse X");
            mouseMove.x -= Input.GetAxis("Mouse Y");
            mouseMove.z = 0;
            transform.rotation = Quaternion.Euler(mouseMove);
        }
        Debug.DrawRay(transform.position, transform.forward * 100, Color.red); // Laser pour connaitre la directionn de l'objet
    }

    public void objectAction(InputAction.CallbackContext context)
    {
        if (isReadable && context.started)
        {
            reading = true;
            Debug.Log("input ok");
        }
    }

    public void undoObjectAction(InputAction.CallbackContext context)
    {
        reading = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MoveClick moveClick))
        {
            if (moveClick.Clickable)
            {
                isReadable = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out MoveClick moveClick))
        {
            Debug.Log(moveClick.Clickable);
            if (moveClick.Clickable)
            {
                isReadable = true;
            }
            if (isReadable)
            {
                if (reading)
                {
                    moveClick.Reading = true;
                    transform.LookAt(other.transform.position);
                }
            }
            else if (!reading)
            {
                moveClick.Reading=false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isReadable = false;
    }
}
