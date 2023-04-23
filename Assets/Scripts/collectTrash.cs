using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collectTrash : MonoBehaviour
{

    [SerializeField] private LayerMask playerMask;

    [SerializeField] private float canCheckRadius = 2f;

    private bool isHeld = false;

    [SerializeField] private float heldReach = 3f;

    private float holdingReach;

    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioSource audioClip;

    private void Awake()
    {
        holdingReach = canCheckRadius;
    }


    // Update is called once per frame
    private void Update()
    {
        


        DetectCollision();

        if (isHeld == true)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            ThrowTrash();
        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        
    }

    private void ThrowTrash()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {



            isHeld = false;

            //audioS = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<AudioSource>();
            //audioS.PlayOneShot(audioS.clip);

            if (transform.rotation == Quaternion.Euler(0f, 180f, 0f))
            {
                gameObject.transform.position += new Vector3(-10f, 0f, 0f);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-200f, 0f);
            }
            else
            {
                gameObject.transform.position += new Vector3(10f, 0f, 0f);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(200f, 0f);
            }

            
            
        }
    }
 

    private void DetectCollision()
    {
        Collider2D collider = Physics2D.OverlapCircle(gameObject.transform.position, canCheckRadius, playerMask);

        if (collider != null && !(collider.gameObject.GetComponent<playerProgress>().getHolding()))
        {
            collider.SendMessage("collectCans");
            isHeld = true;
        }

        if (isHeld == true)
        {
            gameObject.transform.position = collider.gameObject.transform.position + collider.gameObject.transform.right * (canCheckRadius);

            if (collider.gameObject.transform.right.x < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
            {
                transform.rotation = Quaternion.identity;
            }
        }
        else if (collider != null)
        {
            
            collider.SendMessage("stopHolding");
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, canCheckRadius);
    }
}
