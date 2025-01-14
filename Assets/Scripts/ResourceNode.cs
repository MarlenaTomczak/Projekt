using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skrypt obsługujący węzły zasobów, które można uderzyć narzędziem
[RequireComponent(typeof(BoxCollider2D))] // Wymaga komponentu BoxCollider2D
public class ResourceNode : ToolHit
{
    // Prefab obiektu, który ma zostać upuszczony
    [SerializeField] GameObject pickUpDrop;

    // Liczba przedmiotów do upuszczenia
    [SerializeField] int dropCount = 5;

    // Rozrzut pozycji upuszczonych przedmiotów
    [SerializeField] float spread = 0.7f;

    // Przedmiot do upuszczenia
    [SerializeField] Item item;

    // Liczba przedmiotów w jednym upuszczonym obiekcie
    [SerializeField] int itemCountInOneDrop = 1;

    // Typ węzła zasobów
    [SerializeField] ResourceNodeType nodeType;

    // Metoda wywoływana po uderzeniu w węzeł
    public override void Hit()
    {
        // Pętla tworząca upuszczone przedmioty
        while (dropCount > 0)
        {
            dropCount -= 1;

            // Losowe przesunięcie pozycji upuszczonych przedmiotów
            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;

            // Wywołanie menedżera do spawnowania przedmiotów
            ItemSpawnMenager.instance.SpawnItem(position, item, itemCountInOneDrop);
        }

        // Zniszczenie obiektu węzła zasobów
        Destroy(gameObject);
    }

    // Sprawdza, czy węzeł może zostać uderzony danym narzędziem
    public override bool CanBeHit(List<ResourceNodeType> canBeHit)
    {
        return canBeHit.Contains(nodeType);
    }
}