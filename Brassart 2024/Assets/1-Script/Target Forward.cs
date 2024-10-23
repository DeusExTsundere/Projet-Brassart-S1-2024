using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TargetForward : MonoBehaviour
{
    [SerializeField] private GameObject positionReading;
    private bool targetReading;
    private RaycastHit hit;
    private bool reading = false;
    private bool isReadable = false;
    private Vector2 mouseMove;
    private Vector3 playerRotation;
    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        playerRotation.y += mouseMove.x;
        playerRotation.x -= mouseMove.y;
        if (reading)
        {
            transform.LookAt(positionReading.transform.position);
        }
        else
        {
            transform.rotation = Quaternion.Euler(playerRotation);
        }
        Debug.DrawRay(transform.position, transform.forward * 100, Color.red); // Laser pour connaitre la directionn de l'objet
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.GetComponent<MoveClick>())
            {
                targetReading = hit.collider.gameObject.GetComponent<MoveClick>().Reading;
                //Debug.LogError(hit.collider.gameObject.GetComponent<MoveClick>().Reading);
                isReadable = true;
                if (reading)
                {
                    hit.collider.gameObject.GetComponent<MoveClick>().Reading = true;
                }
                else if (reading!)
                {

                }
            }
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
            Debug.Log("input ok");
        }
    }

    public void undoObjectAction(InputAction.CallbackContext context)
    {
        reading = false;
    }

}
