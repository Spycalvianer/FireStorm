using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
    public SceneController sceneManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            sceneManager.Scene("Victory Scene");
        }
    }
}
