

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VendingMachine : MonoBehaviour
{
    // Start is called before the first frame update
    private int credit;
    private int[] candiesInMachine = new int[15];
    public double payment;
    private Dictionary<int, int> candy_value = new Dictionary<int, int>();
    public GameObject spawnObject;
    public Spawn spawn; 
    public Candy candy;

    public Text screen_obj;
    void Start()
    {
        spawn = spawnObject.GetComponent<Spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void acceptCandy(int candy_type){
        candy = new Candy(candy_type=candy_type);
        Debug.Log("Payment: " + payment + " Candy value " + candy.decideWhichCandy());
        int change = (int)(payment - candy.decideWhichCandy());
        if (change >= 0)
        {
            int troco5, troco2, troco1, rest;
            if (change >= 5)
            {
                troco5 = change / 5;
                rest = change % 5;
                if (rest != 0)
                {
                    troco2 = rest / 2;
                    rest = rest % 2;
                    if (rest != 0)
                    {
                        troco1 = rest;
                        Debug.Log("Give candy and change back, change: " + change + " Moedas de 5c: " + troco5 + ", Moedas de 2c: " + troco2 + ", Moedas de 1c: " + troco1);
                    }
                }
            }
            
            payment = 0;
            dropItem(candy_type);
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void changeTextVendingMachine(string msg){
        Text screen = screen_obj.GetComponent<Text>();
        screen.text = msg;
    }

    public void dropItem(int candy_type){
        spawn.SpawnCandy(candy_type);
        changeTextVendingMachine("R$ " + payment);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        double value =  collision.gameObject.GetComponent<DragItem>().value;
        payment += value;
        changeTextVendingMachine("R$ " + payment);
    }

}
