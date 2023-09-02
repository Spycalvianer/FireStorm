using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoSpawn : MonoBehaviour
{
    public GameObject playerPosition;

    public float tornadoSpeed;
    public float tornadoFastSpeed;
    public float tornadoSlowSpeed;
    public float longDistance;
    public float shortDistance;
    public float actualSpeed;
    public float distance;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        TornadoSpawnFunction();
    }
    private void TornadoSpawnFunction()
    {
        Vector3 direccion = playerPosition.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direccion);
        transform.rotation = rotation;
        direccion.Normalize();
        distance = Vector3.Distance(playerPosition.transform.position, transform.position);
        if (distance > longDistance)
        {
            actualSpeed = tornadoFastSpeed;
        }
        else if (distance>shortDistance && distance < longDistance)
        {
            actualSpeed = tornadoSpeed;
        }
        else if (distance < shortDistance)
        {
            actualSpeed = tornadoSlowSpeed;
        }
        Vector3 movement = direccion * actualSpeed * Time.deltaTime;
        transform.position += movement;
    }
}
