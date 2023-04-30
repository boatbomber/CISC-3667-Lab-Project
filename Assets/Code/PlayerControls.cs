using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigid;

    [SerializeField]
    Animator animator;

    [SerializeField]
    GameObject fireball;

    [SerializeField]
    AudioSource fireSound;

    [SerializeField]
    int speed = 5;

    [SerializeField]
    float jumpForce = 160.0f;

    private float movement = 0.0f;
    private bool isFacingRight = true;
    private bool jumpPressed = false;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if (animator == null)
            animator = GetComponent<Animator>();
        if (fireball == null)
            fireball = Resources.Load<GameObject>("Assets/Fireball");
        if (fireSound == null)
            fireSound = GetComponent<AudioSource>();

        animator.SetBool("isJumping", !isGrounded);
        animator.SetBool("isMoving", movement != 0);
    }

    // Update is called once per frame --used for user input
    //do NOT use for physics & movement
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;

        if (Input.GetButtonDown("Fire1"))
        {
            AudioSource.PlayClipAtPoint(fireSound.clip, transform.position);
            Instantiate(fireball, transform.position, Quaternion.identity);
        }
    }

    //called potentially many times per frame
    //use for physics & movement
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(speed * movement, rigid.velocity.y);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();
        if (jumpPressed && isGrounded)
            Jump();
        else
            jumpPressed = false;

        animator.SetBool("isJumping", !isGrounded);
        animator.SetBool("isMoving", movement != 0);
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));

        jumpPressed = false;
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }
}
