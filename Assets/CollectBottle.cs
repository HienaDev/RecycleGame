using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBottle : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;

    [SerializeField] private float bottleCheckRadius = 2f;

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
        Collider2D collider = Physics2D.OverlapCircle(gameObject.transform.position, bottleCheckRadius, playerMask);

        if (collider != null && !(collider.gameObject.GetComponent<playerProgress>().getHolding()))
        {
            collider.SendMessage("collectBottle");
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, bottleCheckRadius);
    }
}
