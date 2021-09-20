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

    // Update is called once per frame
    void Update()
    {
    }

    public void AcceptCandy(int candyType)
    {
        candy = new Candy(candyType);
        int change = (int) (payment - candy.DecideWhichCandy());
        if (change >= 0)
        {
            ChangeTextVendingMachine($"{CalculateChange(change)}");
            payment = 0;
            DropItem(candyType);
            // ChangeTextVendingMachine("R$ " + payment);
        }
        else
        {
            ChangeTextVendingMachine("Not enough money");
        }
    }

    private static String CalculateChange(int change)
    {
        int[] coins = {5, 2, 1};
        int[] amounts = new int[coins.Length];
        string msg = "";

        for (int i = 0; i < coins.Length; i++)
        {
            amounts[i] = change / coins[i];
            change = change % coins[i];
        }

        // for (int i = 0; i < amounts.Length; i++)
        // {
        //     msg += $" Moedas de {coins[i]}: {amounts[i]}";
        // }
        Debug.Log(change);
        msg = $"Troco: R$ {change}";
        return msg;
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
        // ChangeTextVendingMachine("R$ " + payment);
    }

    public void DropCoin(int coinType)
    {
        spawn.spawnCoin(coinType);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        double value = collision.gameObject.GetComponent<DragItem>().value;
        payment += value;
        ChangeTextVendingMachine("R$ " + payment);
    }
}