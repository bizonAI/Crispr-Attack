using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {

    public TextMeshProUGUI textDisplay;
    [TextArea]
    public string[] sentences;
    private int index;
    public float typingSpeed = 0.02f;

    [HideInInspector]
    public bool finished;

    public Animator textPanel;
    public GameObject continueButton;

    //private bool typeIt = true;

    private bool resetText = true;

    private void Start()
    {
        //textDisplayAnim = GameObject.FindGameObjectWithTag("Dialog").GetComponent<Animator>();
        //ontinueButton = GameObject.FindGameObjectWithTag("DialogButton");

        StartCoroutine(Type());
    }

    private void Update()
    {
        if(textDisplay.text == sentences[index] && Input.GetKeyDown(KeyCode.Return))
        {
            NextSentenced();
        }

        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void ResetIndex()
    {
        //index = 0;
        //typeIt = false;
        if (resetText)
        {
            textDisplay.text = "";
            resetText = false;
        }
        
        continueButton.SetActive(false);
        //Destroy(gameObject);
    }

    public void NextSentenced()
    {
        //textDisplayAnim.SetTrigger("change");
        continueButton.SetActive(false);

        if(index < sentences.Length - 1/* && typeIt */)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textPanel.SetTrigger("fadeOut");
            finished = true;
            textDisplay.text = "";
            TextObject.isInDialog = false;
        }
    }
}
