using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody rb1;
    public string terrain;
    public float explosionForce;
    public float explosionRadius;

    public float bulletDamage = 15f;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
/*
        if (collision.transform.tag == terrain)
        {
            Destroy(gameObject);

        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            PlayerData playerData;
            playerData = other.GetComponentInParent<PlayerData>();
            playerData.Damage(bulletDamage);
        }
        else if(other.transform.tag == "Enemy")
        {
            EnemyData enemyData;
            enemyData = other.GetComponentInParent<EnemyData>();
            enemyData.DamageEnemy(bulletDamage);
        }/*
        else if (transform.tag == "Enemy")
        {
            rb1 = GetComponent<Rigidbody>();
            rb1.velocity = Vector3.zero;
        }*/
    }
}
