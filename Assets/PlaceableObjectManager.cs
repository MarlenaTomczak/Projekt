using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceableObjectManager : MonoBehaviour
{
  [SerializeField] PlaceableObjectContainer placeableObject;
  [SerializeField] Tilemap targetTilemap;

   private void Start()
   {
        if (placeableObject == null)
        {
            placeableObject = new PlaceableObjectContainer();  // Initialize if null
        }

        if (placeableObject.placeableObject == null)
        {
            placeableObject.placeableObject = new List<PlaceableObject>();  // Initialize the list if null
        }
        if (placeableObject == null)
        {
            placeableObject = new PlaceableObjectContainer();  // Initialize if null
        }
        GameManager.instance.GetComponent<PlaceableObjectReferenceManager>().placeableObjectManager = this;
   }

  public void Place(Item item, Vector3Int positionOnGrid)
  {
    GameObject go = Instantiate(item.itemPrefab);
    Vector3 position = targetTilemap.CellToWorld(positionOnGrid) + targetTilemap.cellSize/2;
    position -= Vector3.forward * 0.1f;
    go.transform.position = position;
    placeableObject.placeableObject.Add(new PlaceableObject(item, go.transform, positionOnGrid));
  } 
}
    