using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoSingleton<CameraController>
{
    [SerializeField] private Animator cameraAnimator;

    private void Start()
    {
        SetDragCamera();

    }

    private void OnEnable()
    {
        DragInputData.OnLaunch += SetFlyCamera;
        GameOverHandler.OnGameOver += SetDragCamera;
    }

    private void OnDisable()
    {
        DragInputData.OnLaunch -= SetFlyCamera;
        GameOverHandler.OnGameOver -= SetDragCamera;
    }

    private void SetFlyCamera()
    {
        cameraAnimator.Play("FlyCamera");
    }

    private void SetDragCamera()
    {
        cameraAnimator.Play("DragCamera");
    }
}
