using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choix : MonoBehaviour
{
    [SerializeField]private Toggle choix1;
    [SerializeField]private Toggle choix2;
    [SerializeField]private Toggle[] choixPage1;
    [SerializeField]private Toggle[] choixPage2;

    private void OnEnable()
    {
        for (int i = 0; i < choixPage1.Length; i++)
        {
            choixPage1[i].enabled = false;
            Debug.Log("A");
        }
        for (int j = 0;j < choixPage2.Length; j++)
        {
            choixPage2[j].enabled = false;
            Debug.Log("B");
        }
    }

    private void Update()
    {
        if (choix1.isOn)
        {
            choix2.enabled = false;
            for (int i = 0; i < choixPage2.Length; i++)
            {
                choixPage2[i].enabled = false;
            }
            for(int j = 0; j< choixPage1.Length; j++)
            {
                choixPage1[j].enabled = true;
            }
            if (choixPage1[0].isOn)
            {
                choixPage1[1].enabled = false;
            }
            else if (choixPage1[1].isOn)
            {
                choixPage1[0].enabled = false;
            }
        }
        else if (choix2.isOn)
        {
            choix1.enabled = false;
            for (int i = 0;i < choixPage1.Length; i++)
            {
                choixPage1[i].enabled = false;
            }

            for (int j = 0;j < choixPage2.Length; j++)
            {
                choixPage2[j].enabled = true;
            }
            if (choixPage2[0].isOn)
            {
                choixPage2[1].enabled = false;
            }
            else if (choixPage2[1].isOn)
            {
                choixPage2[0].enabled = false;
            }
        }
    }
}
