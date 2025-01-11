using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Skrypt dla obiektu przechowującego dane o uprawach na siatce (gridzie)
[CreateAssetMenu(menuName = "Data/Crops Container")]
public class CropsContainer : ScriptableObject
{
    // Lista wszystkich upraw na siatce
    public List<CropTile> crops;

    // Pobiera uprawę na podstawie pozycji na siatce
    public CropTile Get(Vector3Int position)
    {
        return crops.Find(x => x.position == position);
    }

    // Dodaje nową uprawę do listy
    public void Add(CropTile crop)
    {
        crops.Add(crop);
    }
}
