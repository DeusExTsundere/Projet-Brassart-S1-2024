using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class Stockage_Lore : ScriptableObject
{
    [SerializeField] private string histoire;
    public string Histoire { get { return histoire; } }
}
