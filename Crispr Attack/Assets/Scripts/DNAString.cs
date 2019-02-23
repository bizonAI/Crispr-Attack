using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNAString : MonoBehaviour {

    public DNAPart[] dnaParts;

    public Sprite goodPart;
    public Sprite badPart;

    public float moveSpeed = 4;

    GameManager gameManager;

    public int plusPoints = 5;
    public int littleNegativePoints = -5;
    public int negativePoints = -10;

	void Awake ()
    {
        for (int i = 0; i < dnaParts.Length; i++)
        {
            dnaParts[i].GetComponent<SpriteRenderer>().sprite = goodPart;
            dnaParts[i].isNormalDNA = true;
        }

        int rndPart = Random.Range(0, 4);
        dnaParts[rndPart].GetComponent<SpriteRenderer>().sprite = badPart;
        dnaParts[rndPart].isNormalDNA = false;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	void Update ()
    {
        transform.Translate(Vector2.up * Time.deltaTime * -moveSpeed);
	}

    void MakePoints()
    {
        for (int i = 0; i < dnaParts.Length; i++)
        {
            if (dnaParts[i].dead)
            {
                if (dnaParts[i].isBetter)
                {
                    gameManager.AddPoints(plusPoints);
                }

                if (!dnaParts[i].isBetter && !dnaParts[i].staysDead)
                {
                    gameManager.AddPoints(littleNegativePoints);
                }

                if (dnaParts[i].staysDead)
                {
                    gameManager.AddPoints(negativePoints);
                }
            }
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TheEnd"))
        {
            MakePoints();
        }
    }
}
