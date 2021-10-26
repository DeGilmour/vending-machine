using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject elevatorObj;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        var elevator = elevatorObj.GetComponent<Elevator>();
        if (collision.gameObject.CompareTag("CandyBox"))
        {
            elevator.OnBoxEnter(collision.gameObject);
        }
    }
}
