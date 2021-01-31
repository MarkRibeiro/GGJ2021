using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public AudioClip arrg;
    public AudioClip victoryClip;
    public AudioClip picareta;
    public AudioSource source;

    private void OnEnable() {
        StartCoroutine(Playsounds());
    }

    private IEnumerator Playsounds(){
        source.PlayOneShot(victoryClip);
        yield return new WaitForSeconds(5.0f);
        source.PlayOneShot(arrg);

    }
}
