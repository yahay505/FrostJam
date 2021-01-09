using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public SpriteRenderer colorrenderer;
    public Color[] colors;
    public Transform arrow;
    private Vector3 mousePos;
    public bool isSafe, Ground1, Ground2, Ground3, Ground4, Ground5, Ground6;

    
    void Start()
    {
        colors = Constants.constants.Colors;
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
            Vector2 v2 = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - new Vector2(mousePos.x, mousePos.y);

            float angle = Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg - 90f;
            Debug.Log(angle);
            SetColorByAngle(angle);
        }
        if (Input.GetMouseButton(1))
        {
            Vector2 v2 = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - new Vector2(mousePos.x, mousePos.y);


            float angle = Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg-90f;
            Debug.Log(angle);
            SetColorByAngle(angle);
            arrow.gameObject.SetActive(true);
            arrow.rotation=Quaternion.Euler(0,0, angle);
        }
        else
        {
            arrow.gameObject.SetActive(false);
        }
    }

    private void SetColorByAngle(float angle)
    {
        if (angle+90>0)
        {
            if (angle+90>120)
            {
                colorrenderer.color = colors[0];
            }
            else if (angle+90>60)
            {
                colorrenderer.color = colors[1];
            }
            else
            {
                colorrenderer.color = colors[2];
            }
        }
        else
        {
            if (angle+90<-120)
            {
                colorrenderer.color = colors[3];
            }
            else if (angle+90 <-60)
            {
                colorrenderer.color = colors[4];
            }
            else
            {
                colorrenderer.color = colors[5];
            }
        }
    }
}
