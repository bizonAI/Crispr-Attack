using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseGen : MonoBehaviour
{
    public GameObject light;
    public ChooseGenManager genManager;
    bool wasHit;

    private void Start()
    {
        light.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!wasHit && genManager.moneyAmount != 0)
        {
            light.SetActive(true);
            genManager.MinusMoney();
            wasHit = true;
        }
        else if (wasHit)
        {
            light.SetActive(false);
            genManager.PlusMoney();
            wasHit = false;
        }
        
    }
}
