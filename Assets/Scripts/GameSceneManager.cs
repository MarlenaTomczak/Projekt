using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEditor;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;

    private void Awake()
    {
        // Ustawienie instancji klasy, aby umożliwić dostęp do niej jako singleton
        instance = this;
    }

    [SerializeField] ScreenTint screenTint; // Odniesienie do obiektu odpowiedzialnego za efekt tinty ekranu
    [SerializeField] CameraConfiner cameraConfiner; // Odniesienie do obiektu odpowiedzialnego za ograniczanie kamery

    string currentScene; // Nazwa obecnie załadowanej sceny
    AsyncOperation unload; // Operacja asynchronicznego odładowania sceny
    AsyncOperation load; // Operacja asynchronicznego ładowania nowej sceny
    void Start()
    {
        // Ustawienie początkowej nazwy sceny na aktywną scenę
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void InnitSwitchScene(string to, Vector3 targetPosition)
    {
        // Inicjalizacja przejścia pomiędzy scenami
        StartCoroutine(Transition(to, targetPosition));
    }
    IEnumerator Transition(string to, Vector3 targetPosition)
    {
        // Efekt tinty ekranu przed zmianą sceny
        screenTint.Tint();
        yield return new WaitForSeconds(1f / screenTint.speed + 0.1f); // Oczekiwanie na zakończenie efektu tinty
        SwitchScene(to, targetPosition); // Wywołanie metody zmieniającej scenę
        while (load != null & unload != null) 
        { 
            // Oczekiwanie na zakończenie operacji ładowania i odładowania scen
            if(load.isDone)
            {
                load = null;
            }
            if (unload.isDone) 
            { 
                unload = null;
            }
            yield return new WaitForSeconds(0.1f); // Krótkie opóźnienie w pętli
        }

        // Ustawienie aktywnej sceny na nowo załadowaną scenę
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentScene));

        // Aktualizacja ograniczeń kamery po zmianie sceny
        cameraConfiner.UpdateBounds();
        screenTint.UnTint(); // Usunięcie efektu tinty ekranu
    }
    public void SwitchScene(string to, Vector3 targetPosition)
    {
        // Rozpoczęcie asynchronicznego ładowania nowej sceny
        load = SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
        // Rozpoczęcie asynchronicznego odładowania bieżącej sceny
        unload = SceneManager.UnloadSceneAsync(currentScene);
        currentScene = to; // Aktualizacja nazwy bieżącej sceny
        Transform playerTransform = GameManager.instance.player.transform; // Pobranie transform gracza
        CinemachineBrain currentCamera = Camera.main.GetComponent<CinemachineBrain>(); // Pobranie aktualnej kamery
        currentCamera.ActiveVirtualCamera.OnTargetObjectWarped(playerTransform, targetPosition - playerTransform.position); // Przesunięcie celu kamery na nową pozycję
        playerTransform.position = new Vector3 (targetPosition.x, targetPosition.y, playerTransform.position.z); // Ustawienie nowej pozycji gracza
    }
}
