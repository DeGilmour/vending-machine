

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VendingMachine : MonoBehaviour
{
    // Start is called before the first frame update
    private int credit;
    public double payment;
    public GameObject spawnObject;
    public Spawn spawn; 
    private Candy candy;

    public Text screenObj;
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
        Debug.Log(change);
        if (change >= 0)
        {
            int troco5, troco2, troco1, rest;
            if (change >= 5)
            {
                troco5 = change / 5;
                rest = change % 5;
                Debug.Log(rest);
                if (rest != 0)
                {
                    troco2 = rest / 2;
                    rest = rest % 2;
                    if (rest != 0)
                    {
                        troco1 = rest;
                        ChangeTextVendingMachine("Give candy and change back, change: " + change + " Moedas de 5c: " + troco5 + ", Moedas de 2c: " + troco2 + ", Moedas de 1c: " + troco1);
                        // for(int c=0; c < troco5; c++){
                        //     Debug.Log("Drop coin 5");
                        //     dropCoin(3);
                        // }
                    }
                }
            }
            
            payment = 0;
            dropItem(candyType);
        }
        else
        {
            ChangeTextVendingMachine("Not enough money");
        }
    }

    public void ChangeTextVendingMachine(string msg){
        Text screen = screenObj.GetComponent<Text>();
        screen.text = msg;
        Debug.Log(msg);
    }

    public void dropItem(int candyType){
        spawn.spawnCandy(candyType);
        ChangeTextVendingMachine("R$ " + payment);
    }

    public void dropCoin(int coin_type){
        spawn.spawnCoin(coin_type);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        double value =  collision.gameObject.GetComponent<DragItem>().value;
        payment += value;
        ChangeTextVendingMachine("R$ " + payment);
    }

}
