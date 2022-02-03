using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPointSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] jumpPointPrefabs;
    [SerializeField] private Transform parentObject;
    [SerializeField] private int jumpPointCount;
    private List<Transform> jumpPoints; 

    private void Start()
    {
        for (int i = 0; i < jumpPointCount; i++)
        {
            var jumpPoint = Instantiate(jumpPointPrefabs[Random.Range(0, jumpPointPrefabs.Length)], Vector3.zero, Quaternion.identity, parentObject);
            jumpPoint.transform.localPosition = GetRandomPosition();
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 position = new Vector3(Random.Range(-120, 120), 0, Random.Range(-220, 220));
        return position;
    }
}
