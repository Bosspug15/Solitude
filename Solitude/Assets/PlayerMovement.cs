using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;


    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 7f;


    // Start is called before the first frame update
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Setting a variable to get the horizontal value that is given with input system
        //Create a new vector2 that changes X value based on dirX and keep same Y
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        //Create a new vector2 that changes the Y value and keep same X
        if (Input.GetButtonDown("Jump")) {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState() {
        if (dirX > 0f)
        {
            anim.SetBool("Run", true);
            sprite.flipX = false;

        }
        else if (dirX < 0f)
        {
            anim.SetBool("Run", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
}
