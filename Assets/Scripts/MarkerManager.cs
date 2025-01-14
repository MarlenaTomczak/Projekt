using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Skrypt obsługujący zarządzanie znacznikami na siatce kafelków
public class MarkerManager : MonoBehaviour
{
    // Siatka kafelków, na której będą ustawiane znaczniki
    public Tilemap targetTilemap;

    // Kafelek używany jako znacznik
    [SerializeField] TileBase tile;

    // Pozycja komórki aktualnie oznaczonej znacznikiem
    public Vector3Int markedCellPosition;

    // Poprzednia pozycja komórki znacznika
    Vector3Int oldCellPosition;

    // Flaga określająca, czy znacznik jest widoczny
    bool show;

    private void Update()
    {
        // Jeśli znacznik nie jest widoczny, zakończ działanie
        if (show == false) { return; }

        // Usuń znacznik z poprzedniej pozycji
        targetTilemap.SetTile(oldCellPosition, null);

        // Ustaw znacznik na nowej pozycji
        targetTilemap.SetTile(markedCellPosition, tile);

        // Zaktualizuj poprzednią pozycję
        oldCellPosition = markedCellPosition;
    }

    // Pokazuje lub ukrywa znaczniki na siatce kafelków
    internal void Show(bool selectable)
    {
        show = selectable;

        // Włącza lub wyłącza widoczność siatki kafelków
        targetTilemap.gameObject.SetActive(show);
    }
}