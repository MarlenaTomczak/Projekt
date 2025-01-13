using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skrypt definiujący obiekt przedmiotu w grze jako ScriptableObject
[CreateAssetMenu(menuName = "Data/Item")]
public class Item : ScriptableObject
{
    // Nazwa przedmiotu
    public string Name;

    // Czy przedmiot może być układany w stosy
    public bool stackable;

    // Ikona przedmiotu
    public Sprite icon;

    // Akcja, która jest wywoływana po użyciu narzędzia na przedmiocie
    public ToolAction onAction;

    // Akcja wywoływana po użyciu narzędzia na TileMap
    public ToolAction onTileMapAction;

    // Akcja wywoływana po użyciu przedmiotu
    public ToolAction OnItemUsed;

    // Powiązanie przedmiotu z uprawą
    public Crop crop;

    // Czy ikona przedmiotu ma być podświetlana
    public bool iconHighlight;

    // Prefab powiązany z przedmiotem (np. obiekt w świecie gry)
    public GameObject itemPrefab;

    // Czy przedmiot jest bronią
    public bool isWeapon;

    // Ilość obrażeń zadawanych przez broń
    public int damage = 10;
}
