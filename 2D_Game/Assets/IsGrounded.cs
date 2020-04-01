using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 10;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        // Does the ray intersect any objects excluding the player layer
        if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.down) *5 , Color.yellow);
            Debug.Log("Did Hit---------------------------------------");
        }
        else
        {
           // Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.down) * 5, Color.white);
            Debug.Log("Did not Hit");
        }


    }



}
