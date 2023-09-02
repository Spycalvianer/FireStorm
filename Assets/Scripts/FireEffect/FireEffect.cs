using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    public ParticleSystem fireParticle;

    public float alpha;
    public float shortAlpha;
    public float normalAlpha;
    public float longAlpha;
    public TornadoSpawn tornadoSpawn;

    private void Update()
    {
        fireParticle.startColor = new Color(255, 255, 255, alpha);
        SetAlpha();

    }
    public void SetAlpha()
    {
        if(tornadoSpawn.distance < tornadoSpawn.shortDistance)
        {
            alpha = shortAlpha;
        }
        if (tornadoSpawn.shortDistance <= tornadoSpawn.distance && tornadoSpawn.distance < tornadoSpawn.longDistance)
        {
            alpha = normalAlpha;
        }
        if (tornadoSpawn.distance >= tornadoSpawn.longDistance)
        {
            alpha = longAlpha;
        }
    }
}
