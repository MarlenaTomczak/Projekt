using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skrypt zarządzający głównymi elementami gry
public class GameManager : MonoBehaviour
{
    // Statyczna instancja menedżera gry (singleton)
    public static GameManager instance;

    private void Awake()
    {
        // Ustawienie instancji na bieżący obiekt
        instance = this;
    }

    // Referencja do obiektu gracza
    public GameObject player;

    // Referencja do kontenera ekwipunku
    public Item_Container inventoryContainer;

    // Referencja do kontrolera przeciągania i upuszczania przedmiotów
    public itemDragandDropController dragandDropController;

    // Referencja do kontrolera czasu gry (cykl dnia i nocy)
    public DayTimeController timeController;

    // Referencja do menedżera obiektów możliwych do umieszczenia
    public PlaceableObjectReferenceManager placeableObject;
}
