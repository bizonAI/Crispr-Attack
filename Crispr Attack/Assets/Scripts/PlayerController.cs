using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float downPos = -2;
    public float moveBack = 0.125f;

    public Animator animPlayer;
    public ParticleSystem movementParticle;
    ParticleSystem.EmissionModule movementEmmissionModule;

    [Header("Vertical movement")]
    public float highestPoint = 1;
    public float lowestPoint = -3;
    public float moveSpeedVertical = 0.125f;

    [Header("Horizontal movement")]
    public float leftBorder = 1;
    public float rightBorder = 5;
    public float moveSpeedHorizontal = 0.1f;

    [Header("Shooting")]
    public GameObject projectile;
    public Transform projectileSpawnPoint;
    public float shootingSpeed = 1;

    float shootCounter = 5;

    int rndNmb;
    public Sprite betterDNA;
    public Sprite worseDNA;

    public GameObject letterCanvas;

    public TextMeshProUGUI letter;

    DNAPart dnaPart;

    bool isInDestroyedDNA;

    private void Start()
    {
        letterCanvas.SetActive(false);
        //movementParticle = GetComponent<ParticleSystem>();
        movementEmmissionModule = movementParticle.emission;
    }


    void Update ()
    {
        float speed = moveSpeed * Time.deltaTime;

        float yInput = Input.GetAxis("Vertical") * speed;
        float xInput = Input.GetAxis("Horizontal") * speed;

        transform.Translate(xInput, yInput, 0);

        if(yInput == 0)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, downPos), Time.deltaTime * moveBack);

            animPlayer.SetBool("forwardSpeed", false);
            animPlayer.SetBool("slowDown", false);
        }

        //Move Particle 
        if(yInput > 0)
        {
            movementEmmissionModule.rateOverTime = 100;
            animPlayer.SetBool("forwardSpeed", true);
        } else if(yInput <= 0)
        {
            movementEmmissionModule.rateOverTime = 30;
        }

        if (yInput < 0)
        {
            animPlayer.SetBool("slowDown", true);
        }

        //SHOOT
        if (Input.GetKey(KeyCode.Space))
        {
            if(shootingSpeed <= shootCounter)
            {
                Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);

                shootCounter = 0;
            }
        }

        if(shootCounter < shootingSpeed)
        {
            shootCounter += Time.deltaTime;
        }

        //Debug.Log("is in DNA: " + isInDestroyedDNA);

        if (isInDestroyedDNA)
        {
            RebuildDNA();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DestroyedDNA"))
        {

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("DestroyedDNA"))
        {
            if (!isInDestroyedDNA)
            {
                dnaPart = other.GetComponent<DNAPart>();
                DestoryedDNAEntered();
            }

            //RebuildDNA();
        }
    }

    void DestoryedDNAEntered()
    {
        rndNmb = Random.Range(0, 4);
        letterCanvas.SetActive(true);
        isInDestroyedDNA = true;

        if (rndNmb == 0)
        {
            letter.text = "H";
        }
        else if (rndNmb == 1)
        {
            letter.text = "J";
        }
        else if (rndNmb == 2)
        {
            letter.text = "K";
        }
        else if (rndNmb == 3)
        {
            letter.text = "U";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DestroyedDNA"))
        {
            letterCanvas.SetActive(false);
            isInDestroyedDNA = false;
        }
    }

    void RebuildDNA()
    {
        //H
        if (Input.GetKeyDown(KeyCode.H) && rndNmb == 0)
        {
            MakeHumanBetter();
        }
        if (Input.GetKeyDown(KeyCode.H) && rndNmb != 0)
        {
            MakeHumanBad();
        }

        //I
        if (Input.GetKeyDown(KeyCode.J) && rndNmb == 1)
        {
            MakeHumanBetter();
        }
        if (Input.GetKeyDown(KeyCode.J) && rndNmb != 1)
        {
            MakeHumanBad();
        }

        //J
        if (Input.GetKeyDown(KeyCode.K) && rndNmb == 2)
        {
            MakeHumanBetter();
        }
        if (Input.GetKeyDown(KeyCode.K) && rndNmb != 2)
        {
            MakeHumanBad();
        }

        //U
        if (Input.GetKeyDown(KeyCode.U) && rndNmb == 3)
        {
            MakeHumanBetter();
        }
        if (Input.GetKeyDown(KeyCode.U) && rndNmb != 3)
        {
            MakeHumanBad();
        }
    }

    void MakeHumanBetter()
    {
        dnaPart.MakeItBetter();
        letterCanvas.SetActive(false);
        isInDestroyedDNA = false;
    }

    void MakeHumanBad()
    {
        dnaPart.MakeItWorse();
        letterCanvas.SetActive(false);
        isInDestroyedDNA = false;
    }

    
}
