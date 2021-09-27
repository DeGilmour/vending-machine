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
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(RandomVector() * 40f * Time.deltaTime);
        Destroy(this.gameObject, 3f);
    }

    private static Vector2 RandomVector()
    {
        int random = Random.Range(1, 3);
        Vector2 vector = random switch
        {
            1 => Vector2.up,
            2 => Vector2.left,
            3 => Vector2.right,
            _ => Vector2.down
        };
        return vector;
    }
}
