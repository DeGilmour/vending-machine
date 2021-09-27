using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public AudioPlayer audioPlayer;

    public GameObject audioPlayerObj;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = audioPlayerObj.GetComponent<AudioPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Candy"))
        {
            SpriteRenderer candySprite = collision.gameObject.GetComponent<SpriteRenderer>();
            candySprite.sortingLayerName = "Coins";
            audioPlayer.ChooseAudioToPlay(4);
        }
    }
    
}
