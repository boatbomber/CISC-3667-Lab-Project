using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject airplane;

    // Start is called before the first frame update
    void Start()
    {
        // Every 2 seconds, Instantiate a bird
        InvokeRepeating("SpawnPlane", 0.0f, 8.0f);
    }

    void SpawnPlane()
    {
        Vector2 position = new Vector2(Random.Range(0, 1) > 0.5 ? -6 : 6, Random.Range(1.5f, 2.5f));
        Instantiate(airplane, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update() { }
}
