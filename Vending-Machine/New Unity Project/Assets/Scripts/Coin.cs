using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CoinCannon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CoinCannon()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 50f * Time.deltaTime);
        Destroy(this.gameObject, 3f);
    }
}
