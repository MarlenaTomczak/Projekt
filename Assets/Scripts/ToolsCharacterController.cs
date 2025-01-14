using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Skrypt obsługujący używanie narzędzi i broni przez postać gracza
public class ToolsCharacterController : MonoBehaviour
{
    // Komponenty postaci
    character_controler2d character;
    Rigidbody2D rgbd2d;
    ToolBarController toolbarController;

    [SerializeField] float offsetDistance = 1f; // Odległość używania narzędzia
    [SerializeField] float sizeOfInteractableArea = 1.2f; // Rozmiar obszaru interakcji
    [SerializeField] MarkerManager markerManager; // Zarządca znaczników
    [SerializeField] TileMapReadController tileMapReadController; // Zarządca TileMap
    [SerializeField] float maxDistance = 1.5f; // Maksymalna odległość do interakcji
    [SerializeField] ToolAction onTilePickUp; // Akcja podnoszenia przedmiotu z TileMap
    [SerializeField] IconHighlight iconHighlight; // Podświetlenie ikony

    AttackController attackController; // Zarządca ataku

    Vector3Int selectedTilePosition; // Wybrana pozycja na siatce
    bool selectable; // Czy obecny kafelek jest możliwy do zaznaczenia

    public void Awake()
    {
        // Pobieranie referencji do komponentów
        character = GetComponent<character_controler2d>();
        rgbd2d = GetComponent<Rigidbody2D>();
        toolbarController = GetComponent<ToolBarController>();
        attackController = GetComponent<AttackController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            WeaponAction();
        }

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

    // Obsługuje akcje związane z bronią
    private void WeaponAction()
    {
        Item item = toolbarController.GetItem;
        if (item == null) { return; }
        if (item.isWeapon == false) { return; }

        attackController.Attack(item.damage, character.lastMotionVector);
    }

    // Wybiera kafelek na podstawie pozycji myszy
    private void SelectTile()
    {
        selectedTilePosition = tileMapReadController.GetGridPosition(Input.mousePosition, true);
    }

    // Sprawdza, czy obecnie wybrany kafelek może być zaznaczony
    void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManager.Show(selectable);
        iconHighlight.CanSelect = selectable;
    }

    // Ustawia znacznik na wybranym kafelku
    private void Marker()
    {
        markerManager.markedCellPosition = selectedTilePosition;
        iconHighlight.cellPosition = selectedTilePosition;
    }

    // Używa narzędzia w świecie gry (nie na TileMap)
    private bool UseToolWorld()
    {
        Vector2 position = rgbd2d.position + character.lastMotionVector * offsetDistance;

        Item item = toolbarController.GetItem;
        if (item == null) {
            PickUpTile();
            return false;
        }
        if (item.onAction == null) { return false; }

        bool complete = item.onAction.OnApply(position);

        if (complete == true)
        {
            if (item.OnItemUsed != null)
            {
                item.OnItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
            }
        }

        return complete;
    }

    // Używa narzędzia na siatce kafelków
    private void UseToolGrid()
    {
        if (selectable == true)
        {
            Item item = toolbarController.GetItem;
            if (item == null) { return; }
            if (item.onTileMapAction == null) { return; }

            bool complete = item.onTileMapAction.OnApplyToTileMap(selectedTilePosition, tileMapReadController, item);

            if (complete == true)
            {
                if (item.OnItemUsed != null)
                {
                    item.OnItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
                }
            }
        }
    }

    // Podnosi przedmiot z kafelka TileMap
    private void PickUpTile()
    {
        if (onTilePickUp == null) { return; }

        onTilePickUp.OnApplyToTileMap(selectedTilePosition, tileMapReadController, null);
    }
}
