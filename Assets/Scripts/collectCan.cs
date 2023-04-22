using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collectCan : MonoBehaviour
{

    public UnityEvent interactAction;

    [SerializeField] private LayerMask playerMask;

    [SerializeField] private float canCheckRadius = 2f;

    void Start()
    {
        
    }


    // Update is called once per frame
    private void Update()
    {
        DetectGround();
    }

    private void DetectGround()
    {
        Collider2D collider = Physics2D.OverlapCircle(gameObject.transform.position, canCheckRadius, playerMask);

        if (collider != null)
        {
            collider.SendMessage("collectCans");
            Destroy(gameObject);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, canCheckRadius);
    }
}
