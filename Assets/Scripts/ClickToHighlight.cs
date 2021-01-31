using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToHighlight : MonoBehaviour
{

    public TreasueManeger treasure;
    public GameObject gameOverScreen;
    public GameObject wrongChoiceScreen;
    private Renderer matRenderer;
    void Start()
    {
        matRenderer = GetComponent<Renderer>();
        matRenderer.sharedMaterial.SetVector("Vector3_C357230", new Vector3(1000f, 1000f, 1000f));

    }

    
    void Update()
    {
        if(Time.timeScale == 1){    
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin,ray.direction*100, Color.magenta, 0.02f);
            if( Input.GetMouseButtonDown(0)){
                RaycastHit hit;
                
                if(Physics.Raycast(ray,out hit, 1000.0f)){
                    matRenderer.sharedMaterial.SetVector("Vector3_C357230",hit.point);
                }

                if(TreasueManeger.treasure == false){
                    treasure.confirmScreen.SetActive(true);
                    Time.timeScale = 0;
                    if (treasure.areYouSure == true){
                        TreasueManeger.localOfTreasure = hit.transform.position;
                        TreasueManeger.treasure = true;
                    }
                }
                if(TreasueManeger.treasure == true){
                    if(Vector3.Distance(TreasueManeger.localOfTreasure, hit.transform.position) <= 5)
                    {
                        gameOverScreen.SetActive(true);
                        Debug.Log("Achou o tesouro.");
                        Time.timeScale = 0;
                    }
                    else
                    {
                        wrongChoiceScreen.SetActive(true);
                        Debug.Log("Errou o tesouro.");
                        Time.timeScale = 0;
                    }
                }
                
            }
        }
    }
}
