using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public int fireForce=5;
    public int destroyBulletTime=5;
    public float bulletLimit = 0;
    public float bulletTimer;
    public float bulletCoolDown = 2;
    public bool isShooting;
    public float maxBullets = 2;

    public AudioSource playerShoot;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0)) 
        {
            isShooting = true;
        }
        if (isShooting) bulletTimer += Time.deltaTime;
        if (bulletTimer >= bulletCoolDown)
        {
            bulletLimit = 0;
            bulletTimer = 0;
            isShooting = false;
        }
        Shoot();
        SoundEffects();
    }
    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && bulletLimit < maxBullets)
        {
            GameObject bulletShoot = Instantiate(bullet, firePoint.position, Quaternion.LookRotation(firePoint.forward));
            Rigidbody rb = bulletShoot.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.forward.normalized * fireForce, ForceMode.VelocityChange);
            Destroy(bulletShoot, destroyBulletTime);
            bulletLimit++;
        }
    }
    void SoundEffects()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            playerShoot.Play();
        }
    }
}
