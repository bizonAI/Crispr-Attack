using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkObject : MonoBehaviour
{
    public GameObject camera;
    public Vector3 moveToPos;
    public float camMoveSpeed = 5;

    bool wasHit;

    private void Update()
    {
        if (wasHit)
        {
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, moveToPos, camMoveSpeed * Time.deltaTime);
        }
    }

    private void OnMouseDown()
    {
        wasHit = true;
    }
}
