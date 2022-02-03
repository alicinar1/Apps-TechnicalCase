using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Animator cameraAnimator;

    private void Start()
    {
        SetDragCamera();
        DragInputData.OnLaunch += SetFlyCamera;
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
