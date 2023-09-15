using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{

    private bool isCut;
    public float minV = 0.001f;
    Camera cam;
    CircleCollider2D circleCollider;
    Vector2 currentPos;
    
    void Start()
    {
        cam = Camera.main;  
        circleCollider = GetComponent<CircleCollider2D>();
    }

   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCut)
        {
            UpdateCut();
        }

    }
    void StartCutting()
    {
        isCut = true;
        currentPos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void StopCutting()
    {
        isCut  = false;
        circleCollider.enabled = false;
    }
    public void UpdateCut()
    {
        Vector2 Newpos = cam.ScreenToWorldPoint(Input.mousePosition)  ;
        transform.position = Newpos;
        float velocity  = (Newpos - currentPos).magnitude * Time.deltaTime;
        if (velocity > minV)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false; 
        }
        currentPos = Newpos;
    }
}
