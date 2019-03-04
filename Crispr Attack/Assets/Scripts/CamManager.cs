using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public GameObject[] walkObjects;
    public GameObject myCam;

    public Vector3 startPos;

    public float camMoveSpeed = 5.0f;

    bool goBack;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            for (int i = 0; i < walkObjects.Length; i++)
            {
                walkObjects[i].GetComponent<WalkObject>().wasHit = false;
            }
            goBack = true;
        }

        if (goBack)
        {
            myCam.transform.position = Vector3.MoveTowards(myCam.transform.position, startPos, camMoveSpeed * Time.deltaTime);
        }

        if(myCam.transform.position.y == startPos.y)
        {
            goBack = false;
        }

        Debug.Log("cammanger goBack: " + goBack);
    }
}
