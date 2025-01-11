using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skrypt obsługujący interakcje postaci z otoczeniem
public class CharacterInteractController : MonoBehaviour
{
    // Referencja do kontrolera ruchu postaci
    character_controler2d character_controller;

    // Referencja do Rigidbody2D postaci
    Rigidbody2D rigidbody2d;

    // Odległość od środka postaci, gdzie sprawdzane są interakcje
    [SerializeField] float offsetDistance = 1f;

    // Rozmiar obszaru interakcji
    [SerializeField] float sizeOfInteractableArea = 1.2f;

    // Kontroler podświetlania obiektów interaktywnych
    [SerializeField] HighlightController highlightController;

    // Referencja do komponentu Character (jeśli istnieje)
    Character character;

    // Wywoływane podczas inicjalizacji skryptu
    private void Awake()
    {
        // Pobranie referencji do wymaganych komponentów
        character_controller = GetComponent<character_controler2d>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }

    // Wywoływane raz na klatkę
    private void Update()
    {
        Check(); // Sprawdzanie otoczenia pod kątem obiektów interaktywnych

        // Sprawdzenie, czy użytkownik nacisnął prawy przycisk myszy
        if (Input.GetMouseButtonDown(1))
        {
            Interact(); // Wywołanie interakcji
        }
    }

    // Metoda sprawdzająca otoczenie pod kątem obiektów interaktywnych
    private void Check()
    {
        // Obliczenie pozycji sprawdzania w kierunku ostatniego ruchu postaci
        Vector2 position = rigidbody2d.position + character_controller.lastMotionVector * offsetDistance;

        // Znalezienie wszystkich obiektów w obszarze interakcji
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        // Przechodzenie przez znalezione obiekty
        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>(); // Sprawdzenie, czy obiekt jest interaktywny
            if (hit != null)
            {
                highlightController.Highlight(hit.gameObject); // Podświetlenie obiektu
                return;
            }
        }

        // Ukrycie podświetlenia, jeśli nie znaleziono obiektów
        highlightController.Hide();
    }

    // Metoda obsługująca interakcję z obiektami
    private void Interact()
    {
        // Obliczenie pozycji interakcji w kierunku ostatniego ruchu postaci
        Vector2 position = rigidbody2d.position + character_controller.lastMotionVector * offsetDistance;

        // Znalezienie wszystkich obiektów w obszarze interakcji
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        // Przechodzenie przez znalezione obiekty
        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>(); // Sprawdzenie, czy obiekt jest interaktywny
            if (hit != null)
            {
                hit.Interact(character); // Wywołanie metody interakcji obiektu
                break;
            }
        }
    }
}