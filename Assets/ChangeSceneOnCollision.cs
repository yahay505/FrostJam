using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    public int NextScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(NextScene, LoadSceneMode.Single);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(NextScene, LoadSceneMode.Single);

    }
    
public void loadScene()
    {
        SceneManager.LoadScene(NextScene, LoadSceneMode.Single);

    }
}
