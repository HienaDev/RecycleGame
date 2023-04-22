using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private LayerMask dragMask;
    private Vector3 mousePos;
    private Vector3 objectPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            objectPos = new Vector3(mousePos[0], mousePos[1], 0f);

            Collider2D collider = Physics2D.OverlapCircle(mousePos, 5, dragMask);
            
            if (collider!=null)
            {
                collider.transform.position = objectPos;
                Debug.Log(objectPos);
            }
        }
    }
}
