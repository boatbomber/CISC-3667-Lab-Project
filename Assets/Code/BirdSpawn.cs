using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject bird;

    // Start is called before the first frame update
    void Start()
    {
        // Every 2 seconds, Instantiate a bird
        InvokeRepeating("SpawnBird", 0.0f, 2.0f);
    }

    void SpawnBird()
    {
        Vector2 position = new Vector2(Random.Range(-3, 3), Random.Range(0.0f, 1.0f));
        Instantiate(bird, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update() { }
}
