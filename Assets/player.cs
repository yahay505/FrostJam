using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public static player currentplayer;
    public SpriteRenderer colorrenderer;
    public GameObject particle;
    public Color[] colors;
    public Transform arrow,anchor,wheel;
    private Vector3 mousePos;
    public bool isSafe;
    public bool[] ground = new bool[6];
    public int currentcolor;
    public float speed;
    public Animator animator;
    private Rigidbody2D rb;
    public AudioSource DieSound,stepSound,alteredTimeSound;
    
    void Start()
    {
        Time.timeScale = 1;
        currentplayer = this;
        rb = GetComponent<Rigidbody2D>();
        colors = Constants.constants.Colors;
    }

    // Update is called once per frame
    void Update()
    {
        ProccessCollorWheel();
        ProccessGroundColors();
        ProccessMovement();
        ProccessSound();
    }
    private float timeSinceStep;
    private void ProccessSound()
    {
        
        if (rb.velocity.magnitude>0.1f)
        {
            timeSinceStep += Time.deltaTime;
            if (timeSinceStep>=.25f)
            {
                stepSound.Play();
                timeSinceStep = 0f;
            }
        }
        else
        {
            timeSinceStep = 0;

        }
        if (Time.timeScale==1)
        {
            alteredTimeSound.enabled = false;
        }
        else
        {
            alteredTimeSound.enabled = true;

        }
    }

    private void ProccessMovement()
    {
        rb.velocity = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity += Vector2.right;
        }
        rb.velocity.Normalize();
        rb.velocity *= speed;
        animator.SetFloat("magnitute", rb.velocity.magnitude);
        if (rb.velocity.magnitude>0.1f)
        {
            animator.SetFloat("x", rb.velocity.x);
            animator.SetFloat("y", rb.velocity.y);
            animator.SetFloat("oldX", rb.velocity.x);
            animator.SetFloat("oldY", rb.velocity.y);
        }
    }

    private void ProccessGroundColors()
    {
        if (isSafe)
        {
            return;
        }
        if (!ground[currentcolor])
        {
            Die();
        }
    }

    public void Die()
    {
        Time.timeScale = 1;
        this.enabled = false;
        Debug.Log("die");
        particle.SetActive(true);
        this.Invoke("resetlvl", 1);
        PlayDieSound();
        transform.DetachChildren();
        colorrenderer.gameObject.SetActive(false) ;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void PlayDieSound()
    {
        DieSound.Play();
    }

    public void resetlvl()
    {
        Debug.LogError("loaded");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            //Debug.Log(angle);
            SetColorByAngle(angle);
        }
        if (Input.GetMouseButton(1))
        {
            Vector2 v2 = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - new Vector2(mousePos.x, mousePos.y);


            float angle = Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg-90f;
            //Debug.Log(angle);
            if (v2.magnitude>150)
            {
                SetColorByAngle(angle);
            }

            arrow.gameObject.SetActive(true);
            anchor.gameObject.SetActive(true);
            wheel.gameObject.SetActive(true);
            anchor.position = Camera.main.ScreenToWorldPoint(mousePos)+new Vector3(0,0,11);
            arrow.rotation=Quaternion.Euler(0,0, angle);
        }
        else
        {
            anchor.gameObject.SetActive(false);
            arrow.gameObject.SetActive(false);
            wheel.gameObject.SetActive(false);
        }
    }

    private void SetColorByAngle(float angle)
    {
        if (angle+90>0)
        {
            if (angle+90>120)
            {
                colorrenderer.color = colors[0];
                currentcolor = 0;
            }
            else if (angle+90>60)
            {
                colorrenderer.color = colors[1];
                currentcolor = 1;

            }
            else
            {
                colorrenderer.color = colors[2];
                currentcolor = 2;
            }
        }
        else
        {
            if (angle+90<-120)
            {
                colorrenderer.color = colors[3];
                currentcolor = 3;
            }
            else if (angle+90 <-60)
            {
                colorrenderer.color = colors[4];
                currentcolor = 4;
            }
            else
            {
                colorrenderer.color = colors[5];
                currentcolor = 5;
            }
        }
    }
}
