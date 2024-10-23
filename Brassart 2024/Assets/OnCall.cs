using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCall : MonoBehaviour
{
    [SerializeField] private GameObject uiChoice;
    private bool call = false;
    void Update()
    {
        if (call)
        {
            uiChoice.SetActive(true);
        }
        else
        {
            uiChoice.SetActive(false);
        }
    }
}
