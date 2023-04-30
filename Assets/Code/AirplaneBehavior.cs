using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneBehavior : MonoBehaviour
{
    [SerializeField]
    int speed = 2;

    private int direction = 1; 

    // Start is called before the first frame update
    void Start()
    {
        direction = transform.position.x < 0 ? 1 : -1;
    }

    void Update()
    {
    }

    //called potentially many times per frame
    //use for physics & movement
    private void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(speed * Time.deltaTime * direction, 0, 0);
        transform.rotation = Quaternion.Euler(0, direction > 0 ? 180 : 0, 0);

        // Don't fly out of bounds
        if (transform.position.x < -6 || transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
