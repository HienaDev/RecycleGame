using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectBoard : MonoBehaviour
{

    [SerializeField] private LayerMask playerMask;

    [SerializeField] private float boardCheckRadius = 2f;

    private bool isHeld = false;

    void Start()
    {

    }


    // Update is called once per frame
    private void Update()
    {
        DetectCollision();
    }

    private void DetectCollision()
    {
        Collider2D collider = Physics2D.OverlapCircle(gameObject.transform.position, boardCheckRadius, playerMask);

        if (collider != null && !(collider.gameObject.GetComponent<playerProgress>().getHolding()))
        {
            collider.SendMessage("collectBoards");

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, boardCheckRadius);
    }
}
