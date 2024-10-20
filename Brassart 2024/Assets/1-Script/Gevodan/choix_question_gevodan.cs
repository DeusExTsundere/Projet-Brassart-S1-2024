using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class choix_question_gevodan : MonoBehaviour
{

    [SerializeField] private GameObject intro;
    [SerializeField] private GameObject text;
    [SerializeField] private Button button_gris;
    [SerializeField] private Button button_orange;
    [SerializeField] private Button button_vert;
    private TextMeshProUGUI txt_dialogue;
    private string lore = "-C�est... c�est difficile � dire. C�est un genre de chien, ou un loup... peut-�tre m�me un ours tellement c�est gros..";
    public bool chemin_choisi = false;
    private bool choix_gris = false;
    private bool choix_orange = false;
    private bool choix_vert = false;

    private void Awake()
    {
        txt_dialogue = text.GetComponent<TextMeshProUGUI>();
    }

    public void Question_1_GRIS ()
    {
        Debug.Log("choix gris");
        choix_gris=true;
        button_gris.enabled = false;
        if (chemin_choisi == false)
        {
            lore += "-Cette cr�ature vous a-t-elle d�j� attaqu� ou bless� ? \n -Non non ! Juste elle est l�.. Elle m�observe..";
            txt_dialogue.SetText(lore);
            choix_chemin();
        }
    } 

    public void Question_1_ORANGE () 
    {
        choix_vert=true;
        button_orange.enabled = false;
        if (chemin_choisi == false)
        {
            lore += "-Pouvez-vous me pr�ciser votre localisation ? \n -Je suis au bord de la route, dans la cambrousse. Il n�y a pas un chat � des kilom�tres. Heureusement que j�ai suivi le conseil de P�re en achetant un t�l�phone portable pour la voiture.";
            txt_dialogue.SetText(lore);
            choix_chemin();
        }
    }

    public void Question_1_VERT()
    {
        choix_orange = true;
        button_vert.enabled = false;
        if (chemin_choisi == false)
        {
            lore += "-Pouvez-vous me donner votre identit�, s'il vous pla�t ? \n -Je suis Pierre Bertrand. Je suis simplement sorti d�une soir�e avec des amis, et voil� que je tombe sur cette... cette cr�ature. Je... je ne sais pas quoi faire.";
            txt_dialogue.SetText(lore);
            choix_chemin();
        }
    }

    public void Back()
    {

    }

    public void choix_chemin()
    {
        intro.SetActive(false);
        text.SetActive(true);   
        if ((choix_gris) && (choix_orange ||choix_vert))
        {
            Debug.Log("1");
            chemin_un();
            chemin_choisi=true;
        }
        else if (choix_vert && choix_orange)
        {
            Debug.Log("2");
            chemin_deux();
            chemin_choisi=true;
        }
    }

    public void chemin_un()
    {
        txt_dialogue.SetText(lore);
    }

    public void chemin_deux()
    {

    }

    public void reset_bool ()
    {
        choix_gris = false;
        choix_orange=false;
        choix_vert =false;
    }
}
