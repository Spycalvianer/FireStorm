using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcantarillaScript : MonoBehaviour
{
    bool collision;
    PlayerData playerData;
    public float alcantarillaDamage;
    public float speedLossTimer;
    public float speedLossTime;
    public float speedLossMultiplier;
    MovementScript playerMovement;

    private void OnTriggerEnter(Collider other)
    {
        playerData = other.GetComponent<PlayerData>();
        playerMovement = other.GetComponent<MovementScript>();
        playerData.playerLife -= alcantarillaDamage;
        collision = true;
    }
    private void Update()
    {
        Collision();
    }
    void Collision()
    {
        if (collision)
        {
            speedLossTimer += Time.deltaTime;
            if (speedLossTimer < speedLossTime)
            {
                playerMovement.speed = playerMovement.speed * speedLossMultiplier;
            }
            else if (speedLossTimer >= speedLossTime)
            {
                collision = false;
                playerMovement.speed = 1000;
            }
        }
        else if (!collision && speedLossTimer >= speedLossTime)
        {
            speedLossTimer = 0;
            playerMovement.speed = 1000;
        }
    }
}
