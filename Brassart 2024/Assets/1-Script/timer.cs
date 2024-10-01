using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
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
        if (Mathf.FloorToInt(temps) > 0 && isActive)
        {
            temps -= Time.deltaTime;
            ConvertSeconds();
            chrono.SetText("Temps Restant : " + minutes + " : " + Mathf.FloorToInt(secondes));
        }
    }

    void ConvertSeconds()
    {
        minutes = temps / 60;
        minutes = Mathf.FloorToInt(minutes);      
        secondes = (temps-( minutes*60));
        secondes = Mathf.FloorToInt(secondes);
    }

}
