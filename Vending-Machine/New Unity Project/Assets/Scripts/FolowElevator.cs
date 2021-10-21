using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowElevator : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform elevator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        this.gameObject.transform.position = new Vector3(0, elevator.transform.position.y, -10);
    }
}
