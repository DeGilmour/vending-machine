using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public GameObject boxInElevator;

    public int numberOfCandyA, numberOfCandyB, numberOfCandyC, maxNumberOfCandy;

    public Elevator elevator;

    public GameObject candbox1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (numberOfCandyA  <= 0)
        // {
        //     elevator.floorToMove = 1;
        // }
        // else if (numberOfCandyB <= 0)
        // {
        //     elevator.floorToMove = 2;
        // }
        // else if(numberOfCandyC <= 0)
        // {
        //     elevator.floorToMove = 3;
        // }
    }

    public void DecideWhichBox(int candyBoxType)
    {
        switch (candyBoxType)
        {
            case 1:
                boxInElevator = candbox1;
                break;
        }
    }

    public void AdjustCandyInMachine(int candyBoxType)
    {
        Debug.Log(candyBoxType);
        switch (candyBoxType)
        {
            case 1:
                numberOfCandyA = maxNumberOfCandy;
                break;
            case 2:
                numberOfCandyB = maxNumberOfCandy;
                break;
            case 3:
                numberOfCandyC = maxNumberOfCandy;
                break;
        }
    }
}
