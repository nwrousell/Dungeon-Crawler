using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{

    public string gameScene;

    public void Play()
    {
        GameObject.FindGameObjectWithTag("UI").GetComponent<Canvas>().enabled = true;
        SceneManager.LoadSceneAsync(gameScene, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Menu");    
    }

}
