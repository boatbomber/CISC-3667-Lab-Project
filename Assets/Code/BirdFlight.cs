using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdFlight : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigid;

    [SerializeField]
    Animator animator;

    [SerializeField]
    AudioSource deathSound;

    [SerializeField]
    float speed = 2.0f;

    [SerializeField]
    float jumpForce = 95.0f;

    [SerializeField]
    bool isDead = false;

    private int direction = 1;
    private float timeSinceFlap = 0.0f;
    private float flapFreq = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if (animator == null)
            animator = GetComponent<Animator>();
        if (deathSound == null)
            deathSound = GetComponent<AudioSource>();

        animator.SetBool("isDead", isDead);
    }

    // Update is called once per frame --used for user input
    //do NOT use for physics & movement
    void Update()
    {
        // No user input needed for flight, but we make the birds fly faster every level
        speed = SceneManager.GetActiveScene().buildIndex * 0.75f;
    }

    private void Flap()
    {
        timeSinceFlap = 0.0f;

        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce * Random.Range(0.8f, 1.2f)));
    }

    private void Die()
    {
        if (isDead)
            return; // Already dead

        isDead = true;
        animator.SetBool("isDead", isDead);
        rigid.freezeRotation = false;

        AudioSource.PlayClipAtPoint(deathSound.clip, transform.position);
        Destroy(gameObject, 2);

        int heightPoints = 1 + (int)transform.position.y * 2;

        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        if (controller != null)
        {
            controller.GetComponent<Scorekeeper>().AddPoints(heightPoints);
        }
    }

    //called potentially many times per frame
    //use for physics & movement
    private void FixedUpdate()
    {
        if (isDead)
            return;

        timeSinceFlap += Time.deltaTime;
        if (timeSinceFlap > (flapFreq * Random.Range(0.9f, 1.25f)))
            Flap();

        // Don't fly out of bounds
        if (transform.position.x < -4)
        {
            direction = 1;
        }
        else if (transform.position.x > 4)
        {
            direction = -1;
        }

        rigid.velocity = new Vector2(direction > 0 ? speed : -speed, rigid.velocity.y);
        transform.rotation = Quaternion.Euler(0, direction > 0 ? 180 : 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            // Drop dead when an attack hits
            Die();
        }
        else if (collision.gameObject.tag == "Wall")
        {
            // Turn around when hitting a wall
            direction *= -1;
        }
        else if (collision.gameObject.tag == "BirdEscape")
        {
            // Game is over if a bird escapes
            Destroy(gameObject);
            GameObject controller = GameObject.FindGameObjectWithTag("GameController");
            if (controller != null)
            {
                controller.GetComponent<Scorekeeper>().ResetGame();
            }
        }
    }
}
