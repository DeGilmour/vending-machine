using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoX : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] newSprite;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = newSprite[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        spriteRenderer.sprite = newSprite[1];
    }

    private void OnMouseUp()
    {
        spriteRenderer.sprite = newSprite[0];
    }
}
