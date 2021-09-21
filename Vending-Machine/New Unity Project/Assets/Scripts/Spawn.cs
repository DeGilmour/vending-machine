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
        
    }

    void Update()
    {
        
    }

    public void spawnCandy(int candyType)
    {
        GameObject candy = candyA;
        if(candyType == 2)
            candy = candyB;
        else if(candyType == 3)
            candy  = candyC;
        Instantiate(candy, spawn.position, Quaternion.identity);

    }
    public void spawnCoin(int coinType){
        GameObject coin = coin1;
        if(coinType == 2)
            coin = coin2;
        else if(coinType == 5)
            coin  = coin5;
        Instantiate(coin, spawnCoinObj.position, Quaternion.identity).AddComponent<Coin>();

    }
}
