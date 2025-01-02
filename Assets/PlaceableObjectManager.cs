using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceableObjectManager : MonoBehaviour
{
  [SerializeField] PlaceableObjectContainer placeableObjects;
  [SerializeField] Tilemap targetTilemap;

   private void Start()
   {
        
        GameManager.instance.GetComponent<PlaceableObjectReferenceManager>().placeableObjectManager = this;
        VisualizeMap();
   }

    private void OnDestroy()
    {
        for(int i = 0; i < placeableObjects.placeableObject.Count; ++i)
        {
            placeableObjects.placeableObject[i].targetObject = null;
        }
    }

    private void VisualizeMap()
    {
        for(int i = 0; i < placeableObjects.placeableObject.Count; ++i)
        {
            VisualizeItem(placeableObjects.placeableObject[i]);
        }
    }

    internal void PickUp(Vector3Int gridPosition)
    {
        PlaceableObject placedObject = placeableObjects.Get(gridPosition);

        if(placeableObjects == null)
        {
            Debug.LogWarning("No object found at the given grid position.");    
            return;
        }

        ItemSpawnMenager.instance.SpawnItem(
            targetTilemap.CellToWorld(gridPosition),
            placedObject.placedItem,
            1
            );

        Destroy(placedObject.targetObject.gameObject);

        placeableObjects.Remove(placedObject);
    }

    private void VisualizeItem(PlaceableObject placeableObject)
    {
        GameObject go = Instantiate(placeableObject.placedItem.itemPrefab);
        Vector3 position = targetTilemap.CellToWorld(placeableObject.positionOnGrid) + targetTilemap.cellSize / 2;
        position -= Vector3.forward * 0.1f;
        go.transform.position = position;

        placeableObject.targetObject = go.transform;
    }
    public bool Check(Vector3Int position)
    {
        return placeableObjects.Get(position) != null;
    }
    public void Place(Item item, Vector3Int positionOnGrid)
    {
        if(Check(positionOnGrid) == true) { return; }
        PlaceableObject placeableObject = new PlaceableObject(item, positionOnGrid);
        VisualizeItem(placeableObject);
        placeableObjects.placeableObject.Add(placeableObject);  
    }

 
}
    