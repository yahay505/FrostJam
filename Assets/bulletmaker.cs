using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletmaker : MonoBehaviour
{
    public float shootTime;
    public GameObject prefab;
    private float tick=0;
    private void Update()
    {
        var dir = player.currentplayer.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg-90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        tick+=Time.deltaTime;
        if (shootTime<=tick)
        {
            Instantiate(prefab, transform.position, transform.rotation);
            tick = 0;
        }
    }
}
