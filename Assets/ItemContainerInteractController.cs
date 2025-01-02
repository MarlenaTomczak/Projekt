using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainerInteractController : MonoBehaviour
{
    Item_Container targetItemContainer;
    InventoryController inventoryController;
    [SerializeField] ItemContainerPanel itemContainerPanel;
    Transform openedChest;
    [SerializeField] float maxDistance = 0.8f;

    private void Awake()
    {
        inventoryController = GetComponent<InventoryController>();
    }
    private void Update()
    {
        if(openedChest != null)
        {
            float distance = Vector2.Distance(openedChest.position, transform.position);
            if (distance > maxDistance)
            {
                openedChest.GetComponent<LootContainerInteract>().Close(GetComponent<Character>());
            }
        }
    }

    public void Open(Item_Container item_Container, Transform _openedChest)
    {
        targetItemContainer = item_Container;
        itemContainerPanel.inventory = targetItemContainer;
        inventoryController.Open();
        itemContainerPanel.gameObject.SetActive(true);
        openedChest = _openedChest; 
    }
    public void Close()
    {
        inventoryController.Close();
        itemContainerPanel.gameObject.SetActive(false);
        openedChest = null;
    }
}
