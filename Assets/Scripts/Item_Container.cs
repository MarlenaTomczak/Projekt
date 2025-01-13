using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
// Klasa reprezentująca pojedynczy slot w ekwipunku
public class ItemSlot
{
    public Item item; // Przedmiot w slocie
    public int count; // Ilość przedmiotów w slocie

    // Kopiuje dane z innego slotu
    public void Copy(ItemSlot slot)
    {
        item = slot.item;
        count = slot.count;
    }

    // Ustawia przedmiot i jego ilość w slocie
    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }

    // Czyści slot
    public void Clear()
    {
        item = null;
        count = 0;
    }
}

// Klasa reprezentująca kontener na przedmioty (np. ekwipunek)
[CreateAssetMenu(menuName = "Data/Item Container")]
public class Item_Container : ScriptableObject
{
    public List<ItemSlot> slots; // Lista slotów w kontenerze
    public bool isDirty; // Flaga wskazująca, czy kontener został zmodyfikowany

    // Dodaje przedmiot do kontenera
    public void Add(Item item, int count = 1)
    {
        isDirty = true;

        if (item.stackable == true)
        {
            // Szuka istniejącego slotu z tym przedmiotem
            ItemSlot itemSlot = slots.Find(x => x.item == item);
            if (itemSlot != null)
            {
                itemSlot.count += count; // Zwiększa ilość przedmiotów
            }
            else
            {
                // Szuka pustego slotu
                itemSlot = slots.Find(x => x.item == null);
                if (itemSlot != null)
                {
                    itemSlot.item = item;
                    itemSlot.count = count;
                }
            }
        }
        else
        {
            // Dla przedmiotów niestackowalnych szuka pustego slotu
            ItemSlot itemSlot = slots.Find(x => x.item == null);
            if (itemSlot != null)
            {
                itemSlot.item = item;
            }
        }
    }

    // Usuwa przedmiot z kontenera
    public void Remove(Item itemToRemove, int count = 1)
    {
        isDirty = true;

        if (itemToRemove.stackable)
        {
            // Szuka slotu z tym przedmiotem
            ItemSlot itemSlot = slots.Find(x => x.item == itemToRemove);
            if (itemSlot == null) { return; }

            itemSlot.count -= count; // Zmniejsza ilość przedmiotów
            if (itemSlot.count <= 0)
            {
                itemSlot.Clear(); // Czyści slot, jeśli ilość wynosi 0
            }
        }
        else
        {
            // Dla niestackowalnych usuwa po jednym
            while (count > 0)
            {
                count -= 1;

                ItemSlot itemSlot = slots.Find(x => x.item == itemToRemove);
                if (itemSlot == null) { return; }
                itemSlot.Clear();
            }
        }
    }

    // Sprawdza, czy jest wolne miejsce w kontenerze
    internal bool CheckFreeSpace()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item == null)
            {
                return true;
            }
        }
        return false;
    }

    // Sprawdza, czy w kontenerze znajduje się określony przedmiot w odpowiedniej ilości
    internal bool CheckItem(ItemSlot checkingItem)
    {
        ItemSlot itemSlot = slots.Find(x => x.item == checkingItem.item);
        if (itemSlot == null) { return false; }

        if (checkingItem.item.stackable)
        {
            return itemSlot.count >= checkingItem.count;
        }
        return true;
    }
}
