using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float speed;
    public float range;
    private float startingposy;
    int dir = 1;
    public bool shouldWalkRight =true;
    void Start()
    {
        startingposy = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(shouldWalkRight==true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime * dir);
            if (transform.position.x < startingposy || transform.position.x > startingposy + range)
            {
                dir *= -1;
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            }
        }
      else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime * dir);
            if (transform.position.x > startingposy || transform.position.x < startingposy + range)
            {
                dir *= -1;
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            }
        }
       
    }
}
