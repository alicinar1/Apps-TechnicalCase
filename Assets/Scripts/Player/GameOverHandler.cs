using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Debug.Log(other.tag);
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);
            Debug.Log(SceneManager.GetActiveScene().name);
        }
    }
}
