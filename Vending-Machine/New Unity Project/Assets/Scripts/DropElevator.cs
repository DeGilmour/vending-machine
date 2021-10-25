using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropElevator : MonoBehaviour
{
    public GameObject elevator_obj;
    private void OnMouseDown()
    {
        var elevator_ = elevator_obj.GetComponent<Elevator>();
        elevator_.DropBoxElevator();
    }
}
