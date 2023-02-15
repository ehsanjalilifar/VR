using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureCollider : MonoBehaviour
{
    [SerializeField] private GameObject ground;

    float xRange, zRange;

    // Start is called before the first frame update
    void Start()
    { 
        xRange = ground.transform.localScale.x / 2.0f;
        zRange = ground.transform.localScale.z / 2.0f;

        // Randomly assign a position to a treasure.
        AssignRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Treasures should be reachable. So, relocate them if they are located inside an obstacle.
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            AssignRandomPosition();
        }

        // Collect the treasure when the player hits it.
        if (collision.gameObject.CompareTag("Player"))
        {
            // Do somthing ...
        }
    }

    private void AssignRandomPosition()
    {
        transform.position = new Vector3(
                Random.Range(-xRange + 1f, xRange - 1f),
                transform.position.y,
                Random.Range(-zRange + 1f, zRange - 1f));
    }
}
