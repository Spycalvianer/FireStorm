using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionDeVictoria : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Time.timeScale = 0;
            //Activar Panel
        }
    }
}
