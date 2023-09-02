using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.rigidbody.useGravity = false;
            collision.transform.SetParent(gameObject.transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        collision.rigidbody.useGravity = true;

    }
}
