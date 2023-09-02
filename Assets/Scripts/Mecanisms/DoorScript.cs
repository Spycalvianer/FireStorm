using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    public GameObject enemiesLeft;
    public GameObject tornado;
    public int numberOfTurrets;
    public Transform puertaDerecha;
    public Vector3 openDistance;
    public Transform puertaIzquierda;
    public Text enemiesLeftText;
    public AudioSource openDoor;

    private void Start()
    {
        enemiesLeft.SetActive(true);
    }
    private void Update()
    {
        enemiesLeftText.text = "Enemies left" + " " + numberOfTurrets;
        numberOfTurrets = FindObjectsOfType<LinearShooting>().Length;
        if(numberOfTurrets <= 0)
        {
            puertaDerecha.position += openDistance * Time.deltaTime;
            puertaIzquierda.position -= openDistance * Time.deltaTime;
            tornado.SetActive(true);
            enemiesLeft.SetActive(false);
            openDoor.Play();
        }
    }
}
