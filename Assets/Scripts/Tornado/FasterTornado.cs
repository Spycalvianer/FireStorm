using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterTornado : MonoBehaviour
{
    public float increasedSpeed;
    public TornadoSpawn tornadoSpawn;
    public CamaraScript camaraScript;
    public GameObject cameraDelante;
    public GameObject cameraDetras;
    public bool triggerActivated;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            tornadoSpawn.tornadoSlowSpeed *= increasedSpeed;
            tornadoSpawn.tornadoFastSpeed *= increasedSpeed;
            tornadoSpawn.tornadoSpeed *= increasedSpeed;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            camaraScript.cameraDetrasIsActive = true;
            cameraDetras.SetActive(true);
            cameraDelante.SetActive(false);
            triggerActivated = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        cameraDetras.SetActive(false);
        cameraDelante.SetActive(true);
    }
}
