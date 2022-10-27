using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 10f;
    public float jump = 300f;
    public bool isOnTheGround = true;

    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundCheckRadius = 0.2f;

    public Rigidbody2D rb2D;
    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GroundCheck();
        PlayerMovement();
        PlayerJump();
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isOnTheGround)
        {
            Debug.Log("Jiump at mthod");
            //rb2D.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            rb2D.AddForce(Vector2.up * jump);
            //isOnTheGround = false;
        }
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
            Debug.Log("Right");
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
        }

        /*if (Input.GetKey("space"))
        {
            transform.Translate(new Vector2(0, jump * Time.deltaTime));
        }*/

        if (Input.GetKey(KeyCode.S) && !isOnTheGround)
        {
            transform.Translate(new Vector2(0, -speed * Time.deltaTime));
        }
    }

    void GroundCheck()
    {
        isOnTheGround = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isOnTheGround = true;
        }
    }

    /*private void OnCollisionEnter(Collision collision2D)
    {
        if(collision2D.gameObject.tag == "Ground"){
            isOnTheGround = true;
        }
    }*/
}
