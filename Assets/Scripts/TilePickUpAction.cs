using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

// Skrypt obsługujący akcję zbierania obiektów
[CreateAssetMenu(menuName = "Data/ToolAction/Harvest")]
public class TilePickUpAction : ToolAction
{
   // Metoda wywoływana podczas użycia narzędzia do zbierania
   public override bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController tileMapReadController, Item item)
   {
      // Wywołuje zbieranie upraw z menedżera upraw
      tileMapReadController.cropsManager.PickUp(gridPosition);

      // Wywołuje zbieranie obiektów z menedżera obiektów
      tileMapReadController.objectManager.PickUp(gridPosition);
      
      return true; // Zwraca true, jeśli akcja została pomyślnie wykonana
   }
}