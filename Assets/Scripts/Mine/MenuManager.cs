using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{

    public Canvas menu;
    public Canvas about;
    public Canvas options;

    public TextMeshProUGUI musicToggleText;
    public TextMeshProUGUI soundToggleText;
    public TextMeshProUGUI graphicsToggleText;

    private bool musicToggle = true;
    private bool soundToggle = true;

    private bool greatGraphics = true;

    private GameObject gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController");
    }

    public void Play()
    {
        // Start Game
        gm.GetComponent<LoadManager>().Play();
    }

    public void About()
    {
        menu.enabled = false;
        about.enabled = true;
    }

    public void Back()
    {
        about.enabled = false;
        options.enabled = false;
        menu.enabled = true;
    }

    public void Options()
    {
        menu.enabled = false;
        options.enabled = true;
    }

    public void Quit()
    {
        
    }

    public void ToggleMusic()
    {
        if (musicToggle)
        {
            musicToggle = false;
            musicToggleText.text = "No";
        }
        else
        {
            musicToggle = true;
            musicToggleText.text = "Yes";
        }
        gm.GetComponent<AudioManager>().music = musicToggle;

    }
    public void ToggleSound()
    {
        if (soundToggle)
        {
            soundToggle = false;
            soundToggleText.text = "No";
        }
        else
        {
            soundToggle = true;
            soundToggleText.text = "Yes";
        }
        gm.GetComponent<AudioManager>().sound = soundToggle;
    }
    public void ToggleGraphics()
    {
        if (greatGraphics)
        {
            greatGraphics = false;
            graphicsToggleText.text = "Good";
        }
        else
        {
            greatGraphics = true;
            graphicsToggleText.text = "Great";
        }
        // Change Graphic Settings Somehow Here
    }
}
