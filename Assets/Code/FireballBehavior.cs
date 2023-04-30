using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehavior : MonoBehaviour
{
    [SerializeField]
    float SPEED = 10.0f;

    [SerializeField]
    AudioSource hitSound;

    private Rigidbody2D rigid;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rigid = GetComponent<Rigidbody2D>();
        if (hitSound == null)
            hitSound = GetComponent<AudioSource>();

        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;

        rigid.velocity = new Vector2(direction.x, direction.y).normalized * SPEED;
    }

    void FixedUpdate()
    {
        Vector2 rotation = new Vector2(
            transform.position.x + rigid.velocity.x,
            transform.position.y + rigid.velocity.y
        ).normalized;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(hitSound.clip, transform.position);
        Destroy(gameObject);
    }
}
