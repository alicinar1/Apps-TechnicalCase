using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private AbstractInputData[] inputDatas;

    private void Update()
    {
        for (int i = 0; i < inputDatas.Length; i++)
        {
            inputDatas[i].ProcessInput();
        }
    }
}
