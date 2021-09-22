

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class VendingMachine : MonoBehaviour
{
    // Start is called before the first frame update
    public double payment;
    public GameObject spawnObject;
    public Spawn spawn; 
    private Candy candy;

    public Text screen;
    void Start()
    {
        spawn = spawnObject.GetComponent<Spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AcceptCandy(int candyType){
        candy = new Candy(candyType);
        Debug.Log("Payment: " + payment + " Candy value " + candy.DecideWhichCandy());
        int change = (int)(payment - candy.DecideWhichCandy());
        if(change >=  0 ){
            ChangeTextVendingMachine($"{CalculateChange(change)}");
            payment = 0;
            DropItem(candyType);
        }
        else{
            ChangeTextVendingMachine("Not enough money");
        }
    }

    public String CalculateChange(int change){
        int[] coins = { 5, 2, 1 };
        int[] amounts = new int[coins.Length];
        string msg = "";

        for (int i = 0; i < coins.Length; i++) 
        {
            amounts[i] = change / coins[i];
            change = change % coins[i];
        }
        
        for(int i = 0; i < amounts.Length; i++)
        {
            msg += $" Moedas de {coins[i]}: {amounts[i]}";
        }

        return msg;
    }

    public void ChangeTextVendingMachine(string msg){
        screen.text = msg;
        Debug.Log(msg);
    }

    public void DropItem(int candyType){
        spawn.spawnCandy(candyType);
        ChangeTextVendingMachine("R$ " + payment);
    }

    public void DropCoin(int coinType){
        spawn.spawnCoin(coinType);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        double value =  collision.gameObject.GetComponent<DragItem>().value;
        payment += value;
        ChangeTextVendingMachine("R$ " + payment);
    }

}
