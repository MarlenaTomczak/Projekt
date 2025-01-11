using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skrypt obsługujący system rzemiosła (crafting)
public class Crafting : MonoBehaviour
{
    // Referencja do ekwipunku gracza
    [SerializeField] Item_Container inventory;

    // Metoda odpowiedzialna za tworzenie przedmiotu na podstawie przepisu
    public void Craft(CraftingRecipe recipe)
    {
        // Sprawdzenie, czy w ekwipunku jest wystarczająco miejsca
        if (inventory.CheckFreeSpace() == false)
        {
            Debug.Log("Za mało miejsca w ekwipunku");
            return;
        }

        // Sprawdzenie, czy gracz posiada wszystkie wymagane przedmioty
        for (int i = 0; i < recipe.elements.Count; i++)
        {
            if (inventory.CheckItem(recipe.elements[i]) == false) 
            { 
                Debug.Log("Brak potrzebnych przedmiotów w ekwipunku");
                return;
            }
        }

        // Usunięcie przedmiotów potrzebnych do stworzenia przedmiotu
        for (int i = 0; i < recipe.elements.Count; i++)
        {
            inventory.Remove(recipe.elements[i].item, recipe.elements[i].count);
        }

        // Dodanie stworzonego przedmiotu do ekwipunku
        inventory.Add(recipe.output.item, recipe.output.count);
    }
}
