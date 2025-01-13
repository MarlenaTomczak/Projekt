using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skrypt obsługujący panel wyświetlania ekwipunku
public class ItemPanel : MonoBehaviour
{
    // Referencja do kontenera ekwipunku
    public Item_Container inventory;

    // Lista przycisków ekwipunku
    public List<InventoryButton> buttons;

    private void Start()
    {
        Init(); // Inicjalizacja panelu
    }

    // Inicjalizuje panel, ustawia indeksy i wyświetla przedmioty
    public void Init()
    {
        SetIndex(); // Ustawienie indeksów dla przycisków
        Show(); // Wyświetlenie przedmiotów
    }

    private void OnEnable()
    {
        Show(); // Odświeżanie panelu po włączeniu
    }

    private void LateUpdate()
    {
        // Jeśli ekwipunek został zmodyfikowany, odśwież panel
        if (inventory.isDirty)
        {
            Show();
            inventory.isDirty = false;
        }
    }

    // Ustawia indeksy przycisków na podstawie ich pozycji w liście
    private void SetIndex()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetIndex(i);
        }
    }

    // Wyświetla przedmioty w panelu na podstawie danych z ekwipunku
    public virtual void Show()
    {
        for (int i = 0; i < inventory.slots.Count && i < buttons.Count; i++)
        {
            if (inventory.slots[i].item == null)
            {
                buttons[i].Clean(); // Czyści przycisk, jeśli slot jest pusty
            }
            else
            {
                buttons[i].Set(inventory.slots[i]); // Ustawia dane przycisku na podstawie slotu
            }
        }
    }

    // Metoda wirtualna obsługująca kliknięcia na przyciski (do nadpisania w klasach pochodnych)
    public virtual void OnClick(int id)
    {

    }
}
