using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public int groundtype;
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D collision)
    {

        collision.GetComponent<player>().ground[groundtype] = false;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<player>().ground[groundtype] = true;
    }
    void Update()
    {
        
    }
}
