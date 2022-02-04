using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoSingleton<CameraController>
{
    [SerializeField] private Animator _cameraAnimator;

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
        _cameraAnimator.Play("FlyCamera");
    }

    private void SetDragCamera()
    {
        _cameraAnimator.Play("DragCamera");
    }
}
