using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryAgain : MonoBehaviour
{

    public AudioClip failedClip;
    public AudioSource source;
    public AudioClip picareta;
    private void OnEnable() {
        source.PlayOneShot(picareta);
        source.PlayOneShot(failedClip);
    }
 
}
