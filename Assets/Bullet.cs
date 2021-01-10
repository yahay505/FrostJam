using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position+transform.up, speed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            collision.GetComponent<player>().Die();
            Destroy(this.gameObject);
        }
        catch (System.Exception)
        {
           
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            collision.collider.GetComponent<player>().Die();
            Destroy(this.gameObject);
        }
        catch (System.Exception)
        {

 
        }
    }
}
