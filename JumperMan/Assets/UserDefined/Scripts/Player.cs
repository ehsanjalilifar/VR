using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //move the player to  the starting position if hit an enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            // transform.position = new Vector3(0f, 0.5f, 0f);
            Debug.Log("Collision detected");
        }
    }


}
