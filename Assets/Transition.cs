using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum TransitonType
{
    Warp,
    Scene
}
public class Transition : MonoBehaviour
{
    [SerializeField] TransitonType transitionType;
    [SerializeField] string sceneNameToTransition;
    [SerializeField] Vector3 targetPosition;
    Transform destination;

    internal void InitiateTransition(Transform toTransition)
    {
        switch (transitionType)
        {
            case TransitonType.Warp:
                Cinemachine.CinemachineBrain currentCamera = Camera.main.GetComponent<Cinemachine.CinemachineBrain>();
                currentCamera.ActiveVirtualCamera.OnTargetObjectWarped(toTransition, destination.position - toTransition.position);
                toTransition.position = new Vector3(destination.position.x, destination.position.y, toTransition.position.z);
                break;
            case TransitonType.Scene:
                GameSceneManager.instance.InnitSwitchScene(sceneNameToTransition, targetPosition);
                break;
        }

    }

    void Start()
    {
        destination = transform.GetChild(1);
    }
}
