using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInputData : ScriptableObject
{
    public abstract void ProcessInput();
    public abstract void AddInputDataToManager();
    public abstract void RemoveInputDataToManager();
}
