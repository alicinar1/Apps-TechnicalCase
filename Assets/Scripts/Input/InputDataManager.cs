using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDataManager : MonoSingleton<InputDataManager>
{
    [SerializeField] private AbstractInputData _launchPhaseData;
    [SerializeField] private AbstractInputData _flyPhaseData;
    [SerializeField] private AbstractInputData _steeringData;

    private void OnEnable()
    {
        ActieveDragPhase();
        DragInputData.OnLaunch += ActivateFlyPhase;
    }

    private void OnDisable()
    {
        DragInputData.OnLaunch -= ActivateFlyPhase;
    }

    private void ActivateFlyPhase()
    {
        _launchPhaseData.RemoveInputDataToManager();
        _steeringData.AddInputDataToManager();
        _flyPhaseData.AddInputDataToManager();
    }

    private void ActieveDragPhase()
    {
        _launchPhaseData.AddInputDataToManager();
        _steeringData.RemoveInputDataToManager();
        _flyPhaseData.RemoveInputDataToManager();
    }
}
