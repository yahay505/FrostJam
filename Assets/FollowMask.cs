using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMask : MonoBehaviour
{
    public SpriteRenderer maskrenderer;
    public SpriteMask mask;
    void Update()
    {
        mask.sprite = maskrenderer.sprite;
    }
}
