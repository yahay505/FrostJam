using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Constants :MonoBehaviour
{
    public Color[] Colors;
    public static Constants constants;
    private void Awake()
    {
        constants = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
