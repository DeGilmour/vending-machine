using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;
using UnityEditor;

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
            CalculateChange(change);
            payment = 0;
            DropItem(candyType);
        }
        else
        {
            ChangeTextVendingMachine("Not enough money");
        }
    }

    private void CalculateChange(int change)
    {
        int[] coins = {5, 2, 1};
        int[] amounts = new int[coins.Length];
        string msg = "";

        for (int i = 0; i < coins.Length; i++)
        {
            amounts[i] = change / coins[i];
            change = change % coins[i];
        }

        for (int i = 0; i < amounts.Length; i++)
        {
            msg += $" Moedas de {coins[i]}: {amounts[i]}";
            for (var c = 1; c <= amounts[i]; c++)
            {
                DropCoin(coins[i]);
            }
        }
    }

    private void ChangeTextVendingMachine(string msg)
    {
        screen.text = msg;
    }

    private void CallAlertUnity(string msg)
    {
        EditorUtility.DisplayDialog("Resultado do Troco", msg, "Okay");
    }

    private void DropItem(int candyType)
    {
        spawn.spawnCandy(candyType);
    }

    public void DropCoin(int coinType)
    {
        spawn.spawnCoin(coinType);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Money")) return;
        double value = collision.gameObject.GetComponent<DragItem>().value;
        payment += value;
        ChangeTextVendingMachine($"{payment}");
    }
}