using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 100f;

    //[SerializeField] private KeyCode rightKey = KeyCode.RightArrow;

    //[SerializeField] private KeyCode leftKey = KeyCode.LeftArrow;

    [SerializeField] private float jumpSpeed = 125f;

    [SerializeField] private Transform groundCheck;

    [SerializeField] private float groundCheckRadius = 2f;

    [SerializeField] private float groundCheckSeparation;

    [SerializeField] private LayerMask groundMask;

    [SerializeField] private Collider2D groundCollider;

    [SerializeField] private Collider2D airCollider;

    [SerializeField] private float jumpMaxTime;

    private float lastJumpTime;

    [SerializeField] private float jumpGravity;

    [SerializeField] private float defaultGravity;

    private Rigidbody2D rb;



    //private Animator animator;

    private bool grounded;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {

        DetectGround();

        groundCollider.enabled = grounded;
        airCollider.enabled = !grounded;

        //Vector3 CurrentPosition = transform.position;
        Vector2 currentVelocity = rb.velocity;



        currentVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            currentVelocity.y = jumpSpeed;
            lastJumpTime = Time.time;
            rb.gravityScale = jumpGravity;
        }
        else if(Input.GetButton("Jump") && ((Time.time - lastJumpTime) < jumpMaxTime) && currentVelocity.y > 0)
        {
            rb.gravityScale = jumpGravity;
        }
        else
        {
            rb.gravityScale = defaultGravity;
            lastJumpTime = 0;
        }

        //transform.position = CurrentPosition;
        rb.velocity = currentVelocity;

        //animator.SetFloat("AbsVelocityX", Mathf.Abs(currentVelocity.x));

        //animator.SetFloat("VelocityY", currentVelocity.y);

        //animator.SetBool("OnGround", grounded);

        if (currentVelocity.x < 0 && transform.right.x > 0)
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        else if (currentVelocity.x > 0 && transform.right.x < 0)
            transform.rotation = Quaternion.identity;

        if (grounded)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void DetectGround()
    {
        Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);

        if (collider != null) grounded = true;
        else
        {
            collider = Physics2D.OverlapCircle(groundCheck.position + transform.right * groundCheckSeparation, groundCheckRadius, groundMask);
            if (collider != null) grounded = true;
            else
            {
                collider = Physics2D.OverlapCircle(groundCheck.position - transform.right * groundCheckSeparation, groundCheckRadius, groundMask);
                if (collider != null) grounded = true;
                else
                {
                    grounded = false;
                }
            }
        }

    }

    private void OnDrawGizmos()
    {
        if(groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position + transform.right * groundCheckSeparation, groundCheckRadius);
            Gizmos.DrawWireSphere(groundCheck.position - transform.right * groundCheckSeparation, groundCheckRadius);
        }
    }
}
