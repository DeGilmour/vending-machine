

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        spawn = spawnObject.GetComponent<Spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void acceptCandy(int candy_type){
        // double change = Math.Abs(payment - candy_value[candy_type]);
        candy = new Candy(candy_type=candy_type);
        Debug.Log("Payment: " + payment + " Candy value " + candy.decideWhichCandy());
        double change = payment - candy.decideWhichCandy();
        if (change >= 0)
        {
            Debug.Log("Give candy and change back, change: " + change);
            payment = 0;
            dropItem(candy_type);
        }
        else
        {
            Debug.Log("Not enough money");
            dropItem(candy_type);
        }
    }

    public void dropItem(int candy_type){
        spawn.SpawnCandy(candy_type);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        double value =  collision.gameObject.GetComponent<DragItem>().value;
        payment += value;
        Destroy(collision.gameObject);
    }

}
