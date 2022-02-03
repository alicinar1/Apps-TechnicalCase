using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    [SerializeField] private List<AbstractInputData> inputDataList = new List<AbstractInputData>();

    private void Start()
    {
        //inputDataList.Clear();
    }

    private void OnDisable()
    {

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
