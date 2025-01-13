using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skrypt kontrolujący zarządzanie ekwipunkiem
public class InventoryController : MonoBehaviour
{
    // Referencje do paneli interfejsu użytkownika
    [SerializeField] GameObject panel; // Główny panel ekwipunku
    [SerializeField] GameObject statusPanel; // Panel statusu
    [SerializeField] GameObject toolbarPanel; // Panel paska narzędzi

    private void Update()
    {
        // Sprawdza, czy klawisz "I" został naciśnięty
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Przełącza widoczność panelu ekwipunku
            if (panel.activeInHierarchy == false)
            {
                Open(); // Otwiera ekwipunek
            }
            else
            {
                Close(); // Zamknij ekwipunek
            }
        }
    }

    // Otwiera ekwipunek
    public void Open()
    {
        panel.SetActive(true); // Włącza panel ekwipunku
        statusPanel.SetActive(true); // Włącza panel statusu
        toolbarPanel.SetActive(false); // Wyłącza pasek narzędzi
    }

    // Zamykaj ekwipunek
    public void Close()
    {
        panel.SetActive(false); // Wyłącza panel ekwipunku
        statusPanel.SetActive(false); // Wyłącza panel statusu
        toolbarPanel.SetActive(true); // Włącza pasek narzędzi
    }
}
