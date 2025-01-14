using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Skrypt obsługujący akcję orania kafelków na siatce
[CreateAssetMenu(menuName = "Data/ToolAction/Plow")]
public class PlowTile : ToolAction
{
    // Lista kafelków, które można zaorać
    [SerializeField] List<TileBase> canPlow;

    // Metoda wywoływana podczas użycia narzędzia na siatce kafelków
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController tileMapReadController, Item item)
    {
        // Pobiera kafelek na pozycji siatki
        TileBase tileToPlow = tileMapReadController.GetTileBase(gridPosition);

        // Sprawdza, czy kafelek znajduje się na liście możliwych do zaorania
        if (canPlow.Contains(tileToPlow) == false)
        {
            return false; // Zwraca false, jeśli kafelek nie jest obsługiwany
        }

        // Wywołuje oranie na pozycji siatki
        tileMapReadController.cropsManager.Plow(gridPosition);
        return true; // Zwraca true po udanej akcji
    }
}