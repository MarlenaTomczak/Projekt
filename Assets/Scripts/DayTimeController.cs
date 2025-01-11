using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

// Skrypt kontrolujący cykl dnia i nocy oraz powiązane zdarzenia
public class DayTimeController : MonoBehaviour
{
   const float secondsInDay = 86400f; // Liczba sekund w dniu
   const float phaseLength = 900f; // Długość jednej fazy czasu (15 minut)

   [SerializeField] Color nightLightColor; // Kolor światła w nocy
   [SerializeField] AnimationCurve nightTimeCurve; // Krzywa określająca zmianę światła w nocy
   [SerializeField] Color dayLightColor = Color.white; // Kolor światła w ciągu dnia

   float time; // Aktualny czas w sekundach
   [SerializeField] float timeScale = 60f; // Skala czasu (ile sekund rzeczywistych odpowiada jednej sekundzie w grze)
   [SerializeField] float startAtTime = 28800f; // Startowy czas (w sekundach, domyślnie 8:00)

   [SerializeField] Text text; // Referencja do tekstu wyświetlającego czas
   [SerializeField] Light2D globalLight; // Referencja do globalnego światła
   private int days; // Licznik dni

   List<TimeAgent> agents; // Lista agentów czasu (obiektów reagujących na zmiany czasu)

   private void Awake()
   {
      agents = new List<TimeAgent>();
   }

   private void Start()
   {
      time = startAtTime; // Ustawienie początkowego czasu
   }

   // Subskrypcja agenta czasu do listy
   public void Subscribe(TimeAgent timeAgent)
   {
      agents.Add(timeAgent);
   }

   // Wyrejestrowanie agenta czasu z listy
   public void Unsubscribe(TimeAgent timeAgent)
   {
      agents.Remove(timeAgent);
   }

   // Właściwość zwracająca liczbę godzin
   float Hours 
   {
      get { return time / 3600f; }
   }

   // Właściwość zwracająca liczbę minut
   float Minutes 
   {
      get { return time % 3600f / 60f; }
   }

   private void Update()
   {
      time += Time.deltaTime * timeScale; // Aktualizacja czasu z uwzględnieniem skali czasu

      TimeValuecalculation(); // Aktualizacja wyświetlanego czasu

      DayLight(); // Aktualizacja światła w zależności od pory dnia

      if (time > secondsInDay)
      {
         NextDay(); // Przejście do następnego dnia
      }

      TimeAgents(); // Wywołanie zdarzeń związanych z fazami czasu
   }

   // Aktualizacja wyświetlanego czasu w formacie HH:MM
   private void TimeValuecalculation()
   {
      int hh = (int)Hours;
      int mm = (int)Minutes;
      text.text = hh.ToString("00") + ":" + mm.ToString("00");
   }

   // Aktualizacja koloru światła w zależności od pory dnia
   private void DayLight()
   {
      float v = nightTimeCurve.Evaluate(Hours); // Obliczenie wartości na podstawie krzywej
      Color c = Color.Lerp(dayLightColor, nightLightColor, v); // Interpolacja koloru światła
      globalLight.color = c;
   }

   int oldPhase = 0; // Zmienna przechowująca poprzednią fazę czasu

   // Wywoływanie zdarzeń agentów czasu przy zmianie fazy
   private void TimeAgents()
   {
      int currentPhase = (int)(time / phaseLength); // Obliczenie aktualnej fazy

      if (oldPhase != currentPhase)
      {
         oldPhase = currentPhase;
         for (int i = 0; i < agents.Count; i++)
         {
            agents[i].Invoke(); // Wywołanie zdarzenia agenta czasu
         }
      }
   }

   // Reset czasu i zwiększenie licznika dni przy przejściu do następnego dnia
   private void NextDay()
   {
      time = 0;
      days += 1;
   }
}
