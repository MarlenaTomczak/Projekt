using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skrypt obsługujący akcję sadzenia roślin na siatce kafelków
[CreateAssetMenu(menuName = "Data/ToolAction/Seed Tile")]
public class SeedTile : ToolAction
{
    // Metoda wywoływana podczas użycia narzędzia do sadzenia na siatce kafelków
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController tileMapReadController, Item item)
    {
        // Sprawdza, czy na wskazanej pozycji siatki można posadzić roślinę
        if (tileMapReadController.cropsManager.Check(gridPosition) == false)
        {
            return false; // Zwraca false, jeśli sadzenie nie jest możliwe
        }

        // Wywołuje metodę sadzenia w menedżerze upraw
        tileMapReadController.cropsManager.Seed(gridPosition, item.crop);

        return true; // Zwraca true po udanym sadzeniu
    }
}