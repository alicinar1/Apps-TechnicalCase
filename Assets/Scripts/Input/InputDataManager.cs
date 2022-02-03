using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDataManager : MonoBehaviour
{
    [SerializeField] private AbstractInputData launchPhaseData;
    [SerializeField] private AbstractInputData flyPhaseData;

    private void Start()
    {
        launchPhaseData.AddInputDataToManager();
        DragInputData.OnLaunch += ActivateFlyPhase;
    }

    private void ActivateFlyPhase()
    {
        launchPhaseData.RemoveInputDataToManager();
        flyPhaseData.AddInputDataToManager();
    }
}
