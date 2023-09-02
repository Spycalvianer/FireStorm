using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonDestructableWall : MonoBehaviour
{
    public MovementScript movementScript;
    public float hazardDamage;
    public PlayerData playerData;

    private void OnTriggerEnter(Collider other)
    {
        movementScript = other.GetComponent<MovementScript>();
        if (other.transform.tag == "Player")
        {
            movementScript = other.GetComponent<MovementScript>();
            playerData = other.GetComponent<PlayerData>();
            playerData.Damage(hazardDamage);
            movementScript.collision = true;
        }
    }
}
