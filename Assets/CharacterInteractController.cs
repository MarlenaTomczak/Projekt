using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    character_controler2d character_controller;
    Rigidbody2D rigidbody2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    Character character;
    private void Awake()
    {
        character_controller = GetComponent<character_controler2d >();
        rigidbody2d = GetComponent<Rigidbody2D>();
        character =  GetComponent<Character>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Interact();
        }
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
