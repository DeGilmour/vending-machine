using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Drag();
    }
    void OnMouseDown()
    {
        being_dragged = true;
    }
    void OnMouseUp()
    {
        being_dragged = false;
        if (itemToBeDragged.gameObject.CompareTag("Money")){
            itemToBeDragged.gameObject.transform.position = pos;
            itemToBeDragged.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else{
            // I added this just for flavor, basically it gets the speed in which the object its released(mouse input) * 1000 and sets that to be the current velocity
            var mouseVector = new Vector2(Input.GetAxis("Mouse X") * 1000f, Input.GetAxis("Mouse Y") * 1000f);
            var rigid = itemToBeDragged.gameObject.GetComponent<Rigidbody2D>();
            rigid.velocity = (mouseVector * Time.deltaTime) / rigid.mass;
        }
    }

    void Drag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = mousePos;
    }

}


