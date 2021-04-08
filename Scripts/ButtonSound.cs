using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    private AudioSource buttonAudio;
    public GameObject body;
    public GameObject update;
    private AudioSource updateAudio;
    void Start()
    {
        buttonAudio = body.GetComponent<AudioSource>();
        buttonAudio.loop = false;   
        updateAudio = update.GetComponent<AudioSource>();
        updateAudio.loop = false;
    }

    void Update()
    {
        
    }

    public void buttonclick() {
        ClickSound(buttonAudio);
    }

    public void updateclick() {
        ClickSound(updateAudio);
    }

    public void ClickSound(AudioSource whataudio) {
        whataudio.Play();
    }
}
