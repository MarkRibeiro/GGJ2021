﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator fadeAnimation;
    public float transitionDuration;

    public void StartChangeScene(string scene)
    {
        if(scene == "Ilha pequena 1")
        {
            TreasueManeger.treasure = false;
        }
        StartCoroutine(ChangeScene(scene));
    }
    public IEnumerator ChangeScene(string scene)
    {
        float time = 0;
        float initialVolume = audioSource.volume;
        fadeAnimation.speed = 1/transitionDuration;
        fadeAnimation.SetTrigger("BeginCrossFade");
        while(time<transitionDuration)
        {
            yield return new WaitForSeconds(0.05f);
            time+=0.05f;
            audioSource.volume = initialVolume - (time * initialVolume / transitionDuration);
        }
        SceneManager.LoadScene(scene);
    }
}
