using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Skrypt obsługujący podświetlanie ikon na siatce kafelków
public class IconHighlight : MonoBehaviour
{
    // Pozycja komórki na siatce kafelków
    public Vector3Int cellPosition;

    // Pozycja celu w świecie gry
    Vector3 targetPosition;

    // Referencja do docelowej siatki kafelków
    [SerializeField] Tilemap targetTilemap;

    // Renderer dla ikony
    SpriteRenderer spriteRenderer;

    // Flagi sterujące widocznością i możliwością wyboru
    bool canSelect;
    bool show;

    // Właściwość kontrolująca możliwość wyboru
    public bool CanSelect
    {
        set {
            canSelect = value;
            gameObject.SetActive(canSelect && show);
        }
    }

    // Właściwość kontrolująca widoczność
    public bool Show
    {
        set {
            show = value;
            gameObject.SetActive(canSelect && show); 
        }
    }

    // Aktualizacja pozycji obiektu na podstawie komórki siatki
    private void Update()
    {
        targetPosition = targetTilemap.CellToWorld(cellPosition); // Konwersja pozycji komórki na pozycję świata
        transform.position = targetPosition + targetTilemap.cellSize / 2; // Ustawienie pozycji obiektu na środek komórki
    }

    // Ustawienie ikony dla podświetlenia
    internal void Set(Sprite icon)
    {
        if (spriteRenderer == null) 
        { 
            spriteRenderer = GetComponent<SpriteRenderer>(); // Pobranie referencji do SpriteRenderer, jeśli nie jest ustawiona
        }

        spriteRenderer.sprite = icon; // Ustawienie sprite'a ikony
    }
}
