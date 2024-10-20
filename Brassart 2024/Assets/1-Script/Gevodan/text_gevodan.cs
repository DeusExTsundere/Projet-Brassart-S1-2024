using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class text_gevodan : MonoBehaviour
{

    [SerializeField] private GameObject[] text;
    [SerializeField] private GameObject choix_chemin; 

    private void Start()
    {
        Introduction();
    }

    public void Introduction()
    {
        text[0].SetActive(true);
        StartCoroutine(suite_txt_1());
    }

    IEnumerator suite_txt_1()
    {
        yield return new WaitForSeconds(1);
        text[1].SetActive(true);
        StartCoroutine(suite_txt_2());
    }
    IEnumerator suite_txt_2()
    {
        yield return new WaitForSeconds (1);
        text[2].SetActive(true);
        StartCoroutine(suite_txt_3());
    }
    IEnumerator suite_txt_3()
    {
        yield return new WaitForSeconds (1);
        text[3].SetActive(true);
    }

    IEnumerator button_choix()
    {
        yield return new WaitForSeconds (1);
        choix_chemin.SetActive(true);
    }
}
