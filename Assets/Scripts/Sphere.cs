using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sphere : MonoBehaviour
{
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector2( transform.localScale.x, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
        
    }
    
   
}
