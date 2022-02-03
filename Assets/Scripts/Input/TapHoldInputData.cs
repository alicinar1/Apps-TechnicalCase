using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TechnicalCase/Input/TapHolInputData")]
public class TapHoldInputData : AbstractInputData
{
    public bool isHold;

    public static event Action<AbstractInputData> OnInputDataStart;
    public static event Action<AbstractInputData> OnInputDataEnd;
    public static event Action OnHoldStart;
    public static event Action OnHoldEnd;

    public override void ProcessInput()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
        {
            isHold = true;
            OnHoldStart?.Invoke();
        }

        if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Ended)
        {
            isHold = false;
            OnHoldEnd?.Invoke();
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
