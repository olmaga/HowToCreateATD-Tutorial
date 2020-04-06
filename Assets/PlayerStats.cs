using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    public static int Money;
    public int startMoney = 400;
    public Text moneyDisplay;

    void Start () {
        Money = startMoney;
    }

    void Update () {
        moneyDisplay.text = "Money: " + PlayerStats.Money + "$";
    }
}