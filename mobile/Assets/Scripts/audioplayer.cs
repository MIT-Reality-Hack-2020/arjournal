using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioplayer : MonoBehaviour
{


    public AudioSource audioSource;
    public AudioClip audioClip;
    bool play;
    bool stop;
    Component halo;

    private void Start()
    {
        halo = GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
        play = false;
        stop = true;
    }

    void OnMouseDown()
    {
        print("Mouse Down");
        audioSource.clip = audioClip;
        if (play == false){
            audioSource.Play();
            play = true;
            stop = false;
            halo.GetType().GetProperty("enabled").SetValue(halo, true, null);

        }
        else if (stop == false)
        {
            audioSource.Stop();
            play = false;
            stop = true;
            halo.GetType().GetProperty("enabled").SetValue(halo, false, null);

        }
    }
}
