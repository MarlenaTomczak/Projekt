using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skrypt przechowujący listę przepisów
[CreateAssetMenu(menuName = "Data/RecipeList")]
public class RecipeList : ScriptableObject 
{ 
    // Lista przepisów
    public List<CraftingRecipe> recipes;
}
