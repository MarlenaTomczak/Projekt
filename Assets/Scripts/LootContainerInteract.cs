using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interactable   
{
    [SerializeField] GameObject Chest_Closed;
    [SerializeField] GameObject Chest_Opened;
    [SerializeField] bool isOpen;
    [SerializeField] Item_Container item_Container;
    public override void Interact(Character character)
    {
        if (character == null)
        {
            Debug.LogError("Character is null in LootContainerInteract.Interact!");
            return;
        }

        var itemContainerController = character.GetComponent<ItemContainerInteractController>();
        if (itemContainerController == null)
        {
            Debug.LogError("ItemContainerInteractController is missing on the Character!");
            return;
        }
        if (!isOpen) 
        {
            isOpen = true;
            Chest_Closed.SetActive(false);
            Chest_Opened.SetActive(true);

            character.GetComponent<ItemContainerInteractController>().Open(item_Container, transform);
        }
        else
        {
            isOpen = false;
            Chest_Closed.SetActive(true);
            Chest_Opened.SetActive(false);

            character.GetComponent<ItemContainerInteractController>().Close();
        }
    }

}
