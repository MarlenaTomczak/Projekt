using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject player;
    public Item_Container inventoryContainer;
    public itemDragandDropController dragandDropController;
    public DayTimeController timeController;
    public PlaceableObjectReferenceManager placeableObject;
}
