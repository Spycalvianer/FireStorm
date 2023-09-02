using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards_Damage : MonoBehaviour
{
    public bool collision = false;
    public float hazardDamage;
    public PlayerData playerData;
    public MovementScript movementScript;
    public float speedLossTimer;
    public float speedLossTime = 2;
    public float speedLossMultiplier;

    private void OnTriggerEnter(Collider other)
    {
        movementScript = other.GetComponent<MovementScript>();
        if (other.transform.tag == "Player")
        {
            playerData = other.GetComponent<PlayerData>();
            movementScript = other.GetComponent <MovementScript>();
            playerData.Damage(hazardDamage);
            movementScript.collision = true;
            Destroy(gameObject);
        }

    }
}
