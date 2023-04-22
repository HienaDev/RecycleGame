using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPaper : MonoBehaviour
{

    [SerializeField] private LayerMask playerMask;

    [SerializeField] private float paperCheckRadius = 2f;

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
        Collider2D collider = Physics2D.OverlapCircle(gameObject.transform.position, paperCheckRadius, playerMask);

        if (collider != null)
        {
            collider.SendMessage("collectPaper");
            Destroy(gameObject);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, paperCheckRadius);
    }
}
