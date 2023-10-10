using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    public float xLimit = 12f;
    public float yLimit = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xLimit)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > xLimit)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < -yLimit)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > yLimit)
        {
            Destroy(gameObject);
        }
    }
}
