using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skrypt obsługujący grupę paneli w interfejsie użytkownika
public class PanelGroup : MonoBehaviour
{
    // Lista paneli w grupie
    public List<GameObject> panels;

    // Wyświetla wybrany panel, ukrywając pozostałe
    public void Show(int idPanel)
    {
        for (int i = 0; i < panels.Count; i++)
        {
            // Ustawia aktywność panelu na podstawie jego indeksu
            panels[i].SetActive(i == idPanel);
        }
    }
}
