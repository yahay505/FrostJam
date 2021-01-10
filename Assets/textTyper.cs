using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textTyper : MonoBehaviour
{
    public string TEXT;
    public int framePerBeat,LetterPerBeat;
    private int currentframe = 0, currentBeat = 0;
    private TMPro.TextMeshProUGUI textMesh;
    // Update is called once per frame
    private void Start()
    {
        textMesh = GetComponent<TMPro.TextMeshProUGUI>();
    }
    void Update()
    {
        try
        {

     
        currentframe++;
        if (currentframe==framePerBeat)
        {

                try
                {
                    GetComponent<AudioSource>().Play();
                }
                catch (System.Exception)
                {

                }
                currentframe = 0;
            currentBeat++;


            textMesh.SetText( TEXT.Remove(currentBeat * LetterPerBeat).Replace(@"ü", @"<br>"));
            if (TEXT.Remove(currentBeat * LetterPerBeat)==TEXT)
            {
                this.enabled = false;
            }
        }
        }
        catch (System.Exception)
        {

            this.enabled = false;
        }
    }
}
