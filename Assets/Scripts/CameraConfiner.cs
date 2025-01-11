using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// Klasa zarządzająca granicami kamery za pomocą komponentu CinemachineConfiner
public class CameraConfiner : MonoBehaviour
{
    // Referencja do komponentu CinemachineConfiner, który definiuje ograniczenia kamery
    [SerializeField] CinemachineConfiner confiner;

    /// Wywoływane na początku, inicjuje aktualizację granic
    void Start()
    {
        UpdateBounds();
    }

    /// Metoda aktualizuje granice kamery, bazując na obiekcie "CameraConfiner"
    public void UpdateBounds()
    {
        // Znajduje obiekt o nazwie "CameraConfiner"
        GameObject go = GameObject.Find("CameraConfiner");
        if (go == null) 
        {
            // Jeśli nie znaleziono obiektu, usuwamy ograniczenie kamery
            confiner.m_BoundingShape2D = null;
            return;
        }
        // Pobiera komponent Collider2D z obiektu "CameraConfiner" i ustawia jako ograniczenie
        Collider2D bounds = go.GetComponent<Collider2D>();
        confiner.m_BoundingShape2D = bounds;
    }
}

