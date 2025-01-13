using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Typy węzłów zasobów, które mogą być zbierane
public enum ResourceNodeType
{
    Undefined, 
    Tree, 
    Ore 
}

[CreateAssetMenu(menuName = "Data/ToolAction/Gather Resource Node")] // Tworzy opcję w menu dla skryptu ScriptableObject

public class GatherResourceNode : ToolAction
{
    [SerializeField] float sizeOfInteractableArea = 1f; // Rozmiar obszaru interakcji z węzłem
    [SerializeField] List<ResourceNodeType> canHitNodesOfType; // Lista typów węzłów, które mogą być trafione

    public override bool OnApply(Vector2 worldPoint)
    {
        // Pobiera wszystkie collidery w określonym obszarze
        Collider2D[] colliders = Physics2D.OverlapCircleAll(worldPoint, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            // Sprawdza, czy collider ma komponent ToolHit
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {
                // Sprawdza, czy węzeł może być trafiony na podstawie listy typów
                if (hit.CanBeHit(canHitNodesOfType) == true)
                {
                    hit.Hit(); // Wywołanie akcji trafienia węzła
                    return true; // Zwraca true, gdy akcja jest zakończona
                }
            }
        }
        return false; // Zwraca false, gdy żaden węzeł nie został trafiony
    }
}
