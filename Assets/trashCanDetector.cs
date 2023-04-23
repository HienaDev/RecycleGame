using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashCanDetector : MonoBehaviour
{
    [SerializeField] private LayerMask trashMask;

    [SerializeField] private float canCheckRadius = 2f;

    private GameController gameController;

    // Update is called once per frame
    private void Update()
    {
        DetectCollision();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }



    private void DetectCollision()
    {
        Collider2D collider = Physics2D.OverlapCircle(gameObject.transform.position, canCheckRadius, trashMask);

        if (collider != null)
        {
            gameController.ScoreIncrease();
            gameController.reduceIdleStrash();
            Destroy(collider.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, canCheckRadius);
    }
}
