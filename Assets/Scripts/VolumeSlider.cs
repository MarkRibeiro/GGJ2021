﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    private Slider volumeSlider;
    public AudioMixer gameMixer;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider = GetComponent<Slider>();
        volumeSlider.onValueChanged.AddListener(changeVolume);
        if(PlayerPrefs.HasKey("Volume")) gameMixer.SetFloat("mixerVolume", PlayerPrefs.GetFloat("Volume"));
        else gameMixer.SetFloat("mixerVolume", 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeVolume(float currentValue)
    {
        PlayerPrefs.SetFloat("Volume", currentValue);
        gameMixer.SetFloat("mixerVolume", currentValue);
    }
}
