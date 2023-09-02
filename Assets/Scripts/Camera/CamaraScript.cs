using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    public GameObject cameraDelante;
    public GameObject cameraDetras;
    public bool cameraDetrasIsActive;
    public FasterTornado fastertornado;
    public AudioSource EpicRaceMusic;
    public AudioSource MakeUpTimeMusic;
    public TornadoSpawn tornado;

    private void Awake()
    {
        EpicRaceMusic = GetComponent<AudioSource>();
        EpicRaceMusic.enabled = false;
    }
    private void LateUpdate()
    {
        CameraChange();
        /*
        if (cameraDetrasIsActive)
        {
            cameraDelante.SetActive(false);
            cameraDetras.SetActive(true);
        }
        else
        {
            cameraDetras.SetActive(false);
            cameraDelante.SetActive(true);
        }*/
    }
    void CameraChange()
    {
        cameraDetrasIsActive = Input.GetButton("Fire2");
        if (cameraDetrasIsActive || fastertornado.triggerActivated)
        {
            cameraDelante.SetActive(false);
            cameraDetras.SetActive(true);
        }
        else
        {
            cameraDetras.SetActive(false);
            cameraDelante.SetActive(true);
        }
        if (tornado.isActiveAndEnabled)
        {
            MakeUpTimeMusic.Stop();
            EpicRaceMusic.enabled = true;
        }
    }
}
