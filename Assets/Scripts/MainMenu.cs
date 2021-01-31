using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject configPanel;

    public string Level;
    void Start()
    {
        configPanel.SetActive(false);
    }
    public void Play(){
        SceneManager.LoadScene(Level);
    }
    public void QuitGame(){
        Debug.Log("Saiu");
        Application.Quit();
    }
}
