using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

[CreateAssetMenu(menuName = "Data/ToolAction/Harvest")]

public class TilePickUpAction : ToolAction
{
   public override bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController tileMapReadController, Item item)
   {
      tileMapReadController.cropsManager.PickUp(gridPosition);

      tileMapReadController.objectManager.PickUp(gridPosition);
      return true;
   }
}
