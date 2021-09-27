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

    public Text screenValue;
    public Text screenChange;


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
            StartCoroutine(CalculateChange(change));
            screenChange.text = "TROCO: ";
            CalculateChange(change);
            payment = 0;
            DropItem(candyType);
        }
        else
        {
            screenChange.text = "ERRO";
        }
    }

    private IEnumerator CalculateChange(int change)
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
                yield return new WaitForSeconds(1);
                DropCoin(coins[i]);
            }
        }
    }

    private void ChangeTextVendingMachine(string msg)
    {
        Debug.Log(msg);
        screenValue.text = msg;
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
        StartCoroutine(spawn.spawnCoin(coinType));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Money")) return;
        double value = collision.gameObject.GetComponent<DragItem>().value;
        if (payment >= 15)
        {
            payment = 15; 
        }
        else
        {
            payment += value;
        }
        screenChange.text = "PAG.";
        ChangeTextVendingMachine($"{payment}");
    }
}