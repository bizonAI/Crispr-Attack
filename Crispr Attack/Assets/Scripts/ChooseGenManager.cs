using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseGenManager : MonoBehaviour
{
    public TextMeshProUGUI money;
    public int chooseAmount = 3;

    [HideInInspector]
    public int moneyAmount = 6000;
    int moneyPlusMinusAmount = 2000;

    public void MinusMoney()
    {
        moneyAmount -= moneyPlusMinusAmount;
        money.text = moneyAmount.ToString() + "$";
    }

    public void PlusMoney()
    {
        moneyAmount += moneyPlusMinusAmount;
        money.text = moneyAmount.ToString() + "$";
    }
}
