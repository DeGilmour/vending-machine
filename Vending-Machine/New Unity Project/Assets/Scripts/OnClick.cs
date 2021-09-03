using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnClick : MonoBehaviour
{
    public Button doceA, doceB, doceC;
    // Nao consigo acessar o script sem ser pegando do objeto, se voces conseguirem arrumem isso.
    public GameObject vendingMachine;
    public VendingMachine vendingMachineObj;
    void Start()
    {
        doceA.onClick.AddListener(() => acceptCandy(1));
        doceB.onClick.AddListener(() => acceptCandy(2));
        doceC.onClick.AddListener(() => acceptCandy(3));
        vendingMachineObj = vendingMachine.GetComponent<VendingMachine>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void acceptCandy(int type){
        vendingMachineObj.acceptCandy(type);
    }

}   
