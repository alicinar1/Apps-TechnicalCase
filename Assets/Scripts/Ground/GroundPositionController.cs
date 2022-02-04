using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPositionController : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _parent.position = new Vector3(0, transform.position.y, transform.position.z + 900);
        }
    }
}
