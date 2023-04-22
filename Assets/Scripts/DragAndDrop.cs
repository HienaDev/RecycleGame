using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    //Initialize SerializeField variables
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private LayerMask dragMask;

    //Initialize variables
    private Vector3 mousePos;
    private Vector3 objectPos;
    private bool dragging;
    private Collider2D collider;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Convert mouse position to mouse position based on the camera
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

        //If the Left Mouse Button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            //Create a new vector with the mouse position and the z axis at 0
            objectPos = new Vector3(mousePos[0], mousePos[1], 0f);

            //Create a collider at the mouse position that checks for a draggable object
            collider = Physics2D.OverlapCircle(mousePos, 5, dragMask);
            
            //If it collided with a draggable object
            if (collider!=null)
            {
                //Set the dragging bool as true
                dragging = true;
            }
        }
        //If the Left Mouse Button is released
        else if(Input.GetMouseButtonUp(0))
        {
            //Set the dragging bool as false
            dragging = false;
        }

        //While the Left Mouse Button is being held
        if(dragging)
        {
            //Create a new vector with the mouse position and the z axis at 0
            objectPos = new Vector3(mousePos[0], mousePos[1], 0f);
            
            //Move the draggable object to the mouse position (with the z axis at 0)
            collider.transform.position = objectPos;
        }
    }
}
