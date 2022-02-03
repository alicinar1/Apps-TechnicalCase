using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDataManager : MonoSingleton<InputDataManager>
{
    [SerializeField] private AbstractInputData launchPhaseData;
    [SerializeField] private AbstractInputData flyPhaseData;
    [SerializeField] private AbstractInputData steeringData;

    private void Start()
    {
        
    }

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
        launchPhaseData.RemoveInputDataToManager();
        steeringData.AddInputDataToManager();
        flyPhaseData.AddInputDataToManager();
    }

    private void ActieveDragPhase()
    {
        launchPhaseData.AddInputDataToManager();
        steeringData.RemoveInputDataToManager();
        flyPhaseData.RemoveInputDataToManager();
    }
}
