using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBarController : MonoBehaviour
{
    [SerializeField] int ToolBarSize = 7;
    int selectedTool;

    public Action<int> onChange;

    internal void Set(int id)
    {
        selectedTool = id;
    }

    private void Update()
    {
        float delta = Input.mouseScrollDelta.y;
        if(delta!= 0)
        {
            if (delta > 0)
            {
                selectedTool += 1;
                selectedTool = (selectedTool >= ToolBarSize) ? 0 : selectedTool;
            }
            else
            {
                selectedTool -= 1;
                selectedTool = (selectedTool < 0) ? ToolBarSize - 1 : selectedTool;
            }
            onChange?.Invoke(selectedTool);
        }
    }

}