using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ten skrypt steruje ruchem i animacjami postaci w 2D
[RequireComponent(typeof(Rigidbody2D))] // Upewnia się, że obiekt posiada komponent Rigidbody2D
public class character_controler2d : MonoBehaviour
{
    // Referencja do komponentu Rigidbody2D
    Rigidbody2D rigidbody2d;

    // Prędkość ruchu postaci
    [SerializeField] float speed = 2f;

    // Wektor reprezentujący aktualny kierunek ruchu
    Vector2 motionVector;

    // Przechowuje ostatni kierunek, w którym poruszała się postać
    public Vector2 lastMotionVector;

    // Referencja do komponentu Animator do obsługi animacji
    Animator animator;

    // Zmienna logiczna śledząca, czy postać aktualnie się porusza
    public bool moving;

    // Wywoływana podczas ładowania instancji skryptu
    void Awake()
    {
        // Pobranie referencji do wymaganych komponentów
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Wywoływana raz na klatkę
    private void Update()
    {
        // Pobranie danych wejściowych od gracza
        float horizontal = Input.GetAxisRaw("Horizontal"); // Wejście poziome (np. A/D lub strzałki)
        float vertical = Input.GetAxisRaw("Vertical");   // Wejście pionowe (np. W/S lub strzałki)

        // Utworzenie wektora ruchu na podstawie danych wejściowych
        motionVector = new Vector2(horizontal, vertical);

        // Aktualizacja parametrów animatora dla kierunku ruchu
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);

        // Sprawdzanie, czy postać się porusza
        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("moving", moving); // Aktualizacja stanu "moving" w animatorze

        // Jeśli postać się porusza, aktualizuj ostatni wektor ruchu i kierunek
        if (horizontal != 0 || vertical != 0)
        {
            lastMotionVector = new Vector2(horizontal, vertical).normalized; // Normalizacja dla spójnego kierunku

            // Aktualizacja parametrów animatora dla ostatniego kierunku
            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);
        }
    }

    // Wywoływana w stałych odstępach czasu (używane do aktualizacji fizyki)
    void FixedUpdate()
    {
        Move(); // Obsługuje ruch postaci
    }

    // Obsługuje ruch postaci na podstawie wejścia
    private void Move()
    {
        // Ustaw prędkość Rigidbody2D na wektor ruchu pomnożony przez prędkość
        rigidbody2d.velocity = motionVector * speed;
    }
}
