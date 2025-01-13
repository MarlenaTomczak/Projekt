using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

// Menedżer obsługujący generowanie przedmiotów do podniesienia w grze
public class ItemSpawnMenager : MonoBehaviour
{
    // Statyczna instancja menedżera (singleton)
    public static ItemSpawnMenager instance;

    // Prefab obiektu reprezentującego przedmiot do podniesienia
    [SerializeField] GameObject pickUpItemPrefab;

    private void Awake()
    {
        // Ustawienie statycznej instancji na bieżący obiekt
        instance = this;
    }

    // Metoda generująca przedmiot w określonej pozycji
    public void SpawnItem(Vector3 position, Item item, int count)
    {
        // Tworzy instancję prefabrykat obiektu w podanej pozycji
        GameObject o = Instantiate(pickUpItemPrefab, position, Quaternion.identity);

        // Ustawia dane przedmiotu (rodzaj i ilość) w obiekcie
        o.GetComponent<PickUpItem>().Set(item, count);
    }
}
