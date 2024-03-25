using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector2.left *  Time.deltaTime);
        if (transform.position.x < -10)
        {
            Destroy (gameObject);
        }
    }
}
