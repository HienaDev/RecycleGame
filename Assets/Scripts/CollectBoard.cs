using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectBoard : MonoBehaviour
{

    [SerializeField] private LayerMask playerMask;

    [SerializeField] private float boardCheckRadius = 2f;

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

        if (collider != null)
        {
            collider.SendMessage("collectBoards");
            Destroy(gameObject);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, boardCheckRadius);
    }
}
