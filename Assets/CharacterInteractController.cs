using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    character_controler2d character_controller;
    Rigidbody2D rigidbody2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] HighlightController highlightController;
    Character character;
    private void Awake()
    {
        character_controller = GetComponent<character_controler2d >();
        rigidbody2d = GetComponent<Rigidbody2D>();
        character =  GetComponent<Character>();
        
    }
    private void Update()
    {
        Check();
        if (Input.GetMouseButtonDown(1))
        {
            Interact();
        }
    }

    private void Check()
    {
        Vector2 position = rigidbody2d.position + character_controller.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach(Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                highlightController.Highlight(hit.gameObject);
                return;
            }
        }
         highlightController.Hide();
    }
    
    private void Interact()
    {
        Vector2 position = rigidbody2d.position + character_controller.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach(Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact(character);
                break;
            }
        }
    }
}
