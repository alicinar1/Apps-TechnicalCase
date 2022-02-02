using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "TechnicalCase/Input/DragInputData")]
public class DragInputData : AbstractInputData
{
    private float _firstTouchPosition;
    private float _currentTouchPosition;
    public float DragValue;
    public bool isPressed = true;
    private bool isReleased;

    public static event Action<float> OnPlayerLaunch;
    public static event Action<float> OnPlayerDrag;
    public override void ProcessInput()
    {
        if (Input.touchCount == 0)
        {
            return;
        }
        if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
        {
            _firstTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue().x;
            isPressed = true;
        }
        _currentTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue().x;
        DragValue = Mathf.Abs(_currentTouchPosition - _firstTouchPosition) / 10;
        if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Ended)
        {
            isPressed = false;
            OnPlayerLaunch?.Invoke(DragValue);
        }
    }
}
