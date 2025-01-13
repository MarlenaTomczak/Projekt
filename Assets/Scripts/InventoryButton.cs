using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Skrypt obsługujący przyciski w ekwipunku gracza
public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    // Referencje do komponentów UI
    [SerializeField] Image icon; // Ikona przedmiotu
    [SerializeField] Text text; // Tekst z ilością przedmiotów
    [SerializeField] Image highlight; // Podświetlenie przycisku

    // Indeks przycisku w panelu ekwipunku
    int myIndex;

    // Ustawia indeks przycisku
    public void SetIndex(int index)
    {
        myIndex = index;
    }

    // Ustawia dane dla przycisku na podstawie slotu ekwipunku
    public void Set(ItemSlot slot)
    {
        icon.gameObject.SetActive(true); // Włącza ikonę
        icon.sprite = slot.item.icon; // Ustawia ikonę przedmiotu

        // Jeśli przedmiot jest możliwy do stackowania, pokazuje ilość
        if (slot.item.stackable == true)
        {
            text.gameObject.SetActive(true);
            text.text = slot.count.ToString(); // Ustawia ilość przedmiotów
        }
        else
        {
            text.gameObject.SetActive(false); // Ukrywa tekst ilości
        }
    }

    // Czyści dane przycisku
    public void Clean()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false); // Wyłącza ikonę
        text.gameObject.SetActive(false); // Ukrywa tekst
    }

    // Obsługa kliknięcia w przycisk
    public void OnPointerClick(PointerEventData eventData)
    {
        ItemPanel itemPanel = transform.parent.GetComponent<ItemPanel>(); // Pobiera panel ekwipunku
        itemPanel.OnClick(myIndex); // Wywołuje kliknięcie w panelu dla danego indeksu
    }

    // Podświetla przycisk
    public void Highlight(bool b)
    {
        highlight.gameObject.SetActive(b); // Ustawia stan podświetlenia
    }
}
