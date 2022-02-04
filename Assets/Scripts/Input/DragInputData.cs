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
    public float dragValue;
    public bool isPressed = true;

    public static event Action<float> OnPlayerLaunch;
    public static event Action<float> OnPlayerDrag;
    public static event Action OnLaunch;
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
        if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Moved)
        {
            _currentTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue().x;
            dragValue = Mathf.Abs(_currentTouchPosition - _firstTouchPosition) / 10;
            dragValue = Mathf.Clamp(dragValue, 0, 100);
            Debug.Log(dragValue);
        }
        OnPlayerDrag?.Invoke(dragValue);
        if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Ended)
        {
            isPressed = false;
            OnPlayerLaunch?.Invoke(dragValue);
            OnLaunch?.Invoke();
        }
    }

    public override void AddInputDataToManager()
    {
        InputManager.Instance.AddInputData(this);
    }

    public override void RemoveInputDataToManager()
    {
        InputManager.Instance.RemoveInputData(this);
    }
}
