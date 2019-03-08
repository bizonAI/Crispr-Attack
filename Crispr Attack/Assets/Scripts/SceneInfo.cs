using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SceneInfo : MonoBehaviour
{
    public int possibleInteractions;
    public TextMeshProUGUI numberText;

    private void Start()
    {
        numberText.text = possibleInteractions.ToString();
    }

    public void UpdateInteractions()
    {
        numberText.text = possibleInteractions.ToString();
    }
}
