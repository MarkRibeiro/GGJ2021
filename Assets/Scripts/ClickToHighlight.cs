using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToHighlight : MonoBehaviour
{
    
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
    }

    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction*100, Color.magenta, 0.02f);
        if( Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            
            if(Physics.Raycast(ray,out hit, 1000.0f)){
                GetComponent<Renderer>().sharedMaterial.SetVector("Vector3_C357230",hit.point);
            }
        }
    }
}
