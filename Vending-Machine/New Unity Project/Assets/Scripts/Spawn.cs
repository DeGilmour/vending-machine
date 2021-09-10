using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject candy;
    int numberOfGameObjects = 0;
    public Transform spawnCandyA, spawnCandyB, spawnCandyC;
    void Start()
    {
    }

    void Update()
    {
    }

    void SpawnCandy(int candy_type)
    {
        numberOfGameObjects++;
        Transform spawn = spawnCandyA;
        if(candy_type != 0)
            if(candy_type == 2)
                spawn = spawnCandyB;
            else if(candy_type == 3)
                spawn = spawnCandyC;
        Instantiate(candy, spawn.position, Quaternion.identity);

    }
}
