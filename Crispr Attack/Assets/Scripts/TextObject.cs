using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextObject : MonoBehaviour
{
    public GameObject dialogManager;
    public Animator textPanel;

    public static bool isInDialog;

    GameObject sceneInfo;

    private void Start()
    {
        sceneInfo = GameObject.Find("SceneInfo");
    }

    private void OnMouseDown()
    {
        if (!isInDialog && !dialogManager.GetComponent<Dialog>().finished)
        {
            dialogManager.SetActive(true);
            textPanel.SetTrigger("fadeIn");
            isInDialog = true;

            sceneInfo.GetComponent<SceneInfo>().possibleInteractions--;
            sceneInfo.GetComponent<SceneInfo>().UpdateInteractions();
        }
        
    }
}
