using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Typy przejść: teleportacja lub zmiana sceny
public enum TransitonType
{
    Warp,
    Scene
}

// Klasa obsługująca przejścia między lokacjami lub scenami
public class Transition : MonoBehaviour
{
    [SerializeField] TransitonType transitionType; // Typ przejścia
    [SerializeField] string sceneNameToTransition; // Nazwa sceny docelowej (dla przejść scen)
    [SerializeField] Vector3 targetPosition; // Docelowa pozycja (dla przejść scen)
    Transform destination; // Miejsce docelowe dla teleportacji

    // Inicjalizuje przejście dla określonego obiektu
    internal void InitiateTransition(Transform toTransition)
    {
        switch (transitionType)
        {
            case TransitonType.Warp:
                // Teleportacja obiektu do miejsca docelowego
                Cinemachine.CinemachineBrain currentCamera = Camera.main.GetComponent<Cinemachine.CinemachineBrain>();
                currentCamera.ActiveVirtualCamera.OnTargetObjectWarped(toTransition, destination.position - toTransition.position);
                toTransition.position = new Vector3(destination.position.x, destination.position.y, toTransition.position.z);
                break;

            case TransitonType.Scene:
                // Przejście do innej sceny
                GameSceneManager.instance.InnitSwitchScene(sceneNameToTransition, targetPosition);
                break;
        }
    }

    // Ustawienie punktu docelowego teleportacji na dziecko obiektu
    void Start()
    {
        destination = transform.GetChild(1);
    }
}