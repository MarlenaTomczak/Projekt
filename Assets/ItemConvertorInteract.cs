using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConvertorInteract : Interactable
{
  [SerializeField] Item convertableItem;
  [SerializeField] Item producedItem;
  [SerializeField] int producedItemCount = 1;

  ItemSlot itemSlot;

  [SerializeField] float timeToProcess = 5f;
  float timer;

  private void Start()
  {
    itemSlot = new ItemSlot();
  }

  public override void Interact(Character character)
  {
    if(itemSlot.item == null) 
    {
        if(GameManager.instance.dragandDropController.Check(convertableItem))
        {
            StartItemProcessing();
        }
    }
    
    if(itemSlot.item != null && timer < 0f)
    {
        GameManager.instance.inventoryContainer.Add(itemSlot.item, itemSlot.count);
        itemSlot.Clear();
    }
    
  }

  private void StartItemProcessing()
  {
    itemSlot.Copy(GameManager.instance.dragandDropController.itemSlot);
    GameManager.instance.dragandDropController.RemoveItem();

    timer = timeToProcess;
  }

  private void Update()
  {
    if(itemSlot == null) { return; }
    if(timer > 0f)
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            CompleteItemConversion();
        }
    }
  }

  private void CompleteItemConversion()
  {
    itemSlot.Clear();
    itemSlot.Set(producedItem, producedItemCount);
  }
}
