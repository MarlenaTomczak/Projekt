using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Skrypt obsługujący przeciąganie i upuszczanie przedmiotów
public class itemDragandDropController : MonoBehaviour
{
    // Slot na przedmiot, którym zarządza kontroler
    public ItemSlot itemSlot;

    // Ikona reprezentująca przedmiot
    [SerializeField] GameObject itemIcon;
    RectTransform iconTransform;
    Image itemIconImage;

    private void Start()
    {
        // Inicjalizacja slotu przedmiotu oraz referencji do ikony
        itemSlot = new ItemSlot();
        iconTransform = itemIcon.GetComponent<RectTransform>();
        itemIconImage = itemIcon.GetComponent<Image>();
    }

    private void Update()
    {
        // Jeśli ikona przedmiotu jest aktywna
        if (itemIcon.activeInHierarchy == true)
        {
            // Przesuwaj ikonę w miejsce kursora myszy
            iconTransform.position = Input.mousePosition;

            // Obsługa upuszczania przedmiotu na świat gry
            if (Input.GetMouseButtonDown(0))
            {
                // Jeśli kursor nie jest nad UI
                if (EventSystem.current.IsPointerOverGameObject() == false)
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    worldPosition.z = 0;

                    // Spawn przedmiotu w miejscu upuszczenia
                    ItemSpawnMenager.instance.SpawnItem(worldPosition, itemSlot.item, itemSlot.count);
                    itemSlot.Clear(); // Czyszczenie slotu
                    itemIcon.SetActive(false); // Ukrycie ikony
                }
            }
        }
    }

    // Usuwa określoną ilość przedmiotu ze slotu
    internal void RemoveItem(int count = 1)
    {
        if (itemSlot == null) { return; }

        if (itemSlot.item.stackable)
        {
            itemSlot.count -= count;
            if (itemSlot.count <= 0)
            {
                itemSlot.Clear();
            }
        }
        else
        {
            itemSlot.Clear();
        }
        UpdateIcon(); // Aktualizacja ikony
    }

    // Sprawdza, czy slot zawiera określony przedmiot w wymaganej ilości
    public bool Check(Item item, int count = 1)
    {
        if (itemSlot == null) { return false; }

        if (item.stackable)
        {
            return itemSlot.item == item && itemSlot.count >= count;
        }

        return itemSlot.item == item;
    }

    // Obsługuje kliknięcie w slot przedmiotu
    internal void OnClick(ItemSlot itemSlot)
    {
        if (this.itemSlot.item == null)
        {
            this.itemSlot.Copy(itemSlot);
            itemSlot.Clear();
        }
        else
        {
            Item item = itemSlot.item;
            int count = itemSlot.count;
            itemSlot.Copy(this.itemSlot);
            this.itemSlot.Set(item, count);
        }
        UpdateIcon(); // Aktualizacja ikony po zmianie slotu
    }

    // Aktualizuje ikonę przedmiotu w oparciu o dane slotu
    private void UpdateIcon()
    {
        if (itemSlot.item == null)
        {
            itemIcon.SetActive(false); // Ukrywa ikonę, jeśli slot jest pusty
        }
        else
        {
            itemIcon.SetActive(true); // Pokazuje ikonę, jeśli slot zawiera przedmiot
            itemIconImage.sprite = itemSlot.item.icon; // Ustawia sprite ikony
        }
    }
}
