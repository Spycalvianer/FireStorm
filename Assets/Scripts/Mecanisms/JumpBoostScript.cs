using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoostScript : MonoBehaviour
{
    MovementScript movementScript;
    public float jumpMult;
    public float initialJump = 25f;

    private void OnTriggerEnter(Collider other)
    {
        movementScript = other.GetComponentInParent<MovementScript>();
        if (other.tag == "Player")
        {
            movementScript.jumpForce *= jumpMult;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        movementScript.jumpForce = initialJump;
    }
}
