using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{ 
    public void Scene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Scene("Victory Scene");
        }
    }
}
