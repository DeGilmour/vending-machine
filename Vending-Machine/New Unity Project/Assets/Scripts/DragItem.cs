using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragItem : MonoBehaviour
{
    public Collider2D itemToBeDragged;
    public Vector3 pos;
    public double value;
    bool being_dragged;
    // Start is called before the first frame update
    void Start()
    {
        itemToBeDragged = GetComponent<Collider2D>();
        pos = itemToBeDragged.gameObject.transform.position;
        being_dragged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (being_dragged)
            drag();
    }
    void OnMouseDown()
    {
        being_dragged = true;
    }
    void OnMouseUp()
    {
        being_dragged = false;
        if (itemToBeDragged.gameObject.tag == "Money"){
            itemToBeDragged.gameObject.transform.position = pos;
            itemToBeDragged.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    void drag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = mousePos;
    }

}


