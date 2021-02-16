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
        Debug.Log("treasure? " + TreasueManeger.treasure);
        if(Time.timeScale == 1){    
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin,ray.direction*100, Color.magenta, 0.02f);
            if(TreasueManeger.treasure == true){
                Debug.DrawRay(TreasueManeger.localOfTreasure,Vector3.up,Color.blue);
                Debug.Log("Tesouro: "+TreasueManeger.localOfTreasure);
            }
            if( Input.GetMouseButtonDown(0)){
                RaycastHit hit;
                
                if(Physics.Raycast(ray,out hit, 1000.0f) && hit.transform.name != "Oceano"){
                    matRenderer.sharedMaterial.SetVector("Vector3_C357230",hit.point);

                    if(TreasueManeger.treasure == false){
                        treasure.confirmScreen.SetActive(true);
                        Time.timeScale = 0;
                        TreasueManeger.localOfTreasure = hit.point;
                        TreasueManeger.treasure = true;
                        Debug.Log("x= " + TreasueManeger.localOfTreasure.x + "y= " + TreasueManeger.localOfTreasure.y + "z= " + TreasueManeger.localOfTreasure.z);
                    }

                    if(TreasueManeger.treasure == true){
                        Debug.Log("distance: "+Vector3.Distance(TreasueManeger.localOfTreasure, hit.point));
                        if(Vector3.Distance(TreasueManeger.localOfTreasure, hit.point) < 5.5f)
                        {
                            gameOverScreen.SetActive(true);
                            Debug.Log("Achou o tesouro.");
                            Time.timeScale = 0;
                        }
                        else
                        {
                            wrongChoiceScreen.SetActive(true);
                            Time.timeScale = 0;
                            Debug.Log("x= " + hit.point.x + "y= " + hit.point.y + "z= " + hit.point.z);
                        }
                    }
                }
            }
        }
    }
}
