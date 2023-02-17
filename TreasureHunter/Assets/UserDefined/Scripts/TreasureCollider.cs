using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureCollider : MonoBehaviour
{
    public static int count = 0;

    [SerializeField] private GameObject ground;

    float xRange, zRange, initialHeight;

    // Start is called before the first frame update
    void Start()
    { 
        xRange = ground.transform.localScale.x / 2.0f;
        zRange = ground.transform.localScale.z / 2.0f;

        initialHeight = gameObject.transform.position.y; // We need this variable to reset the scene (Check the trick for disabling the treasure)

        // Randomly assign a position to a treasure.
        AssignRandomPosition();
    }

    private void Update()
    {
        // We want to collect the treasure (disable it) when the treasure is grabbed.
        if(transform.GetComponent<OVRGrabbable>().isGrabbed)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                        -5f,
                                                        gameObject.transform.position.z);
            // We have to do this trick because when the treasure is grabbed and we disable it,
            // we encounter a bug. The player will not be able to move anymore!
            // Thus, we hide the treasure first and then we disable it (while the treasure is not grabbed)
        }

        if (!transform.GetComponent<OVRGrabbable>().isGrabbed && gameObject.transform.position.y < 0)
        {
            gameObject.SetActive(false);
        }


    }

    // Update is called once per frame
    private void OnDisable()
    {
        count--;
    }

    private void OnEnable()
    {
        count++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Treasures should be reachable. So, relocate them if they are located inside an obstacle.
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            AssignRandomPosition();
        }
    }

    private void AssignRandomPosition()
    {
        transform.position = new Vector3(
                Random.Range(-xRange + 1f, xRange - 1f),
                transform.position.y,
                Random.Range(-zRange + 1f, zRange - 1f));
    }

    public void Reset()
    {
        if (!gameObject.activeSelf) gameObject.SetActive(true);

        transform.position = new Vector3(
                Random.Range(-xRange + 1f, xRange - 1f),
                initialHeight,
                Random.Range(-zRange + 1f, zRange - 1f));
        
    }
}
