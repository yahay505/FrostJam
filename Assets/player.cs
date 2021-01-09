using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public SpriteRenderer colorrenderer;
    public Color[] colors;
    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProccessCollorWheel();
    }

    private void ProccessCollorWheel()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Time.timeScale = .2f;
            mousePos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(1))
        {
            Time.timeScale = 1;
            Vector2 v2 =  new Vector2( Input.mousePosition.x, Input.mousePosition.y) - new Vector2(mousePos.x,mousePos.y);

 
            float angle = Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
            Debug.Log(angle);
        }
    }
}
