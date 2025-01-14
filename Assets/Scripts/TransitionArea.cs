using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Klasa obsługująca obszar przejścia dla gracza
public class TransitionArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Sprawdza, czy obiekt wchodzący w obszar ma tag "Player"
        if (collision.transform.CompareTag("Player"))
        {
            // Wywołuje przejście dla obiektu gracza
            transform.parent.GetComponent<Transition>().InitiateTransition(collision.transform);
        }
    }
}