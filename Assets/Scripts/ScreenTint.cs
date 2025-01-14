using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Skrypt obsługujący efekt przyciemniania i rozjaśniania ekranu
public class ScreenTint : MonoBehaviour
{
    // Kolor po przyciemnieniu
    [SerializeField] Color tintedColor;

    // Kolor po rozjaśnieniu
    [SerializeField] Color unTintedColor;

    // Prędkość efektu przyciemniania/rozjaśniania
    public float speed = 0.5f;

    // Referencja do komponentu Image
    Image image;

    // Współczynnik interpolacji
    float f;

    private void Awake()
    {
        // Pobranie komponentu Image
        image = GetComponent<Image>();
    }

    // Rozpoczyna proces przyciemniania ekranu
    public void Tint()
    {
        StopAllCoroutines(); // Zatrzymuje wszystkie bieżące korutyny
        f = 0f; // Resetuje współczynnik interpolacji
        StartCoroutine(TintScreen()); // Uruchamia korutynę przyciemniania
    }

    // Rozpoczyna proces rozjaśniania ekranu
    public void UnTint()
    {
        StopAllCoroutines(); // Zatrzymuje wszystkie bieżące korutyny
        f = 0f; // Resetuje współczynnik interpolacji
        StartCoroutine(UnTintScreen()); // Uruchamia korutynę rozjaśniania
    }

    // Korutyna przyciemniania ekranu
    private IEnumerator TintScreen()
    {
        while (f < 1f)
        {
            f += Time.deltaTime * speed; // Zwiększa współczynnik interpolacji
            f = Mathf.Clamp(f, 0, 1f); // Ogranicza wartość współczynnika do przedziału [0, 1]

            // Interpoluje kolor między unTintedColor a tintedColor
            Color c = Color.Lerp(unTintedColor, tintedColor, f);
            image.color = c; // Ustawia nowy kolor obrazu

            yield return new WaitForEndOfFrame(); // Czeka do końca klatki
        }
    }

    // Korutyna rozjaśniania ekranu
    private IEnumerator UnTintScreen()
    {
        while (f < 1f)
        {
            f += Time.deltaTime * speed; // Zwiększa współczynnik interpolacji
            f = Mathf.Clamp(f, 0, 1f); // Ogranicza wartość współczynnika do przedziału [0, 1]

            // Interpoluje kolor między tintedColor a unTintedColor
            Color c = Color.Lerp(tintedColor, unTintedColor, f);
            image.color = c; // Ustawia nowy kolor obrazu

            yield return new WaitForEndOfFrame(); // Czeka do końca klatki
        }
    }
}
