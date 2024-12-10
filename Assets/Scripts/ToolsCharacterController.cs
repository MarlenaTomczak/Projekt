using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolsCharacterController : MonoBehaviour
{
    character_controler2d character;
    Rigidbody2D rgbd2d;
    ToolBarController toolbarController;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController tileMapReadController;
    [SerializeField] float maxDistance = 1.5f;
    [SerializeField] ToolAction onTilePickUp;



    Vector3Int selectedTilePosition;
    bool selectable;

    public void Awake()
    {
        character = GetComponent<character_controler2d>();
        rgbd2d = GetComponent<Rigidbody2D>();
        toolbarController = GetComponent<ToolBarController>();
    }

    private void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        if (Input.GetMouseButtonDown(0))
        {
            if (UseToolWorld() == true)
            {
                return;
            }
            UseToolGrid();
        }
    }

    private void SelectTile()
    {
        selectedTilePosition = tileMapReadController.GetGridPosition(Input.mousePosition, true);
    }

    void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManager.Show(selectable);
    }

    private void Marker()
    {
        markerManager.markedCellPosition= selectedTilePosition;
    }

    private bool UseToolWorld()
    {
        Vector2 position = rgbd2d.position + character.lastMotionVector * offsetDistance;

        Item item = toolbarController.GetItem;
        if (item == null) { 
            PickUpTile();
            return false; 
        }
        if (item.onAction == null) { return false; }

        bool complete = item.onAction. OnApply(position);

        if (complete == true)
            {
                if(item.OnItemUsed != null)
                {
                    item.OnItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
                }
            }

        return complete;
    }

    private void UseToolGrid()
    {
        if (selectable == true)
        {
           Item item = toolbarController. GetItem;
            if (item == null) { return; }
            if (item.onTileMapAction == null) { return; }

            bool complete = item.onTileMapAction.OnApplyToTileMap(selectedTilePosition, tileMapReadController, item);

            if (complete == true)
            {
                if(item.OnItemUsed != null)
                {
                    item.OnItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
                }
            }
        }
    }

    private void PickUpTile()
    {
        if(onTilePickUp == null) { return; }

        onTilePickUp.OnApplyToTileMap(selectedTilePosition, tileMapReadController, null);
    }
}
