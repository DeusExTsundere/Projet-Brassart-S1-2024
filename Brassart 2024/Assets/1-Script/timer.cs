using TMPro;
using UnityEngine;

public class RemainingTime : MonoBehaviour
{
    private TextMeshProUGUI chrono;
    [SerializeField] private float temps;
    [SerializeField] private bool isActive;
    public bool IsActive 
    { 
        get { return isActive; } 
        set { isActive = value; }
    }

    private float minutes;
    private float secondes;

    private void Awake()
    {
        ConvertSeconds();
    }
    void Start()
    {
        chrono = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Mathf.Round(temps) > 0 && isActive)
        {
            temps -= Time.deltaTime;
            ConvertSeconds();
            chrono.SetText("Temps Restant : " + minutes + " : " + Mathf.Round(secondes));
        }
    }

    void ConvertSeconds()
    {
        minutes = temps / 60;
        minutes = Mathf.Round(minutes);      
        secondes = (temps-( minutes*60));
        secondes = Mathf.Round(secondes);
    }

}
