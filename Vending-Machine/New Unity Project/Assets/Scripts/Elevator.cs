using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    // Start is called before the first frame update
    public bool needsToMove;
    public float elevatorMoveSpeed, elevatorDecelerationsSpeed, elevatorMaxSpeed;
    public Transform shaft0, shaft1, shaft2, shaft3;
    public int floorToMove; // vai ser removido
    public Counter counter;
    private int boxInElevatorType;
    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        if(needsToMove) MoveElevator(floorToMove);
    }

    void MoveElevator(int position)
    {
        //1 = first floor.. and so on.
        var shaft = shaft0.position;
        switch (position)
        {
            case 1:
                shaft = shaft1.position;
                break;
            case 2:
                shaft = shaft2.position;
                break;
            case 3:
                shaft = shaft3.position;
                break;
        }
        transform.position = Vector2.MoveTowards(transform.position, shaft, elevatorMoveSpeed * Time.deltaTime);
        var toBeSpeed = elevatorMoveSpeed - 1f;
        var distanceBetweenShaftElevator = Vector3.Distance(transform.position, shaft);
        // All the physics  below is just for flavor

        if (distanceBetweenShaftElevator > 0 && toBeSpeed >= 0)
        {
            
            if (distanceBetweenShaftElevator <= 5) {
                elevatorMoveSpeed -= elevatorDecelerationsSpeed * Time.deltaTime * 3f; // Decelerates the elevator when it gets closer to the floor
                
            }
        }
        else if (distanceBetweenShaftElevator == 0)
        {
            needsToMove = false;
            elevatorMoveSpeed = 0f;
            StartCoroutine(OpenElevatorDoors());
        }
        if (distanceBetweenShaftElevator > 5 && elevatorMoveSpeed <= elevatorMaxSpeed)
        {
            elevatorMoveSpeed += elevatorDecelerationsSpeed * Time.deltaTime * 3f; // Accelerates the elevator when it gets further from the floor
            
        }
    }

    IEnumerator OpenElevatorDoors()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Opens the doors");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // needsToMove = false;
        if (collision.gameObject.CompareTag("CandyBox"))
        {
            counter.DecideWhichBox(collision.gameObject.GetComponent<CandyBox>().candyBoxType);
            boxInElevatorType = collision.gameObject.GetComponent<CandyBox>().candyBoxType;
            // Destroy(collision.gameObject, 1f);
        }
    }

    private void OnMouseDown()
    {
        // Instantiate the candy box inside the elevator
        counter.boxInElevator.GetComponent<CandyBox>().candyBoxType = boxInElevatorType;
        Instantiate(counter.boxInElevator, this.transform);
    }
}
