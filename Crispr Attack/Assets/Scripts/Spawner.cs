using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject dnaString;
    public float spawnSpeed = 5;

    float counter;
    float rndSpawnSpeed;

    private void Start()
    {
        counter = spawnSpeed;

        rndSpawnSpeed = Random.Range(spawnSpeed * 0.5f, spawnSpeed * 1.5f);
    }

    void Update ()
    {
		if(rndSpawnSpeed <= counter)
        {
            rndSpawnSpeed = Random.Range(spawnSpeed * 0.5f, spawnSpeed * 1.5f);
            Instantiate(dnaString);
            counter = 0;
        }

        counter += Time.deltaTime;


	}
}
