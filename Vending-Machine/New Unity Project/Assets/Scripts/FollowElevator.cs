using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowElevator : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform elevator;
    
    private void FixedUpdate()
    {
        this.gameObject.transform.position = new Vector3(0, elevator.transform.position.y + 0.7f, -10);
    }
}