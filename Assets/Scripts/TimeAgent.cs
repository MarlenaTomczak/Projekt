using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Klasa obsługująca agenta czasu, który reaguje na zdarzenia czasowe
public class TimeAgent : MonoBehaviour
{
    // Akcja wywoływana przy każdym tyknięciu czasu
    public Action onTimeTick;

    private void Start()
    {
        Init(); // Inicjalizacja agenta czasu
    }

    // Subskrybuje agenta czasu w kontrolerze czasu gry
    public void Init()
    {
        GameManager.instance.timeController.Subscribe(this);
    }

    // Wywołuje zdarzenie czasowe
    public void Invoke()
    {
        onTimeTick?.Invoke(); // Wywołuje akcję, jeśli jest subskrybowana
    }

    private void OnDestroy()
    {
        // Wyrejestrowuje agenta czasu po jego zniszczeniu
        GameManager.instance.timeController.Unsubscribe(this);
    }
}