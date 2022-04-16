using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawnerBehaviour : MonoBehaviour
{

    public float delay = 0f;
    public float spawnAreaMinX = 0f;
    public float spawnAreaMaxX = 0f;
    public float spawnAreaMinY = 0f;
    public float spawnAreaMaxY = 0f;
    public float spawnAreaMinZ = 0f;
    public float spawnAreaMaxZ = 0f;

    public float minSecondsWait = 1.1f;
    public float maxSecondsWait = 5.1f;

    public float secondsToInreaseDifficulty = 10f;
    public float difficultyFactorSeconds = 0.5f;
    public float wave = 1f;

    public bool spawnMissiles = true;

    public GameObject misslePrefab;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnMissile",delay);
        Invoke("IncreaseDifficulty", secondsToInreaseDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SpawnMissile()
    {

        Vector3 spawnPosition = new Vector3(Random.Range(spawnAreaMinX, spawnAreaMaxX), Random.Range(spawnAreaMinY, spawnAreaMaxY), Random.Range(spawnAreaMinZ, spawnAreaMaxZ));
        Instantiate<GameObject>(misslePrefab, spawnPosition, new Quaternion(-180,0,0,0));

        //Debug.Log("Missile Spawned");
        if (spawnMissiles) {
            Invoke("SpawnMissile", Random.Range(minSecondsWait-(difficultyFactorSeconds* wave), maxSecondsWait - (difficultyFactorSeconds * wave)));
        }

        
    }
    private void IncreaseDifficulty()
    {
        wave++;
        Invoke("IncreaseDifficulty", secondsToInreaseDifficulty);
        Debug.Log("Increased Difficulty");
    }

}

