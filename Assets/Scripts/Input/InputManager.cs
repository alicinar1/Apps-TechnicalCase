using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private List<AbstractInputData> inputDataList = new List<AbstractInputData>();

    private void Awake()
    {
        inputDataList.Clear();
        DragInputData.OnInputDataStart += AddInputData;
        SteeringInputData.OnInputDataStart += AddInputData;
        TapHoldInputData.OnInputDataStart += AddInputData;

        DragInputData.OnInputDataEnd += RemoveInputData;
        TapHoldInputData.OnInputDataEnd += RemoveInputData;
        SteeringInputData.OnInputDataEnd += RemoveInputData;
    }

    private void OnDisable()
    {
        DragInputData.OnInputDataStart -= AddInputData;
        TapHoldInputData.OnInputDataStart -= AddInputData;
        SteeringInputData.OnInputDataStart -= AddInputData;

        DragInputData.OnInputDataEnd -= RemoveInputData;
        TapHoldInputData.OnInputDataEnd -= RemoveInputData;
        SteeringInputData.OnInputDataEnd -= RemoveInputData;
    }

    private void Update()
    {
        for (int i = 0; i < inputDataList.Count; i++)
        {
            inputDataList[i].ProcessInput();
        }
    }

    public void AddInputData(AbstractInputData inputData)
    {
        inputDataList.Add(inputData);
        Debug.Log(inputData + "Added");
        Debug.Log(inputDataList.Count);
    }

    public void RemoveInputData(AbstractInputData inputData)
    {
        inputDataList.Remove(inputData);
        Debug.Log(inputData + "Removed");
    }
}
