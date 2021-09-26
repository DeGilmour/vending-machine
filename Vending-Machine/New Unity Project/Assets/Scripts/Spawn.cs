using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject candyA, candyB, candyC;
    public GameObject coin1,coin2,coin5, audioPlayerObj;
    public Transform spawnA, spawnB, spawnC, spawnCoinObj;
    public AudioPlayer audioPlayer;

    void Start()
    {
        audioPlayer = audioPlayerObj.GetComponent<AudioPlayer>();
    }

    void Update()
    {
        
    }

    public void spawnCandy(int candyType)
    {
        Transform spawn = spawnA;
        GameObject candy = candyA;
        if (candyType == 2)
        {
            candy = candyB;
            spawn = spawnB;
        }
        else if (candyType == 3)
        {
            candy = candyC;
            spawn = spawnC;
        }
        Instantiate(candy, spawn.position, Quaternion.identity);

    }

    public IEnumerator spawnCoin(int coinType) 
    {
        yield return new WaitForSeconds(3);
        audioPlayer.ChooseAudioToPlay(1);
        GameObject coin = coin1;
        if(coinType == 2)
            coin = coin2;
        else if(coinType == 5)
            coin  = coin5;
        Instantiate(coin, spawnCoinObj.position, Quaternion.identity).AddComponent<Coin>();
        audioPlayer.ChooseAudioToPlay(1);
    }
}
