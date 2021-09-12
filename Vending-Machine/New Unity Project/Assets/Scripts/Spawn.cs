using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject candyA, candyB, candyC;
    public Transform spawn;
    public new Component rigidbody;
    void Start()
    {
        // if(stop < 2)
        //    InvokeRepeating("SpawnCandy", 1, 3);
    }

    void Update()
    {
        
    }

    public void SpawnCandy(int candy_type)
    {
        GameObject candy = candyA;
        if(candy_type == 2)
            candy = candyB;
        else
            candy  = candyC;
        Instantiate(candy, spawn.position, Quaternion.identity).AddComponent(typeof(Rigidbody2D));

    }
}
