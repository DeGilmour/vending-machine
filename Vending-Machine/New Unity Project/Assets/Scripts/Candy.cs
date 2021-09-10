using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private Dictionary<int, int> candy_value = new Dictionary<int, int>();
    void Start()
    {
        candy_value.Add(1, 6);
        candy_value.Add(2, 7);
        candy_value.Add(3, 8);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
