using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingMachine : MonoBehaviour
{
    // Start is called before the first frame update
    public int payment, maxNumberOfCandy;
    public GameObject spawnObject;
    public Spawn spawn;
    private Candy candy;
    public AudioPlayer audioPlayer;
    public GameObject audioPlayerObj;
    public Counter counter;
    public Text screenValue;
    public Text screenChange;


    void Start()
    {
        spawn = spawnObject.GetComponent<Spawn>();
        audioPlayer = audioPlayerObj.GetComponent<AudioPlayer>();
    }

    void Update()
    {
    }

    public void AcceptCandy(int candyType)
    {
        candy = new Candy(candyType);
        int change = (int) (payment - candy.DecideWhichCandy());
        
        ChangeTextVendingMachine($"{change}");
        if (change >= 0)
        {
            StartCoroutine(CalculateChange(change));
            screenChange.text = "TROCO: ";
            payment = 0;
            DropItem(candyType);
        }
        else
        {
            screenChange.text = "ERRO";
            audioPlayer.ChooseAudioToPlay(6);
            StartCoroutine(Waiter(5));
        }

    }

    private IEnumerator CalculateChange(int change)
    {
        int[] coins = {5, 2, 1};
        int[] amounts = new int[coins.Length];
        for (int i = 0; i < coins.Length; i++)
        {
            amounts[i] = change / coins[i];
            change = change % coins[i];
        }
        for (int i = 0; i < amounts.Length; i++)
        {
            for (var c = 1; c <= amounts[i]; c++)
            {
                yield return new WaitForSeconds(1);
                DropCoin(coins[i]);
            }
        }
        yield return new WaitForSeconds(5);
        ChangeTextVendingMachine("");
        screenChange.text = "";
    }

    private IEnumerator Waiter(float sec)
    {
        yield return new WaitForSeconds(sec);
        screenChange.text = "";
        screenValue.text = "";
        StartCoroutine(CalculateChange(payment));
        payment = 0;
    }

    private void ChangeTextVendingMachine(string msg)
    {
        screenValue.text = msg;
    }
    
    private void DropItem(int candyType)
    {
        spawn.spawnCandy(candyType);
        switch (candyType)
        {
            case 1:
                counter.numberOfCandyA--;
                break;
            case 2:
                counter.numberOfCandyB--;
                break;
            case 3:
                counter.numberOfCandyC--;
                break;
        }
    }

    private void DropCoin(int coinType)
    {
        StartCoroutine(spawn.spawnCoin(coinType));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Money")) return;
        int value = collision.gameObject.GetComponent<Coin>().coinValue;
        if (payment >= 15)
        {
            payment = 15; 
        }
        else
        {
            payment += value;
            audioPlayer.ChooseAudioToPlay(5);
        }
        screenChange.text = "PAG.";
        ChangeTextVendingMachine($"{payment}");

    }
}