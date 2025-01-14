using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Skrypt definiujący dane dotyczące kafelków
[CreateAssetMenu(menuName = "Data/Tile Data")]
public class TileData : ScriptableObject
{
    // Lista kafelków powiązanych z tymi danymi
    public List<TileBase> tiles;

    // Czy kafelek może być zaorany
    public bool plowable;
}