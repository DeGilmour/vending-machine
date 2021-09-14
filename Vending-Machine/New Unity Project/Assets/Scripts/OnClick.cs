using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnClick : MonoBehaviour
{
    // public Button doceA, doceB, doceC;
    public GameObject doceA, doceB, doceC;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite, oldSprite;
    // Nao consigo acessar o script sem ser pegando do objeto, se voces conseguirem arrumem isso.
    public GameObject vendingMachine;
    public VendingMachine vendingMachineObj;
    void Start()
    {
        // doceA.onClick.AddListener(() => acceptCandy(1));
        // doceB.onClick.AddListener(() => acceptCandy(2));
        // doceC.onClick.AddListener(() => acceptCandy(3));
        vendingMachineObj = vendingMachine.GetComponent<VendingMachine>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void acceptCandy(int type){
        vendingMachineObj.acceptCandy(type);
    }

    void OnMouseDown()
    {
        
        ChangeSprite(1);
        int type = 0;
        if(this.gameObject.name == "buttonA"){
            type = 1;
        }
        else if(this.gameObject.name == "buttonB")
            type = 2;
        else
            type = 3;
        acceptCandy(type);
    }
    
    void OnMouseUp()
    {
        ChangeSprite(0);
        
    }
    void ChangeSprite(int type) 
    {
        if(type == 1)
            spriteRenderer.sprite = newSprite;
        else
            spriteRenderer.sprite = oldSprite;
    }
}   
