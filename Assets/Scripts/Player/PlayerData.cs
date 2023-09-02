using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public SceneController sceneManager;
    public float playerLife;
    public float playerMaxLife;
    bool playerIsDead;

    public AudioSource naveHit;

    private void Start()
    {
        playerMaxLife = playerLife;
    }
    private void Update()
    {
        DestroyGameObject();
        ChangeScene();
    }
    public void Damage(float damage)
    {
        playerLife -= damage;
    }
    public void DestroyGameObject()
    {
        if (playerLife < 0)
        {
            //Destroy(gameObject);
            playerIsDead = true;
        }
    }
    public void ChangeScene()
    {
        if (playerIsDead)
        {
            sceneManager.Scene("Game Over");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Untagged")
        {
            naveHit.Play();
        }
    }
}
