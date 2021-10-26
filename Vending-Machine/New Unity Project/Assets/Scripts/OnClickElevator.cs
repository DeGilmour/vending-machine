using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickElevator : MonoBehaviour
{
    // private SpriteRenderer spriteRenderer;
    // public Sprite newSprite, oldSprite;
    public Elevator elevator;

    public GameObject elevatorObj;

    public int floorToMove;
    // Start is called before the first frame update
    void Start()
    {
        elevator = elevatorObj.GetComponent<Elevator>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        Debug.Log("Needs to move to " + floorToMove);
        MoveToFloor(floorToMove);
    }

    public void MoveToFloor(int floor)
    {
        elevator.floorToMove = floor;
        elevator.needsToMove = true;
    }
    void OnMouseUp()
    {
        // ChangeSprite(0);
    }
    // void ChangeSprite(int type) 
    // {
    //     if(type == 1)
    //         spriteRenderer.sprite = newSprite;
    //     else
    //         spriteRenderer.sprite = oldSprite;
    // }
}
