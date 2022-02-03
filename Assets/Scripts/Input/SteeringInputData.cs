using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "TechnicalCase/Input/SteeringInputData")]
public class SteeringInputData : AbstractInputData
{
    private float _firstTouchPosition;
    private float _currentTouchPosition;
    [SerializeField]public float _steeringValue;

    public static event Action<AbstractInputData> OnInputDataStart;
    public static event Action<AbstractInputData> OnInputDataEnd;
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
            OnHoldStart?.Invoke(_steeringValue);
        }
        if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Ended)
        {
            _steeringValue = 0;
        }
    }

    public override void AddInputDataToManager()
    {
        OnInputDataStart?.Invoke(this);
    }

    public override void RemoveInputDataToManager()
    {
        OnInputDataEnd?.Invoke(this);
    }
}
