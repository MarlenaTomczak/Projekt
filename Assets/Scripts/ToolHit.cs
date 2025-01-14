using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Klasa bazowa dla narzędzi umożliwiających interakcję z obiektami
public class ToolHit : MonoBehaviour
{
    // Metoda wirtualna, wywoływana podczas uderzenia w obiekt
    public virtual void Hit()
    {
        // Domyślne zachowanie - brak działania
    }

    // Metoda wirtualna, sprawdzająca czy obiekt może być uderzony danym narzędziem
    public virtual bool CanBeHit(List<ResourceNodeType> canBeHit)
    {
        return true; // Domyślnie każdy obiekt może być uderzony
    }
}