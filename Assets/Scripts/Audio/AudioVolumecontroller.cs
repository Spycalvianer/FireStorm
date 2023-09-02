using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioVolumecontroller : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetVolumeLevel (float sliderValue)
    {
        mixer.SetFloat("MasterParam", Mathf.Log10(sliderValue) * 20);
    }
    public void SetMusicLevel(float sliderValue)
    {
        mixer.SetFloat("MusicParam", Mathf.Log10(sliderValue) * 20);
    }
    public void SetEffectsLevel(float sliderValue)
    {
        mixer.SetFloat("SFXParam", Mathf.Log10(sliderValue) * 20);
    }
}
