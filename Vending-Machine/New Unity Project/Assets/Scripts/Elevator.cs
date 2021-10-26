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
    public int floorToMove, currentFloor = 0; // vai ser removido
    public Counter counter;
    private int boxInElevatorType;
    public AudioPlayer audioPlayer;
    public GameObject[] arrowsUp, arrowsDown;
    public GameObject audioPlayerObj;

    public Animator elevatorAnimator;
    void Start()
    {
        elevatorAnimator.SetBool("OpenDoors", true);
        audioPlayer = audioPlayerObj.GetComponent<AudioPlayer>();
    }

    void FixedUpdate()
    {
        if (needsToMove) MoveElevator(floorToMove);
    }

    void MoveElevator(int position)
    {
        //1 = first floor.. and so on.
        // elevatorAnimator.SetBool("OpenDoors", false);
        // elevatorAnimator.Play("ClosingDoors");
        // while (elevatorAnimator.GetCurrentAnimatorStateInfo (0).IsName("ClosingDoors")) {
        //     yield return new WaitForSeconds(3);
        // }
        // audioPlayer.ChooseAudioToPlay(7);
        if (currentFloor > floorToMove)
        {
            ChangeArrows(false);
        }
        else
        {
            ChangeArrows(true);
        }

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
            if (distanceBetweenShaftElevator <= 5)
            {
                elevatorMoveSpeed -=
                    elevatorDecelerationsSpeed * Time.deltaTime *
                    3f; // Decelerates the elevator when it gets closer to the floor
            }
        }
        else if (distanceBetweenShaftElevator == 0)
        {
            
            needsToMove = false;
            elevatorMoveSpeed = 0f;
            elevatorAnimator.SetBool("OpenDoors", true);
            currentFloor = floorToMove;
            audioPlayer.ChooseAudioToPlay(9);
        }

        if (distanceBetweenShaftElevator > 5 && elevatorMoveSpeed <= elevatorMaxSpeed)
        {
            elevatorMoveSpeed +=
                elevatorDecelerationsSpeed * Time.deltaTime *
                3f; // Accelerates the elevator when it gets further from the floor
        }
    }

    private void ChangeArrows(bool goingUp)
    {
        if (!goingUp)
        {
            foreach (var arrow in arrowsDown)
            {
                Debug.Log("Arrows down");
                arrow.GetComponent<SpriteRenderer>();
            }
        }
        else
        {
            foreach (var arrow in arrowsUp)
            {
                Debug.Log("Arrows up");
                arrow.GetComponent<SpriteRenderer>();
            }
        }
    }
    
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     // needsToMove = false;
    //     Debug.Log(collision.gameObject.name);
    //     if (collision.gameObject.CompareTag("CandyBox"))
    //     {
    //         counter.DecideWhichBox(collision.gameObject.GetComponent<CandyBox>().candyBoxType);
    //         boxInElevatorType = collision.gameObject.GetComponent<CandyBox>().candyBoxType;
    //         // Destroy(collision.gameObject, 1f);
    //     }
    //     if (collision.gameObject.CompareTag("Stop"))
    //     {
    //         Debug.Log("collided with ");
    //     }
    // }
    
    public void OnBoxEnter(GameObject box)
    {
        var candyBoxType = box.GetComponent<CandyBox>().candyBoxType;
        counter.DecideWhichBox(candyBoxType);
        boxInElevatorType = box.GetComponent<CandyBox>().candyBoxType;
    }
    
    // private void OnMouseDown()
    // {
    //     // Instantiate the candy box inside the elevator
    //     counter.boxInElevator.GetComponent<CandyBox>().candyBoxType = boxInElevatorType;
    //     GameObject clone = counter.boxInElevator;
    //     clone.GetComponent<CandyBox>().candyBoxType = boxInElevatorType;
    //     Destroy(Instantiate(clone, this.transform), 10f);
    // }

    public void DropBoxElevator()
    {
        counter.boxInElevator.GetComponent<CandyBox>().candyBoxType = boxInElevatorType;
        GameObject clone = counter.boxInElevator;
        clone.GetComponent<CandyBox>().candyBoxType = boxInElevatorType;
        Destroy(Instantiate(clone, this.transform), 10f);
    }
}