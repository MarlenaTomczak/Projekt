﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using System;


[CreateAssetMenu(menuName = "Data/Recipe")] 
public class CraftingRecipe : ScriptableObject
{
    public List<ItemSlot> elements;
    public ItemSlot output;
}
