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

    //public static event Action<AbstractInputData> OnInputDataStart;
    //public static event Action<AbstractInputData> OnInputDataEnd;
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
            DragValue = Mathf.Abs(_currentTouchPosition - _firstTouchPosition) / 10;
            DragValue = Mathf.Clamp(DragValue, 0, 100);
            Debug.Log(DragValue);
        }
        OnPlayerDrag?.Invoke(DragValue);
        if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Ended)
        {
            isPressed = false;
            OnPlayerLaunch?.Invoke(DragValue);
            OnLaunch?.Invoke();
        }
    }

    public override void AddInputDataToManager()
    {
        //OnInputDataStart?.Invoke(this);
        InputManager.Instance.AddInputData(this);
    }

    public override void RemoveInputDataToManager()
    {
        //OnInputDataEnd?.Invoke(this);
        InputManager.Instance.RemoveInputData(this);
    }
}
