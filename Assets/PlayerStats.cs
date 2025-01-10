using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public Slider healthSlider; 
    public Slider energySlider;  
    public float maxHealth = 100f; 
    public float maxEnergy = 100f;
    public float deductionAmount = 30f; 

    public Image regenerateImage; 
    public Image deductImage;     
    public float imageDisplayTime = 5f; 

    void Start()
    {
        healthSlider.maxValue = maxHealth;
        energySlider.maxValue = maxEnergy;
        healthSlider.value = maxHealth;
        energySlider.value = maxEnergy;

        regenerateImage.gameObject.SetActive(false);
        deductImage.gameObject.SetActive(false);
    }

    public void FullyRegenerate()
    {
        healthSlider.value = maxHealth;
        energySlider.value = maxEnergy;

        StartCoroutine(DisplayImageForTime(regenerateImage));
    }

    public void DeductStats()
    {
        healthSlider.value = Mathf.Max(healthSlider.value - deductionAmount, 0f); 
        energySlider.value = Mathf.Max(energySlider.value - deductionAmount, 0f);
        StartCoroutine(DisplayImageForTime(deductImage));
    }

    private IEnumerator DisplayImageForTime(Image imageToDisplay)
    {
        imageToDisplay.gameObject.SetActive(true); 
        yield return new WaitForSeconds(imageDisplayTime); 
        imageToDisplay.gameObject.SetActive(false);
    }
}
