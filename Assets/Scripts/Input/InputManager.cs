using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private List<AbstractInputData> inputDataList = new List<AbstractInputData>();

    private void Awake()
    {
        DragInputData.OnInputDataStart += AddInputData;
        TapHoldInputData.OnInputDataStart += AddInputData;

        DragInputData.OnInputDataEnd += RemoveInputData;
        TapHoldInputData.OnInputDataEnd += RemoveInputData;
    }

    private void OnDisable()
    {
        DragInputData.OnInputDataStart -= AddInputData;
        TapHoldInputData.OnInputDataStart -= AddInputData;

        DragInputData.OnInputDataEnd -= RemoveInputData;
        TapHoldInputData.OnInputDataEnd -= RemoveInputData;
    }

    private void Update()
    {
        //foreach (AbstractInputData inputData in inputDataList.to)
        //{
        //    inputData.ProcessInput();
        //}
        for (int i = 0; i < inputDataList.Count; i++)
        {
            inputDataList[i].ProcessInput();
        }
    }

    public void AddInputData(AbstractInputData inputData)
    {
        inputDataList.Add(inputData);
        Debug.Log(inputData + "Added");
    }

    public void RemoveInputData(AbstractInputData inputData)
    {
        inputDataList.Remove(inputData);
    }
}
