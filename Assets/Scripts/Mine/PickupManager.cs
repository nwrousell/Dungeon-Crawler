using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickupManager : MonoBehaviour
{

    public int orangeJuices = 0;
    public int apples = 0;
    public int coins = 0;

    public TextMeshProUGUI orangeJuiceText;
    public TextMeshProUGUI appleText;
    public TextMeshProUGUI coinText;

    private void Update()
    {
        // Update UI to show how many buffs the player has
        orangeJuiceText.text = orangeJuices.ToString();
        appleText.text = apples.ToString();
        coinText.text = coins.ToString();
    }

    public void AddOrangeJuice(int amount)
    {
        orangeJuices += amount;
    }

    public void AddApple(int amount)
    {
        apples += amount;
    }

    public void AddCoins(int amount)
    {
        coins += amount;
    }

}
