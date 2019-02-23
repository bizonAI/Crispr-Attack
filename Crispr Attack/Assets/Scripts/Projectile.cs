using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject deathParticle;

    public float projectileSpeed = 5;
    public float horizontalDestroyPos = 6.2f;

    public float xValue = 1;

    float rndXValue;

    private void Start()
    {
        rndXValue = Random.Range(-xValue, xValue);
    }

    void Update ()
    {
        transform.Translate(Vector2.up * Time.deltaTime * projectileSpeed);
        transform.Translate(Vector2.right * Time.deltaTime * rndXValue);

        if(transform.position.y >= horizontalDestroyPos)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("DNAPart"))
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
