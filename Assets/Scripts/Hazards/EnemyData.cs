using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public float enemyLife = 10f;

    public void DamageEnemy(float damage)
    {
        if (enemyLife > 0)
        {
            enemyLife -= damage;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
