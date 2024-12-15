using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] Item_Container inventory;
    public void Craft( CraftingRecipe recipe)
    {
        if (inventory.CheckFreeSpace() == false)
        {
            Debug.Log(" za mało miejsca w ekwipunku");
            return;
        }

        
        for (int i = 0; i < recipe.elements.Count; i++)
        {


            if (inventory.CheckItem(recipe.elements[i]) == false) 
            { 
           
                Debug.Log("brak potrzebnych przedmiotów w ekwipunku");
                return;
            };
         }
 
        for(int i= 0;  i < recipe.elements.Count;i++)
        {
            inventory.Remove(recipe.elements[i].item, recipe.elements[i].count);
        }
        inventory.Add(recipe.output.item,recipe.output.count);
    }
}
