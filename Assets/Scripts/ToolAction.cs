using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Klasa bazowa dla akcji narzędziowych
public class ToolAction : ScriptableObject
{
    // Metoda wywoływana podczas zastosowania narzędzia w świecie
    public virtual bool OnApply(Vector2 worldPoint)
    {
        Debug.LogWarning("OnApply is not implemented");
        return true;
    }

    // Metoda wywoływana podczas zastosowania narzędzia na siatce kafelków
    public virtual bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController tileMapReadController, Item item)
    {
        Debug.LogWarning("OnApplyToTileMap is not implemented");
        return true;
    }

    // Metoda wywoływana po użyciu narzędzia, usuwa przedmiot z ekwipunku
    public virtual void OnItemUsed(Item usedItem, Item_Container inventory)
    {
        inventory.Remove(usedItem);
    }
}