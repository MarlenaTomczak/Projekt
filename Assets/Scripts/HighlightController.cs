using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skrypt obsługujący podświetlanie obiektów w grze
public class HighlightController : MonoBehaviour
{
     // Obiekt używany do podświetlania
     [SerializeField] GameObject highlighter;

     // Aktualnie podświetlany cel
     GameObject currentTarget;

     // Metoda podświetlająca wybrany obiekt
     public void Highlight(GameObject target)
     {
        // Jeśli cel jest już podświetlony, nie rób nic
        if (currentTarget == target)
        {
            return;
        }

        // Ustaw nowy cel
        currentTarget = target;

        // Oblicz pozycję podświetlenia (nieco nad obiektem)
        Vector3 position = target.transform.position + Vector3.up * 0.8f;

        // Podświetl w obliczonej pozycji
        Highlight(position);
     }

     // Metoda podświetlająca na podstawie pozycji
     public void Highlight(Vector3 position)
     {
        highlighter.SetActive(true); // Włącz podświetlenie
        highlighter.transform.position = position; // Ustaw pozycję podświetlenia
     }
     
     // Ukrywa podświetlenie
     public void Hide()
     {
        currentTarget = null; // Zresetuj cel
        highlighter.SetActive(false); // Wyłącz podświetlenie
     }
}
