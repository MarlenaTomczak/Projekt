using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

// Klasa obsługująca odczyt danych z Tilemap
public class TileMapReadController : MonoBehaviour
{
	[SerializeField] Tilemap tilemap; // Referencja do Tilemap
	public CropsManager cropsManager; // Menedżer obsługujący uprawy
	public PlaceableObjectReferenceManager objectManager; // Menedżer obiektów możliwych do umieszczenia
	
	// Pobiera pozycję siatki na podstawie pozycji w świecie lub pozycji myszy
	public Vector3Int GetGridPosition(Vector2 position, bool mousePosition)
	{
		if (tilemap == null)
		{
			tilemap = GameObject.Find("BaseTilemap").GetComponent<Tilemap>(); // Znajduje Tilemap w scenie
		}

		if (tilemap == null) { return Vector3Int.zero; } // Zwraca zero, jeśli Tilemap nie istnieje

		Vector3 worldPosition;

		if (mousePosition)
		{
			worldPosition = Camera.main.ScreenToWorldPoint(position); // Pobiera pozycję myszy w świecie
		}
		else {
			worldPosition = position; // Używa przekazanej pozycji
		}

		Vector3Int gridPosition = tilemap.WorldToCell(worldPosition); // Konwertuje na pozycję siatki
		
		return gridPosition;
	}

	// Pobiera kafelek TileBase na podstawie pozycji siatki
	public TileBase GetTileBase(Vector3Int gridPosition)
	{
		if (tilemap == null)
		{
			tilemap = GameObject.Find("BaseTilemap").GetComponent<Tilemap>(); // Znajduje Tilemap w scenie
		}

		if (tilemap == null) { return null; } // Zwraca null, jeśli Tilemap nie istnieje

		TileBase tile = tilemap.GetTile(gridPosition); // Pobiera kafelek na podstawie pozycji

		return tile;
	}
};