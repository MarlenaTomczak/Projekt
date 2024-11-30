using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
public class ItemSpawnMenager : MonoBehaviour
{
    public static ItemSpawnMenager instance;
    [SerializeField] GameObject pickUpItemPrefab;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnItem(Vector3 position, Item item, int count)
    {
        GameObject o = Instantiate(pickUpItemPrefab, position, Quaternion.identity);
        o.GetComponent<PickUpItem>().Set(item,count);   
    }
}
