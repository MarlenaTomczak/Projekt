using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skrypt obsługujący przedmioty możliwe do podniesienia przez gracza
public class PickUpItem : MonoBehaviour
{
    // Referencja do gracza
    Transform player;

    // Prędkość ruchu przedmiotu w kierunku gracza
    [SerializeField] float speed = 5f;

    // Dystans, w którym przedmiot może zostać podniesiony
    [SerializeField] float pickUpDistance = 1.5f;

    // Czas życia przedmiotu w sekundach
    [SerializeField] float ttl = 10f;

    // Przedmiot i jego ilość
    public Item item;
    public int count = 1;

    private void Awake()
    {
        // Ustawienie referencji do gracza
        player = GameManager.instance.player.transform;
    }

    // Ustawia dane przedmiotu i przypisuje ikonę
    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.icon;
    }

    private void Update()
    {
        // Zmniejszanie czasu życia
        ttl -= Time.deltaTime;
        if (ttl < 0)
        {
            Destroy(gameObject); // Usuwanie przedmiotu, jeśli czas życia się skończy
        }

        // Obliczenie dystansu między przedmiotem a graczem
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > pickUpDistance)
        {
            return; // Nie robi nic, jeśli gracz jest za daleko
        }

        // Poruszanie przedmiotu w kierunku gracza
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );

        // Jeśli dystans jest bardzo mały, dodanie przedmiotu do ekwipunku
        if (distance < 0.1f)
        {
            if (GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.Add(item, count); // Dodanie do ekwipunku
            }
            else
            {
                Debug.LogWarning("Brak przypisanego ekwipunku do GameManager");
            }
            Destroy(gameObject); // Usuwanie przedmiot z gry
        }
    }
}