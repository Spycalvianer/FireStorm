using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLoop : MonoBehaviour
{
    public float movingSpeed;
    public Transform target;
    public Transform loop;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
           transform.position = Vector3.MoveTowards(loop.position, target.position, movingSpeed);
        }
    }
}
