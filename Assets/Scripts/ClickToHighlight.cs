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
        if( Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit, 1000.0f)){
                GetComponent<Renderer>().sharedMaterial.SetVector("_Center",hit.point);
            }
        }
    }
}
