using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public Vector2 areasize,offset;
    public Vector3 target;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (target==null||target==transform.localPosition)
        {
            target = new Vector2(Random.Range(areasize.x, areasize.x  * -1), Random.Range(areasize.y , areasize.y * -1 ));
        }
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed*Time.deltaTime);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        other.gameObject.GetComponent<player>().isSafe = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<player>().isSafe = false;

    }

}
