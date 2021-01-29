using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject canvas;
    public GameObject pausePanel;
    public GameObject configPanel;
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            pause();
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void pause()
    {
        if (isPaused == false)
        {
            Time.timeScale = 0;
            canvas.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(true);
            configPanel.SetActive(false);
            Time.timeScale = 1;
            canvas.SetActive(false);
        }
        isPaused = !isPaused;
        Debug.Log(Time.timeScale);
    }
}
