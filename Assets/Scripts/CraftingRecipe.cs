using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using System;

// Skrypt dla obiektu przechowującego dane przepisu rzemieślniczego
[CreateAssetMenu(menuName = "Data/Recipe")] 
public class CraftingRecipe : ScriptableObject
{
    // Lista elementów (przedmiotów) wymaganych do stworzenia nowego przedmiotu
    public List<ItemSlot> elements;

    // Dane wyjściowego przedmiotu (rezultat rzemiosła)
    public ItemSlot output;
}
