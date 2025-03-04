using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    public bool isgoingSideway= false;
    public bool isgoingAbove = false;
    public bool up = false;
    public bool right = false;
    public float speed;
    public float range;
    private float startingposy;
    private float startingposx;
    int dir = 1;
    void Start()
    {
        startingposy = transform.position.y;
        startingposx = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isgoingAbove== true)
        {
            if(up==true)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime * dir);
                if (transform.position.y < startingposy || transform.position.y > startingposy + range)
                {
                    dir *= -1;
                }
            }
            else
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime * dir);
                if (transform.position.y > startingposy || transform.position.y < startingposy + range)
                {
                    dir *= -1;
                }
            }
         
        }
        if(isgoingSideway== true)
        {
            if(right==true)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime * dir);
                if (transform.position.x < startingposx || transform.position.x > startingposx + range)
                {
                    dir *= -1;
                }
            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime * dir);
                if (transform.position.x > startingposx || transform.position.x < startingposx + range)
                {
                    dir *= -1;
                }
            }
        }

     
    }
}
