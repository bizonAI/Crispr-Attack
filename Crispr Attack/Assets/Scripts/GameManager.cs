using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("DEBUG")]
    public int score = 0;

    [Header("Text Element")]
    public TextMeshProUGUI scoreText;

    [Header("Changing Values")]
    public int[] worstValue;
    public int[] worseValue;
    public int[] normalValue;
    public int[] betterValue;
    public int[] bestValue;

    [Header("Images")]
    public Image preview;
    [Space(10)]

    public Sprite worstPreview;
    public Sprite worsePreview;
    public Sprite normalPreview;
    public Sprite betterPreview;
    public Sprite bestPreview;

    public Animator cameraObject;

    private void Start()
    {
        scoreText.text = score.ToString() + "% aging resistance";
    }

    public void AddPoints(int points)
    {
        score += points;

        if(points <= 0)
        {
            cameraObject.SetTrigger("negativePoints");
        }

        scoreText.text = score.ToString() + "% aging resistance";
    }

    private void Update()
    {
        if (score >= worstValue[0] && score <= worstValue[1])
        {
            preview.sprite = worstPreview;
        }

        if (score >= worseValue[0] && score <= worseValue[1])
        {
            preview.sprite = worsePreview;
        }

        if (score >= normalValue[0] && score <= normalValue[1])
        {
            preview.sprite = normalPreview;
        }

        if (score >= betterValue[0] && score <= betterValue[1])
        {
            preview.sprite = betterPreview;
        }

        if (score >= bestValue[0] && score <= bestValue[1])
        {
            preview.sprite = bestPreview;
        }

    }
}
