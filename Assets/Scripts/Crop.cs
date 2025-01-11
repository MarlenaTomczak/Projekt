using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skrypt dla obiektu przechowującego dane o uprawach
[CreateAssetMenu(menuName = "Data/Crop")]
public class Crop : ScriptableObject
{
    // Czas potrzebny do pełnego wzrostu rośliny (w sekundach lub innym jednostkach)
    public int timeToGrow = 10;

    // Przedmiot reprezentujący pole uprawne
    public Item field;

    // Ilość zbiorów, jakie można uzyskać z jednej rośliny
    public int count = 1;

    // Lista sprite'ów reprezentujących różne etapy wzrostu rośliny
    public List<Sprite> sprites;

    // Lista czasów dla każdego etapu wzrostu rośliny (powiązana ze sprite'ami)
    public List<int> growthStageTime;
}
