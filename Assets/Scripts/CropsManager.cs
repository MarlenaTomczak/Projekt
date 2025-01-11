using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Klasa reprezentująca pojedynczy kafelek z uprawą
[Serializable]
public class CropTile
{
    // Licznik czasu wzrostu
    public int growTimer;

    // Aktualny etap wzrostu rośliny
    public int growStage;

    // Dane o rodzaju uprawy
    public Crop crop;

    // Renderer odpowiedzialny za wyświetlanie rośliny
    public SpriteRenderer renderer;

    // Poziom uszkodzenia rośliny
    public float damage;

    // Pozycja na siatce (gridzie)
    public Vector3Int position;

    // Właściwość sprawdzająca, czy roślina jest gotowa do zbioru
    public bool Complete
    {
        get {
            if (crop == null) { return false; }
            return growTimer >= crop.timeToGrow;
        }
    }

    // Metoda resetująca kafelek po zbiorze
    internal void Harvested()
    {
        growTimer = 0;
        growStage = 0;
        crop = null;
        renderer.gameObject.SetActive(false);
        damage = 0;
    }
}

// Menedżer zarządzający uprawami
public class CropsManager : MonoBehaviour
{
    // Referencja do menedżera upraw na siatce
    public TilemapCropsManager cropsManager;

    // Metoda zbierania plonów z danej pozycji
    public void PickUp(Vector3Int position)
    {
        if (cropsManager == null)
        { 
            Debug.LogWarning("No tilemap crops manager are referenced in the crops manager");
            return; 
        } 
        
        cropsManager.PickUp(position);
    }

    // Metoda sprawdzająca, czy dany kafelek jest zajęty
    public bool Check(Vector3Int position)
    {
        if (cropsManager == null)
        { 
            Debug.LogWarning("No tilemap crops manager are referenced in the crops manager");
            return false; 
        }

        return cropsManager.Check(position);
    }

    // Metoda sadzenia rośliny na danym kafelku
    public void Seed(Vector3Int position, Crop toSeed)
    {
        if (cropsManager == null)
        { 
            Debug.LogWarning("No tilemap crops manager are referenced in the crops manager");
            return; 
        }

        cropsManager.Seed(position, toSeed);
    }

    // Metoda orania danego kafelka
    public void Plow(Vector3Int position)
    {
        if (cropsManager == null)
        { 
            Debug.LogWarning("No tilemap crops manager are referenced in the crops manager");
            return; 
        }

        cropsManager.Plow(position);
    }
}
