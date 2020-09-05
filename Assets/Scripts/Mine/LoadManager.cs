using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadManager : MonoBehaviour
{

    public string gameScene;
    public TextMeshProUGUI gameOverText;

    public void Play()
    {
        GameObject.FindGameObjectWithTag("UI").GetComponent<Canvas>().enabled = true;
        SceneManager.LoadSceneAsync(gameScene, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Menu");    
    }

    public void Restart()
    {
        // Reset Health and called dead stuff
        gameObject.GetComponent<HealthManager>().health = gameObject.GetComponent<HealthManager>().fullHealth;
        gameObject.GetComponent<HealthManager>().calledDeadStuff = false;

        // Reload Scene
        SceneManager.UnloadSceneAsync(gameScene);
        SceneManager.LoadSceneAsync(gameScene, LoadSceneMode.Additive);

        GameObject.FindGameObjectWithTag("EffectsPanel").GetComponent<Animator>().SetBool("Dead", false);
        gameOverText.enabled = false;
    }

}
