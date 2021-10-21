using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alfredo : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform leftWall, rightWall;
    public float alfredoSpeed;
    public Animator alfredoAnimator;
    private bool goingLeft = true, goingRight = false, stopped=false;
    public SpriteRenderer alfredoSpriteRenderer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        AlfredoMovement();
    }

    void AlfredoMovement()
    {
        if (stopped) return;
        alfredoAnimator.SetBool("Running", true);
        if(goingLeft) transform.position = Vector2.MoveTowards(transform.position, leftWall.position, alfredoSpeed * Time.deltaTime);
        if(goingRight) transform.position = Vector2.MoveTowards(transform.position, rightWall.position, alfredoSpeed * Time.deltaTime);
        StartCoroutine(LazyAlfredo());

    }
    IEnumerator LazyAlfredo()
    {
        yield return new WaitForSeconds(5);
        alfredoAnimator.SetBool("Running", false);
        stopped = true;
        yield return new WaitForSeconds(5);
        stopped = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "AlfredoLeft")
        {
            goingRight = true;
            goingLeft = false;
            alfredoSpriteRenderer.flipX = true;
        }
        else if (collision.gameObject.name == "AlfredoRight")
        {
            goingLeft = true;
            goingRight = false;
            alfredoSpriteRenderer.flipX = false;
        }
        
    }
}
