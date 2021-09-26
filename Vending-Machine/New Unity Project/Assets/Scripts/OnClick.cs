using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnClick : MonoBehaviour
{
    // public Button doceA, doceB, doceC;
    private SpriteRenderer spriteRenderer;
    public Sprite newSprite, oldSprite;
    // Nao consigo acessar o script sem ser pegando do objeto, se voces conseguirem arrumem isso.
    public GameObject vendingMachine, audioPlayerObj;
    public VendingMachine vendingMachineObj;
    public int buttonType;
    public AudioPlayer audioPlayer;
    void Start()
    {
        vendingMachineObj = vendingMachine.GetComponent<VendingMachine>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        audioPlayer = audioPlayerObj.GetComponent<AudioPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AcceptCandy(int type){

        vendingMachineObj.AcceptCandy(type);
    }

    void OnMouseDown()
    {
        
        ChangeSprite(1);
        AcceptCandy(buttonType);
        audioPlayer.ChooseAudioToPlay(2);
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
