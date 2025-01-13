using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Skrypt obsługujący panel ekwipunku
public class InventoryPanel : ItemPanel
{
    // Metoda obsługująca kliknięcie w slot ekwipunku
    public override void OnClick(int id)
    {
        // Przekazuje kliknięcie do kontrolera przeciągania i upuszczania przedmiotów
        GameManager.instance.dragandDropController.OnClick(inventory.slots[id]);
        
        // Odświeża wyświetlanie panelu ekwipunku
        Show();
    }
}
