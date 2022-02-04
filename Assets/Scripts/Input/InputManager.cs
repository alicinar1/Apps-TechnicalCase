using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    [SerializeField] private List<AbstractInputData> _inputDataList = new List<AbstractInputData>();

    private void Update()
    {
        for (int i = 0; i < _inputDataList.Count; i++)
        {
            _inputDataList[i].ProcessInput();
        }
    }

    public void AddInputData(AbstractInputData inputData)
    {
        _inputDataList.Add(inputData);
        Debug.Log(inputData + "Added");
        Debug.Log(_inputDataList.Count);
    }

    public void RemoveInputData(AbstractInputData inputData)
    {
        _inputDataList.Remove(inputData);
        Debug.Log(inputData + "Removed");
    }
}
