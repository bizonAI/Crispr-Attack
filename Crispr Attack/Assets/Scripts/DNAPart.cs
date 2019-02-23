using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNAPart : MonoBehaviour
{
    public int health = 5;
    int setHealth;
    public Sprite destroyedPart;

    SpriteRenderer normalSprite;

    public bool isDestroyed = false;

    public Sprite betterDNA;
    public Sprite normalDNA;
    public Sprite worseDNA;

    public bool dead = false;

    public bool staysDead = false;
    public bool isBetter;

    public GameObject deathParticle;
    public GameObject betterParticle;
    public GameObject worseParticle;

    public bool isNormalDNA;

    private void Start()
    {
        normalSprite = GetComponent<SpriteRenderer>();
        setHealth = health;
    }

    public void MakeItBetter()
    {
        if (isNormalDNA)
        {
            normalSprite.sprite = normalDNA;
            health = setHealth;
            dead = false;
            staysDead = false;
            isDestroyed = false;
            gameObject.tag = "DNAPart";
        }
        else
        {
            normalSprite.sprite = betterDNA;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            staysDead = false;
            Instantiate(betterParticle, transform.position, betterParticle.transform.rotation);
            isBetter = true;
        }
    }

    public void MakeItWorse()
    {
        normalSprite.sprite = worseDNA;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        staysDead = false;
        Instantiate(worseParticle, transform.position, worseParticle.transform.rotation);
        isBetter = false;
    }

    private void Update()
    {
        if(health == 0 && !dead)
        {
            //Debug.Log("is destroyed");
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            normalSprite.sprite = destroyedPart;
            isDestroyed = true;
            gameObject.tag = "DestroyedDNA";
            staysDead = true;
            dead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            health--;
        }

        if (other.CompareTag("Player") && isDestroyed)
        {
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isDestroyed)
        {
        }
    }


}
