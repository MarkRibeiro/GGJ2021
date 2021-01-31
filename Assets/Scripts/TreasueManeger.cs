using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasueManeger : MonoBehaviour
{
    public static bool treasure = false;
    public bool areYouSure = false;
    public GameObject confirmScreen;
    public static Vector3 localOfTreasure;

    public string scene;

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
        SceneManager.LoadScene(scene);
    }
    public void No()
    {
        Debug.Log("Não");
        areYouSure = false;
        confirmScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
