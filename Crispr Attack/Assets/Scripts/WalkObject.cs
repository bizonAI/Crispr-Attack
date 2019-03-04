using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WalkObject : MonoBehaviour
{
    public GameObject camera;
    public Vector3 moveToPos;
    public float camMoveSpeed = 5;

    [HideInInspector]
    public bool wasHit;

    public GameObject interactionCavas;


    private void Update()
    {
        if (wasHit)
        {
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, moveToPos, camMoveSpeed * Time.deltaTime);
        }

        if(camera.transform.position.z == moveToPos.z)
        {
            interactionCavas.SetActive(true);
        }
        else
        {
            interactionCavas.SetActive(false);
        }


        Debug.Log("walkobject was hit: " + wasHit);
    }

    private void OnMouseDown()
    {
        wasHit = true;

        if(camera.transform.position.z == moveToPos.z)
        {
            SceneManager.LoadScene(1);
            Debug.Log("Load new scene");
        }
    }
}
