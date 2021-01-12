using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneQuit : MonoBehaviour
{

        public void quitGame() {
        Application.Quit();
        Debug.Log("QUIT");
    }
}

