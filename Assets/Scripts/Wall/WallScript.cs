using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public float hazardDamage;
    public PlayerData playerData;
    public MovementScript movementScript;
    public float withdrawForce;
    private void OnTriggerEnter(Collider other)
    {
        movementScript = other.GetComponent<MovementScript>();
        if (other.transform.tag == "Player")
        {
            playerData.Damage(hazardDamage);
            other.attachedRigidbody.AddForce(withdrawForce * -other.transform.forward, ForceMode.Impulse);
        }
    }
}

