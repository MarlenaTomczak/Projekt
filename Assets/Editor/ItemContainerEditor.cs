using System.Collections;
using System.Collections.Generic;
using ICSharpCode.NRefactory.Ast;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

[CustomEditor(typeof(Item_Container))]
public class ItemContainerEditor : Editor
{

   public override void OnInspectorGUI()
    {
        Item_Container container = target as Item_Container;
        if (GUILayout.Button("wyczysc ekwipunek"))
        {
            for(int i=0; i<container.slots.Count; i++)
            {
                container.slots[i].Clear();
            }
            

        }
       DrawDefaultInspector();
    }
}
