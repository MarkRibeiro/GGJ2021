using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLapse : MonoBehaviour
{
    public CanvasGroup fadeInCanvas; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(stopTime());
    }

    private IEnumerator stopTime()
    {
        yield return new WaitUntil(() => fadeInCanvas.alpha <= 0);
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
