using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public GameObject boxInElevator;

    public int numberOfCandyA, numberOfCandyB, numberOfCandyC, maxNumberOfCandy;

    public Elevator elevator;

    public GameObject candyBox1, candyBox2, candyBox3;
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
                boxInElevator = candyBox1;
                break;
            case 2:
                boxInElevator = candyBox2;
                break;
            case 3:
                boxInElevator = candyBox3;
                break;
        }
    }

    public void AdjustCandyInMachine(int candyBoxType)
    {
        Debug.Log("Candy box type " + candyBoxType);
        switch (candyBoxType)
        {
            case 3:
                numberOfCandyA = maxNumberOfCandy;
                break;
            case 2:
                numberOfCandyB = maxNumberOfCandy;
                break;
            case 1:
                numberOfCandyC = maxNumberOfCandy;
                break;
        }
        
    }
}
