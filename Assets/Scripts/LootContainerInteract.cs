using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Klasa obsługująca interakcję ze skrzynią
public class LootContainerInteract : Interactable
{
    // Referencje do zamkniętego i otwartego stanu skrzyni
    [SerializeField] GameObject Chest_Closed;
    [SerializeField] GameObject Chest_Opened;

    // Czy skrzynia jest otwarta
    [SerializeField] bool isOpen;

    // Kontener przechowujący przedmioty w skrzyni
    [SerializeField] Item_Container item_Container;

    // Obsługa interakcji postaci z pojemnikiem
    public override void Interact(Character character)
    {
        if (character == null)
        {
            Debug.LogError("Character is null in LootContainerInteract.Interact!");
            return;
        }

        // Pobranie kontrolera interakcji z kontenerami przedmiotów
        var itemContainerController = character.GetComponent<ItemContainerInteractController>();
        if (itemContainerController == null)
        {
            Debug.LogError("ItemContainerInteractController is missing on the Character!");
            return;
        }

        // Przełączanie stanu skrzyni
        if (!isOpen)
        {
            Open(character);
        }
        else
        {
            Close(character);
        }
    }

    // Otwiera skrzynię
    public void Open(Character character)
    {
        isOpen = true;
        Chest_Closed.SetActive(false); // Ukrywa zamkniętą skrzynię
        Chest_Opened.SetActive(true); // Pokazuje otwartą skrzynię

        // Otwiera interfejs pojemnika dla postaci
        character.GetComponent<ItemContainerInteractController>().Open(item_Container, transform);
    }

    // Zamykaj skrzynię
    public void Close(Character character)
    {
        isOpen = false;
        Chest_Closed.SetActive(true); // Pokazuje zamkniętą skrzynię
        Chest_Opened.SetActive(false); // Ukrywa otwartą skrzynię

        // Zamykaj interfejs pojemnika
        character.GetComponent<ItemContainerInteractController>().Close();
    }
}