﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("main menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("teste");
    }
}