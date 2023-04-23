using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField]
    private LayerMask binMask;
    [SerializeField]
    private string colour;

    private Vector3 objectPos;
    private Collider2D collider;

    private Dictionary<int, GameObject> trashObjects;

    // Update is called once per frame
    void Update()
    {
        //If the Left Mouse Button is pressed
        if (Input.GetMouseButtonUp(0))
        {
            //Create a collider at the mouse position that checks for a draggable object
            collider = Physics2D.OverlapCircle(gameObject.transform.position, 5, binMask);
            
            //If it collided with a draggable object
            if (collider!=null)
            {
                if (collider.gameObject.GetComponent<Bin>().GetColour() == colour)
                {
                    GameObject.Find("SceneManager").GetComponent<trashSpawner>().SpawnTrash();
                    Destroy(gameObject);
                }
                else
                {
                    gameObject.transform.position = new Vector3(-150,70,0);
                }
            }
        }
    }
}
