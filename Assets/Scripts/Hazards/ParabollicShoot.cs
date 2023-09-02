using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabollicShoot : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject bullet;
    public int fireForce;
    public int destroyBulletTime = 5;
    public GameObject playerPosition;
    public GameObject bodyPosition;

    public float timer;
    public float turretCooldown;
    public float detectionZone;

    private void Update()
    {
        Vector3 direccion = playerPosition.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direccion);
        if(direccion.magnitude < detectionZone)
        {
            bodyPosition.transform.rotation = rotation;
            timer += Time.deltaTime;

            for (int i = 0; i < firePoints.Length; i++)
            {
                if (timer >= turretCooldown)
                {
                    GameObject bulletShoot = Instantiate(bullet, firePoints[i].position, Quaternion.LookRotation(firePoints[i].forward));
                    Rigidbody rb = bulletShoot.GetComponent<Rigidbody>();
                    rb.AddForce(direccion.normalized * fireForce, ForceMode.VelocityChange);
                    Destroy(bulletShoot, destroyBulletTime);
                    if(i==firePoints.Length - 1) timer = 0;
                }
            }
        }
       
    }
}
