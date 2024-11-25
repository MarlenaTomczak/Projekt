using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interactable   
{
    [SerializeField] GameObject Chest_Closed;
    [SerializeField] GameObject Chest_Opened;
    [SerializeField] bool isOpen;
    public override void Interact(Character character)
    {
    if (!isOpen) 
        {
            isOpen = true;
            Chest_Closed.SetActive(false);
            Chest_Opened.SetActive(true);
        }
    }
}
