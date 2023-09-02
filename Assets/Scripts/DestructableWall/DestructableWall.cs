using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableWall : MonoBehaviour
{
    public MovementScript playerMovement;
    public PlayerData playerData;
    public float hazardDamage;
    public float collisionForce;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
            playerMovement = other.GetComponent<MovementScript>();
            playerData = other.GetComponent<PlayerData>();
            playerData.Damage(hazardDamage);
            playerMovement.collision = true;
        }
    }
}
