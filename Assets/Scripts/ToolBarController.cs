using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Klasa kontrolująca pasek narzędzi gracza
public class ToolBarController : MonoBehaviour
{
    [SerializeField] int toolBarSize = 7; // Liczba slotów w pasku narzędzi
    int selectedTool; // Aktualnie wybrane narzędzie

    // Akcja wywoływana przy zmianie narzędzia
    public Action<int> onChange;

    [SerializeField] IconHighlight iconHighlight; // Obiekt podświetlający ikonę

    // Właściwość zwracająca aktualnie wybrany przedmiot
    public Item GetItem
    {
        get {
            return GameManager.instance.inventoryContainer.slots[selectedTool].item;
        }
    }

    private void Start()
    {
        onChange += UpdateHighlightIcon; // Subskrybuj metodę aktualizującą ikonę
        UpdateHighlightIcon(selectedTool); // Aktualizuj ikonę dla początkowego narzędzia
    }

    private void Update()
    {
        // Obsługa przewijania myszką do zmiany narzędzia
        float delta = Input.mouseScrollDelta.y;
        if (delta != 0)
        {
            if (delta > 0)
            {
                selectedTool += 1;
                selectedTool = (selectedTool >= toolBarSize) ? 0 : selectedTool;
            }
            else
            {
                selectedTool -= 1;
                selectedTool = (selectedTool < 0) ? toolBarSize - 1 : selectedTool;
            }
            onChange?.Invoke(selectedTool); // Wywołaj zdarzenie zmiany narzędzia
        }
    }

    // Ustawia aktywne narzędzie na podstawie podanego id
    internal void Set(int id)
    {
        selectedTool = id;
    }

    // Aktualizuje ikonę podświetlenia na podstawie wybranego narzędzia
    public void UpdateHighlightIcon(int id = 0)
    {
        Item item = GetItem;
        if (item == null)
        {
            iconHighlight.Show = false; // Ukryj podświetlenie, jeśli brak przedmiotu
            return;
        }

        iconHighlight.Show = item.iconHighlight; // Ustaw widoczność podświetlenia
        if (item.iconHighlight)
        {
            iconHighlight.Set(item.icon); // Ustaw ikonę podświetlenia
        }
    }
}
