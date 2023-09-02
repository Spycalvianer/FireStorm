using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerSearch : MonoBehaviour
{
    public SceneController controller;
    private void Update()
    {
        SearchPlayer();
    }
    void SearchPlayer()
    {
        if (FindObjectOfType <PlayerData>() == null)
        {
            controller.Scene("Game Over");
        }
    }
}
