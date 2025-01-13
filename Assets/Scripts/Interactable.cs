using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Klasa bazowa dla obiektów interaktywnych w grze
public class Interactable : MonoBehaviour
{
   // Wirtualna metoda obsługująca interakcję postaci z obiektem
   public virtual void Interact(Character character)
   {
      // Domyślne zachowanie przy interakcji (do nadpisania w klasach pochodnych)
   }
}
