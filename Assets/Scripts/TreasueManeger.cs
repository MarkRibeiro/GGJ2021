using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreasueManeger : MonoBehaviour
{
    public static bool treasure = false;
    public bool areYouSure = false;
    public GameObject confirmScreen;
    public static Vector3 localOfTreasure;
    public string scene;
    public SceneTransition st;

    private void Start()
    {
        confirmScreen.SetActive(false);
    }
    public void Yes()
    {
        Debug.Log("Sim");
        areYouSure = true;
        confirmScreen.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(st.ChangeScene(scene));
        
    }
    public void No()
    {
        Debug.Log("Não");
        areYouSure = false;
        confirmScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
