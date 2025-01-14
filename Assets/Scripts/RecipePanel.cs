using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skrypt obsługujący panel wyświetlania przepisów 
public class RecipePanel : ItemPanel
{
    // Lista przepisów dostępnych w panelu
    [SerializeField] RecipeList recipeList;

    // Obiekt odpowiedzialny za wykonywanie craftingu
    [SerializeField] Crafting crafting;

    // Wyświetla dostępne przepisy w panelu
    public override void Show()
    {
        for (int i = 0; i < buttons.Count && i < recipeList.recipes.Count; i++)
        {
            // Ustawia przyciski na podstawie wyjścia każdego przepisu
            buttons[i].Set(recipeList.recipes[i].output);
        }
    }

    // Obsługuje kliknięcie w przepis w panelu
    public override void OnClick(int id)
    {
        // Jeśli kliknięto poza listą przepisów, zakończ
        if (id >= recipeList.recipes.Count)
        {
            return;
        }

        // Wykonuje rzemiosło na podstawie wybranego przepisu
        crafting.Craft(recipeList.recipes[id]);
    }
}