using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstancle : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector2.left * 4*Time.deltaTime);
        if (transform.position.y < -5 )
        {
            Destroy (gameObject);
        }
    }
}
