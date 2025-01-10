using UnityEngine;

public class bed : MonoBehaviour
{
    public PlayerStats playerStats; 

    private void OnMouseDown()
    {
        if (playerStats != null)
        {
            playerStats.FullyRegenerate();
        }
    }
}
