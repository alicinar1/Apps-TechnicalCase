using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPointSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _jumpPointPrefabs;
    [SerializeField] private Transform _parentObject;
    [SerializeField] private int _jumpPointCount;
    private List<Transform> _jumpPoints; 

    private void Start()
    {
        for (int i = 0; i < _jumpPointCount; i++)
        {
            var jumpPoint = Instantiate(_jumpPointPrefabs[Random.Range(0, _jumpPointPrefabs.Length)], Vector3.zero, Quaternion.identity, _parentObject);
            jumpPoint.transform.localPosition = GetRandomPosition();
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 position = new Vector3(Random.Range(-120, 120), 1, Random.Range(-220, 220));
        return position;
    }
}
