using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject bird;

    private float timeSinceSpawn = 0.0f;
    private float spawnFreq = 2.0f;

    // Start is called before the first frame update
    void Start() { }

    void SpawnBird()
    {
        Vector2 position = new Vector2(Random.Range(-3, 3), Random.Range(0.0f, 1.0f));
        Instantiate(bird, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (
            SceneManager.GetActiveScene().buildIndex < 4 // Don't spawn birds on menu, help, settings, or end screens
        )
            return;

        spawnFreq = 0.5f + 3.0f / SceneManager.GetActiveScene().buildIndex;

        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn > spawnFreq)
        {
            SpawnBird();
            timeSinceSpawn = 0.0f;
        }
    }
}
