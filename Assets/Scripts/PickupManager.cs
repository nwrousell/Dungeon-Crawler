using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickupManager : MonoBehaviour
{

    public int orangeJuices = 0;
    public int apples = 0;

    public TextMeshProUGUI orangeJuiceText;
    public TextMeshProUGUI appleText;

    private void Update()
    {
        // Update UI to show how many buffs the player has
        orangeJuiceText.text = orangeJuices.ToString();
        appleText.text = apples.ToString();
    }

    public void AddOrangeJuice(int amount)
    {
        orangeJuices += amount;
    }

    public void AddApple(int amount)
    {
        apples += amount;
    }

}
