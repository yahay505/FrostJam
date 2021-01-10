using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    public int NextScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GetComponent<AudioSource>().Play();

        SceneManager.LoadScene(NextScene, LoadSceneMode.Single);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GetComponent<AudioSource>().Play();

        SceneManager.LoadScene(NextScene, LoadSceneMode.Single);

    }
    
public void loadScene()
    {
        //GetComponent<AudioSource>().Play();

        SceneManager.LoadScene(NextScene, LoadSceneMode.Single);
    }
}
