using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainerInteractController : MonoBehaviour
{
    Item_Container targetItemContainer;
    [SerializeField] ItemContainerPanel itemContainerPanel;

    public void Open()
    {
        itemContainerPanel.gameObject.SetActive(true);
    }
    public void Close()
    {
        itemContainerPanel.gameObject.SetActive(false);
    }
}
