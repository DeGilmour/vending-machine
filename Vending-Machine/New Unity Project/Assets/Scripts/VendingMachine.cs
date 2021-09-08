using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    // Start is called before the first frame update
    private int credit;
    private int[] candiesInMachine = new int[15];
    double money;
    private Dictionary<int, int> candy_value = new Dictionary<int, int>();
 
    void Start()
    {
        candy_value.Add(1, 6);
        candy_value.Add(2, 7);
        candy_value.Add(3, 8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void acceptCandy(int candy_type){
        var diff = money.CompareTo(candy_type);
        double change = Math.Abs(money -  candy_value[candy_type]);
        if(diff > 0){
            Debug.Log("Give candy and change back, change: " + change);
        }
        else{
            Debug.Log("Not enough money");
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        double value =  collision.gameObject.GetComponent<DragItem>().value;
        money += value;
    }

}
