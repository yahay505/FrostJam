using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    public float[] time;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int currentindex=0;
    private float timesincestart;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (time[time.Length-1]<timesincestart)
        {
            this.enabled = false;
        }
        timesincestart+=Time.deltaTime;
        spriteRenderer.sprite = sprites[currentindex];
        if (timesincestart>time[currentindex+1])
        {
            currentindex++;
     }
    }
}
