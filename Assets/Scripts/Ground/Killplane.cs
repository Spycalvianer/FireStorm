using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killplane : MonoBehaviour
{
    public GameObject player;
    public PlayerData playerData;
    public float killplaneDamage;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            playerData.Damage(killplaneDamage);
        }
    }
}
