using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject candyA, candyB, candyC;
    public GameObject coin1,coin2,coin5;
    public Transform spawn, spawnCoinObj;

    void Start()
    {
        // if(stop < 2)
        //    InvokeRepeating("SpawnCandy", 1, 3);
    }

    void Update()
    {
        
    }

    public void spawnCandy(int candy_type)
    {
        GameObject candy = candyA;
        if(candy_type == 2)
            candy = candyB;
        else
            candy  = candyC;
        Instantiate(candy, spawn.position, Quaternion.identity);

    }
    public void spawnCoin(int coin_type){
        GameObject coin = coin1;
        if(coin_type == 2)
            coin = coin2;
        else
            coin  = coin5;
        Instantiate(coin, spawnCoinObj.position, Quaternion.identity);
    }
}
