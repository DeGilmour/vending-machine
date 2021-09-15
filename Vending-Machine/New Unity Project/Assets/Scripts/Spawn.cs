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

    public void spawnCandy(int candy_type)
    {
        GameObject candy = candyA;
        if(candy_type == 2)
            candy = candyB;
        else if(candy_type == 3)
            candy  = candyC;
        Instantiate(candy, spawn.position, Quaternion.identity);

    }
    public void spawnCoin(int coin_type){
        GameObject coin = coin1;
        if(coin_type == 2)
            coin = coin2;
        else if(coin_type == 3)
            coin  = coin5;
        Instantiate(coin, spawnCoinObj.position, Quaternion.identity);
    }
}
