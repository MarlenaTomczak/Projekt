using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
   const float secondsInDay = 86400f;

   [SerializeField] Color nightLightColor;
   [SerializeField] AnimationCurve nightTimeCurve; 
   [SerializeField] Color dayLightColor = Color.white;
   
   float time;
   [SerializeField] float timeScale = 60f;

   [SerializeField] Text text;

   float Hours 
   {
      get { return time / 3600f; }
   }

   private void Update()
   {
      time += Time.deltaTime * timeScale;
      text.text = Hours.ToString();
   }

}
