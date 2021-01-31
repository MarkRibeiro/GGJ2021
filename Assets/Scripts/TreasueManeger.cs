using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreasueManeger : MonoBehaviour
{
    public static bool treasure = false;
    public bool areYouSure = false;
    public GameObject confirmScreen;
    public GameObject gameOverScreen;
    public GameObject wrongChoiceScreen;
    public static Vector3 localOfTreasure;
    public string scene;
    public SceneTransition st;
    public AudioSource audioSource;
    public AudioClip burrySound;

    private void Start()
    {
        confirmScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        wrongChoiceScreen.SetActive(false);
        Debug.Log("x= " + TreasueManeger.localOfTreasure.x + "y= " + TreasueManeger.localOfTreasure.y + "z= " + TreasueManeger.localOfTreasure.z);
    }
    public void Yes()
    {
        treasure = true;
        areYouSure = true;
        confirmScreen.SetActive(false);
        Time.timeScale = 1;
        audioSource.PlayOneShot(burrySound);
        StartCoroutine(st.ChangeScene(scene));
        
    }
    public void No()
    {
        Debug.Log("Não");
        Time.timeScale = 1;
        areYouSure = false;
        treasure = false;
        confirmScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        wrongChoiceScreen.SetActive(false);
    }
}
