using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "TechnicalCase/Input/SteeringInputData")]
public class SteeringInputData : AbstractInputData
{
    [SerializeField] public float _steeringValue;

    private float _firstTouchPosition;
    private float _currentTouchPosition;

    public static event Action<float> OnHoldStart;
    public static event Action OnHoldEnd;

    public override void ProcessInput()
    {
        if (Input.touchCount == 0)
        {
            return;
        }
        if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
        {
            _firstTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue().x;
        }
        if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Moved)
        {
            _currentTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue().x;
            _steeringValue = (_currentTouchPosition - _firstTouchPosition) / 10;
            _steeringValue = Mathf.Clamp(_steeringValue, -5, 5);
            OnHoldStart?.Invoke(_steeringValue);
        }
        if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Ended)
        {
            _steeringValue = 0;
            _steeringValue = Mathf.Clamp(_steeringValue, -5, 5);
            OnHoldStart?.Invoke(_steeringValue);
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
