using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextObject : MonoBehaviour
{
    public GameObject dialogManager;
    public Animator textPanel;

    public static bool isInDialog;

    private void OnMouseDown()
    {
        if (!isInDialog && !dialogManager.GetComponent<Dialog>().finished)
        {
            dialogManager.SetActive(true);
            textPanel.SetTrigger("fadeIn");
            isInDialog = true;
        }
        
    }
}
