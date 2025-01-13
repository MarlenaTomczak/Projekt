using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skrypt obsługujący generowanie przedmiotów w grze
[RequireComponent(typeof(TimeAgent))] // Odnośnik do wymaganego komponentu TimeAgent
public class ItemSpawner : MonoBehaviour
{
    // Przedmiot do wygenerowania
    [SerializeField] Item toSpawn;

    // Ilość generowanych przedmiotów
    [SerializeField] int count;

    // Zakres rozrzutu pozycji generowania
    [SerializeField] float spread = 2f;

    // Prawdopodobieństwo generowania przedmiotu
    [SerializeField] float probability = 0.5f;

    private void Start()
    {
        // Pobiera komponent TimeAgent i subskrybuje zdarzenie czasowe
        TimeAgent timeAgent = GetComponent<TimeAgent>();
        timeAgent.onTimeTick += Spawn;
    }

    // Metoda generująca przedmiot
    void Spawn()
    {
        if (UnityEngine.Random.value < probability) // Sprawdza, czy zdarzenie generacji powinno wystąpić
        {
            Vector3 position = transform.position;

            // Dodaje losowe przesunięcie w ramach rozrzutu
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;

            // Wywołuje menedżera generowania przedmiotów
            ItemSpawnMenager.instance.SpawnItem(position, toSpawn, count);
        }
    }
}
