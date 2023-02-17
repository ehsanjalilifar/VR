using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleLocator : MonoBehaviour
{
    [SerializeField] private GameObject ground;

    float xRange, zRange;

    // Start is called before the first frame update
    void Start()
    {
        xRange = ground.transform.localScale.x / 2.0f;
        zRange = ground.transform.localScale.z / 2.0f;

        AssignRandomPosition();

        // Obstacles have normal rigid body by default which is required for the collision detection.
        // After positining the obstacles, we don't want them to move. So, we make them kinematic rigid body.
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //gameObject.GetComponent<BoxCollider>().isTrigger = true;

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Treasures should be reachable. So, relocate them if they are located inside an obstacle.
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            AssignRandomPosition();
            Debug.Log("Obstacle was relocated");
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
